using System.Collections.Generic;
using System.Windows.Forms;

namespace AppMultisport {
    public partial class ExtendedCardStatusTable : UserControl {

        private enum CardState {

        }

        public class TableRow {
            public Employee Employee { get; set; }
            public Dept Dept { get; set; }
            public Card CurrentCard { get; set; }
            public Card PlannedCard { get; set; }

            public TableRow(Employee employee, Dept dept, Card currentCard, Card plannedCard) {
                Employee = employee;
                Dept = dept;
                CurrentCard = currentCard;
                PlannedCard = plannedCard;
            }
        }

        private List<TableRow> rows = new List<TableRow>();

        public void RefreshTable() {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            rows = DAO.GetExtendedCardStatusTable();
            foreach (TableRow row in rows) {
                string currentCardString;
                string plannedCardString;
                string deptString;

                if (row.CurrentCard == null) {
                    currentCardString = "brak karty";
                } else {
                    if (!row.CurrentCard.Active) {
                        currentCardString = "nieaktywna";
                    } else {
                        currentCardString = (row.CurrentCard.Type == Card.CardType.MultiActive) ? Rules.MultiActiveName : Rules.MultiPlusName;
                    }
                }

                if (row.PlannedCard == null) {
                    plannedCardString = "bez zmian";
                } else {
                    if (!row.PlannedCard.Active) {
                        plannedCardString = "dezaktywacja";
                    } else {
                        plannedCardString = (row.PlannedCard.Type == Card.CardType.MultiActive) ? Rules.MultiActiveName : Rules.MultiPlusName;
                    }
                }

                if (row.Dept == null) {
                    deptString = "brak";
                } else {
                    deptString = row.Dept.ToString();
                }

                dataGridView1.Rows.Add(
                    new object[] {
                        row.Employee.EmployeeID.ToString(),
                        row.Employee.LastName,
                        row.Employee.FirstName,
                        deptString,
                        row.Employee.Retirement,
                        currentCardString,
                        plannedCardString
                    }
                );
            }
        }

        public ExtendedCardStatusTable() {
            InitializeComponent();
        }

    }
}
