using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;

namespace AppMultisport {

    public partial class Form1 : Form {
        
        private List<SqlInt32> foundEmployeeIDs = new List<SqlInt32>();
        private SqlInt32 selectedEmployeeID;
        private bool addingNewEmployee;
        private Card currentCard;
        private Card alreadyPlannedCard;
        private EPPlusXlsxWriter fileWriter = new EPPlusXlsxWriter();

        private void SetupDepartments() {
            List<Dept> departments = DAO.GetDepartments();
            identityInput1.SetupDepartments(departments);
            employeeDataPanel1.SetupDepartments(new List<Dept>(departments));  //Nowa lista, by comboBoksy przewijały się osobno.
        }

        //Kliknięcie przycisku "Dalej" po podaniu danych pracownika
        private void buttonFindEmployee_Click(object sender, EventArgs e) {
            if (identityInput1.FirstName.Equals(string.Empty) || identityInput1.LastName.Equals(String.Empty) || (!identityInput1.DepartmentSelected && !identityInput1.Retired)) {
                MessageBox.Show("Dane pracownika muszą być kompletne.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else {
                identityInput1.Enabled = false;
                buttonFindEmployee.Enabled = false;
                try {
                    if (identityInput1.Retired) {
                        foundEmployeeIDs = DAO.GetRetiredEmployeeIDs(identityInput1.FirstName, identityInput1.LastName);
                    } else {
                        foundEmployeeIDs = DAO.GetEmployeeIDs(identityInput1.FirstName, identityInput1.LastName, identityInput1.Department);
                    }
                    string addAsNewPersonStr = "Dodaj jako nową osobę";
                    switch (foundEmployeeIDs.Count) {
                        case 0:  //Na pewno nowy pracownik - od razu przejdź do ustawiania karty
                            EditNewEmployee();
                            break;
                        case 1:  //Zarejestrowany pracownik lub nowy, "identyczny" - wyświetl jego ID oraz wybór Dodaj osobę
                            narrowDownPanel1.ListBoxEmployees.Items.Clear();
                            narrowDownPanel1.ListBoxEmployees.Items.Add("Osoba już zarejestrowana");
                            narrowDownPanel1.ListBoxEmployees.Items.Add(addAsNewPersonStr);
                            narrowDownPanel1.Enabled = true;
                            break;
                        default:  //Jeden z "identycznych" zarejestrowanych pracowników lub nowy - wyświetl ich ID, a także datę założenia karty, no i wybór Dodaj osobę
                            narrowDownPanel1.ListBoxEmployees.Items.Clear();
                            for (int i = 0; i < foundEmployeeIDs.Count; ++i) {
                                narrowDownPanel1.ListBoxEmployees.Items.Add("ID: " + foundEmployeeIDs[i] + "; Dołączenie: " + DAO.GetJoinDate(foundEmployeeIDs[i]).ToString("dd.MM.yyyy"));
                            }
                            narrowDownPanel1.ListBoxEmployees.Items.Add(addAsNewPersonStr);
                            narrowDownPanel1.Enabled = true;
                            break;
                    }
                } catch (SqlException exception) {
                    ShowDatabaseErrorMessage(exception);
                    ReturnToStart();
                }
            }
        }

        private void identityNarrowDownPanel1_NextClick(object sender, EventArgs e) {
            narrowDownPanel1.Enabled = false;
            menuItemEditDepts.Enabled = false;
            if (narrowDownPanel1.ListBoxEmployees.SelectedIndex == foundEmployeeIDs.Count) {  //Jeżeli została wybrana opcja dodania nowej osoby
                EditNewEmployee();
            } else {  //Jeżeli została wybrana któraś z już zarejestrowanych osób
                selectedEmployeeID = foundEmployeeIDs[narrowDownPanel1.ListBoxEmployees.SelectedIndex];
                try {
                    currentCard = DAO.GetCardOrNull(DateTime.Today, selectedEmployeeID);
                    alreadyPlannedCard = DAO.GetPlannedCardOrNull(selectedEmployeeID);
                } catch (SqlException exception) {
                    ShowDatabaseErrorMessage(exception);
                    ReturnToStart();
                }
                EditRegisteredEmployee();
            }
        }

        private void identityNarrowDownPanel1_CancelClick(object sender, EventArgs e) {
            narrowDownPanel1.Clear();
            narrowDownPanel1.Enabled = false;
            ReturnToStart();
        }

        private void EditNewEmployee() {
            addingNewEmployee = true;
            cardStatusPanel1.SetupForNewCard();
            cardStatusPanel1.Enabled = true;
            buttonConfirm.Enabled = true;
            buttonCancel.Enabled = true;
        }

        private void EditRegisteredEmployee() {
            addingNewEmployee = false;
            if (alreadyPlannedCard == null) {
                cardStatusPanel1.SetupForCard(currentCard);
            } else {
                if (currentCard != null) {
                    cardStatusPanel1.SetupForCards(currentCard, alreadyPlannedCard);
                } else {
                    cardStatusPanel1.SetupForPlannedCard(alreadyPlannedCard);
                }
                
            }
            cardStatusPanel1.Enabled = true;
            employeeDataPanel1.Enabled = true;
            employeeDataPanel1.SetRetirement(identityInput1.Retired);
            buttonDeleteEmployee.Enabled = true;
            buttonConfirm.Enabled = true;
            buttonCancel.Enabled = true;
        }

        private void buttonConfirm_Click(object sender, EventArgs e) {
            try {
                if (
                    (employeeDataPanel1.ChangingFirstName && employeeDataPanel1.NewFirstName.Equals(string.Empty)) 
                    || 
                    (employeeDataPanel1.ChangingLastName && employeeDataPanel1.NewLastName.Equals(string.Empty))
                    ||
                    (identityInput1.Retired && employeeDataPanel1.ChangingRetirement && !employeeDataPanel1.ChangingDept)
                ) {
                    if (identityInput1.Retired && employeeDataPanel1.ChangingRetirement && !employeeDataPanel1.ChangingDept) {
                        MessageBox.Show("Proszę określić dział pracownika powracającego z emerytury.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } else {
                        MessageBox.Show("Dane pracownika nie mogą być puste.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } else {
                    bool deadlineOK = true;
                    if (addingNewEmployee) {
                        deadlineOK = Rules.CheckDeadline(DateTime.Today, Card.TypeOfChange.TypeChange);
                        if (deadlineOK) {
                            if (identityInput1.Retired) {
                               DAO.AddNewEmployee(identityInput1.FirstName, identityInput1.LastName, null, new Card(cardStatusPanel1.SelectedOption), true);
                            } else {
                                DAO.AddNewEmployee(identityInput1.FirstName, identityInput1.LastName, identityInput1.Department, new Card(cardStatusPanel1.SelectedOption), false);
                            }
                        } else {
                            MessageBox.Show(Rules.DeadlineMessage(Card.TypeOfChange.TypeChange), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        ReturnToStart();
                    } else {

                        if (currentCard == null) {
                            //Przypadek szczególny - zmiana karty pracownika, który jeszcze nie otrzymał swojej pierwszej karty.
                            if (cardStatusPanel1.SelectedOption == CardStatusRadioPanel.CardStatusSelection.Inactive) {
                                //Wycofanie zamówienia pierwszej karty
                                deadlineOK = Rules.CheckDeadline(DateTime.Today, Card.TypeOfChange.ActivationChange);
                                if (deadlineOK) {
                                    DAO.DeleteEmployee(selectedEmployeeID);
                                } else {
                                    MessageBox.Show(Rules.DeadlineMessage(Card.TypeOfChange.ActivationChange), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }                                
                            } else {
                                Card newlyPlannedCard = new Card(cardStatusPanel1.SelectedOption);
                                if (newlyPlannedCard.Type != alreadyPlannedCard.Type) {
                                    //Zmiana typu pierwszej, nieotrzymanej jeszcze karty
                                    deadlineOK = Rules.CheckDeadline(DateTime.Today, Card.TypeOfChange.TypeChange);
                                    if (deadlineOK) {
                                        DAO.ModifyPlannedCardUpdate(selectedEmployeeID, newlyPlannedCard);
                                    } else {
                                        MessageBox.Show(Rules.DeadlineMessage(Card.TypeOfChange.TypeChange), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                        } else {
                            Card.TypeOfChange currentChange = Card.DetermineTypeOfChange(currentCard, cardStatusPanel1.SelectedOption);
                            if (alreadyPlannedCard == null) {

                                //Zmiana nie była wcześniej planowana
                                if (currentChange != Card.TypeOfChange.NoChange) {
                                    deadlineOK = Rules.CheckDeadline(DateTime.Today, currentChange);
                                    if (deadlineOK) {
                                        DAO.AddCardUpdate(selectedEmployeeID, Card.AfterUpdate(currentCard, currentChange));
                                    } else {
                                        MessageBox.Show(Rules.DeadlineMessage(currentChange), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }

                            } else {

                                //Zmiana była wcześniej planowana
                                Card.TypeOfChange replacedChange = Card.DetermineTypeOfChange(currentCard, alreadyPlannedCard);
                                if (currentChange != Card.TypeOfChange.NoChange) {
                                    if (currentChange != replacedChange) {
                                        //Zmienia się plany
                                        deadlineOK = Rules.CheckDeadline(DateTime.Today, currentChange) && Rules.CheckDeadline(DateTime.Today, replacedChange);
                                        if (deadlineOK) {
                                            DAO.ModifyPlannedCardUpdate(selectedEmployeeID, Card.AfterUpdate(currentCard, currentChange));
                                        } else {
                                            MessageBox.Show("Upłynął termin wprowadzania tej zmiany.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                } else {
                                    //Planowana zmiana jest wycofywana
                                    deadlineOK = Rules.CheckDeadline(DateTime.Today, replacedChange);
                                    if (deadlineOK) {
                                        DAO.DeletePlannedCardUpdate(selectedEmployeeID);
                                    } else {
                                        MessageBox.Show(Rules.DeadlineMessage(replacedChange), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                        }

                        if (deadlineOK) {
                            if (employeeDataPanel1.ChangingFirstName) {
                                DAO.UpdateFirstName(selectedEmployeeID, employeeDataPanel1.NewFirstName);
                            }
                            if (employeeDataPanel1.ChangingLastName) {
                                DAO.UpdateLastName(selectedEmployeeID, employeeDataPanel1.NewLastName);
                            }
                            if (employeeDataPanel1.ChangingDept) {
                                DAO.UpdateEmployeesDepartment(selectedEmployeeID, employeeDataPanel1.NewDept);
                            }
                            if (employeeDataPanel1.ChangingRetirement) {
                                DAO.UpdateRetirement(selectedEmployeeID, !identityInput1.Retired);
                            }
                        }

                        ReturnToStart();
                    }
                }
            } catch (SqlException exception) {
                ShowDatabaseErrorMessage(exception);
                ReturnToStart();
            }


}

        private void buttonCancel_Click(object sender, EventArgs e) {
            ReturnToStart();
        }

        private void buttonDeleteEmployee_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Czy na pewno usunąć z bazy dane i historię kart tego pracownika?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                try {
                    DAO.DeleteEmployee(selectedEmployeeID);
                } catch (SqlException exception) {
                    ShowDatabaseErrorMessage(exception);
                }
                ReturnToStart();
            }
        }

        private void ReturnToStart() {
            buttonConfirm.Enabled = false;
            buttonCancel.Enabled = false;
            buttonDeleteEmployee.Enabled = false;

            cardStatusPanel1.ClearSetup();
            cardStatusPanel1.Enabled = false;
            employeeDataPanel1.Clear();
            employeeDataPanel1.Enabled = false;

            narrowDownPanel1.ListBoxEmployees.Items.Clear();
            narrowDownPanel1.Enabled = false;

            foundEmployeeIDs.Clear();

            identityInput1.Enabled = true;
            buttonFindEmployee.Enabled = true;
            menuItemEditDepts.Enabled = true;
        }

        private void menuItemGenerateCurrent_Click(object sender, EventArgs e) {
            CreateReportFile(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1));
        }

        private void menuItemGenerateForSelectedMonth_Click(object sender, EventArgs e) {
            MonthDateDialog dialog = new MonthDateDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                CreateReportFile(dialog.SelectedDate);
            }
        }

        private void CreateReportFile(DateTime date) {
            Report report;
            try {
                report = new Report(date);
                saveFileDialog.FileName = "POTRĄCENIA " + Rules.MotivationProgramCompanyName + "_" + report.Date.ToString("MMMMyyyy") + ".xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    fileWriter.CreateOrOverwriteFile(saveFileDialog.FileName, report);
                }
            } catch (SqlException exception) {
                ShowDatabaseErrorMessage(exception);
            } catch (IOException exception) {
                MessageBox.Show("Wystąpił błąd podczas zapisywania pliku: " + exception.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuItemEditDepts_Click(object sender, EventArgs e) {
            ReturnToStart();
            try {
                DeptForm dialog = new DeptForm();
                if (dialog.ShowDialog() == DialogResult.OK) {
                    SetupDepartments();
                }
            } catch (SqlException exception) {
                ShowDatabaseErrorMessage(exception);
                Application.Exit();
            }
        }

        private void ShowDatabaseErrorMessage(SqlException exception) {
            MessageBox.Show("Wystąpił błąd przy komunikacji z bazą danych: " + exception.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public Form1() {
            InitializeComponent();
            Text = Application.ProductName;
            try {
                SetupDepartments();
            } catch (SqlException e) {
                ShowDatabaseErrorMessage(e);
                Environment.Exit(0);
            }
            narrowDownPanel1.ButtonNextClick += new EventHandler(identityNarrowDownPanel1_NextClick);
            narrowDownPanel1.ButtonCancelClick += new EventHandler(identityNarrowDownPanel1_CancelClick);
        }

    }

}
