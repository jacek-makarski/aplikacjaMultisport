using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace AppMultisport {

    public static class DAO {
       
        private static readonly String connectionString = "Server=localhost;Database=AppMultisportDB;Integrated Security=SSPI";  //Zastosowanie Windows Authentication do logowania do bazy danych

        private static readonly String sqlFirstDayOfNextMonth = "CONVERT(DATE, DATEADD(DAY, 1, EOMONTH(GETDATE())))";
        //Pierwszy dzień następnego miesiąca obliczany metodą wymagającą SQL Server 2012
        //Wersja SQL Server 2008: "CONVERT(DATE, DATEADD(MONTH, DATEDIFF(MONTH, -1, GETDATE()), 0))"

        private static Card ReadCardOrNull(SqlDataReader reader) {
            if (reader.Read()) {   
                return new Card((bool) reader["CardActivation"], (bool) reader["CardType"] ? Card.CardType.MultiPlus : Card.CardType.MultiActive);
                ///*Alternatywna wersja, szybsza, ale zakładająca poprawną kolejność kolumn:*/ return new Card(reader.GetBoolean(0), reader.GetBoolean(1) ? Card.CardType.MultiPlus : Card.CardType.MultiActive);
            } else {
                return null;
            }
        }

        private static void AddParametersFromCard(SqlParameterCollection parameters, Card sourceCard) {
            parameters.AddWithValue("@cardActivation", sourceCard.Active);
            parameters.AddWithValue("@cardType", (sourceCard.Type == Card.CardType.MultiPlus));
        }

        public static List<Dept> GetDepartments() {
            List<Dept> result = new List<Dept>();
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DepartmentID, Name FROM Departments ORDER BY Ordering", connection);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        result.Add(new Dept(reader.GetSqlInt32(0), (string) reader.GetSqlString(1)));
                    }
                }
            }
            return result;
        }

        public static List<SqlInt32> GetEmployeeIDs(string firstName, string lastName, Dept employeesDept) {
            List<SqlInt32> result = new List<SqlInt32>();
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT EmployeeID FROM Employees WHERE FirstName = @firstName AND LastName = @lastName AND DepartmentID = @deptID", connection);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@deptID", employeesDept.DepartmentID);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        result.Add(reader.GetSqlInt32(0));
                    }
                }
            }
            return result;
        }

        public static DateTime GetJoinDate(SqlInt32 employeeID) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT MIN(ValidationDate) FROM CardUpdates WHERE EmployeeID = @employeeID GROUP BY EmployeeID", connection);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                return (DateTime) command.ExecuteScalar();
            }
        }

        public static List<Employee> GetEmployeesWhoDeactivatedCards(DateTime date) {
            List<Employee> result = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT EmployeeID, FirstName, LastName, DepartmentID FROM dbo.CardDeactivationsTable(@deactivationMonth)", connection);
                command.Parameters.AddWithValue("@deactivationMonth", date);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        result.Add(new Employee(reader.GetSqlInt32(0), reader.GetString(1), reader.GetString(2), reader.GetSqlInt32(3)));
                    }
                }
            }
            return result;
        }

        public static List<EmployeeWithCard> GetEmployeesWhoJoined(DateTime date) {
            List<EmployeeWithCard> result = new List<EmployeeWithCard>();
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT EmployeeID, FirstName, LastName, DepartmentID, CardType FROM dbo.EmployeesWhoJoined(@monthOfJoining)", connection);
                command.Parameters.AddWithValue("@monthOfJoining", date);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        result.Add(
                            new EmployeeWithCard(
                                new Employee(reader.GetSqlInt32(0), reader.GetString(1), reader.GetString(2), reader.GetSqlInt32(3)),
                                new Card(true, reader.GetBoolean(4) ? Card.CardType.MultiPlus : Card.CardType.MultiActive)
                            )
                        );
                    }
                }
            }
            return result;
        }

        public static List<Report.DeptReport> GetDeptReports(DateTime date) {
            List<Report.DeptReport> result = new List<Report.DeptReport>();
            List<Dept> deptList = GetDepartments();
            foreach (Dept currentDept in deptList) {
                result.Add(new Report.DeptReport(currentDept));
            }
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DeptID, DeptName, EmployeeID, FirstName, LastName, CardType FROM dbo.CardStatusTable(@dayStatusFor) WHERE CardActivation = 1 ORDER BY DeptOrdering", connection);
                command.Parameters.AddWithValue("@dayStatusFor", date);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    Report.DeptReport currentDeptReport = null;
                    while (reader.Read()) {
                        if (currentDeptReport == null || reader.GetSqlInt32(0) != currentDeptReport.Dept.DepartmentID) {
                            currentDeptReport = Report.FindDeptReport(result, reader.GetSqlInt32(0));
                        }
                        currentDeptReport.EmployeesWithActiveCards.Add(
                            new EmployeeWithCard(
                                new Employee(reader.GetSqlInt32(2), reader.GetString(3), reader.GetString(4), currentDeptReport.Dept.DepartmentID),
                                new Card(true, reader.GetBoolean(5) ? Card.CardType.MultiPlus : Card.CardType.MultiActive)
                            )
                        );
                    }
                }
            }
            return result;
        }

        public static void UpdateFirstName(SqlInt32 employeeID, string newFirstName) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Employees SET FirstName = @newFirstName WHERE EmployeeID = @employeeID", connection);
                command.Parameters.AddWithValue("@newFirstName", newFirstName);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                command.ExecuteNonQuery();
            }
        }

        public static void UpdateLastName(SqlInt32 employeeID, string newLastName) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Employees SET LastName = @newLastName WHERE EmployeeID = @employeeID", connection);
                command.Parameters.AddWithValue("@newLastName", newLastName);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                command.ExecuteNonQuery();
            }
        }

        public static void UpdateEmployeesDepartment(SqlInt32 employeeID, Dept newDept) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Employees SET DepartmentID = @newDeptID WHERE EmployeeID = @employeeID", connection);
                command.Parameters.AddWithValue("@newDeptID", newDept.DepartmentID);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteEmployee(SqlInt32 employeeID) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Employees WHERE EmployeeID = @employeeID", connection);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                command.ExecuteNonQuery();
            }
        }

        public static void AddNewEmployee(string firstName, string lastName, Dept employeesDept, Card initialCard) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction()) {

                    //Dodanie nowego pracownika
                    SqlCommand command = new SqlCommand("INSERT INTO Employees OUTPUT INSERTED.EmployeeID VALUES (@firstName, @lastName, @deptID)", connection, transaction);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@deptID", employeesDept.DepartmentID);
                    SqlInt32 employeeID = (int) command.ExecuteScalar();  //Brak rzutowania wywołuje błąd.

                    //Dodanie początkowego stanu karty
                    command = new SqlCommand("INSERT INTO CardUpdates VALUES (" + sqlFirstDayOfNextMonth + ", @employeeID, @cardActivation, @cardType)", connection, transaction);
                    command.Parameters.AddWithValue("@employeeID", employeeID);
                    AddParametersFromCard(command.Parameters, initialCard);
                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        public static Card GetCardOrNull(DateTime date, SqlInt32 employeeID) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT CardActivation, CardType FROM dbo.CardStatus(@date, @employeeID)", connection);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    return ReadCardOrNull(reader);
                }
            }
        }

        public static Card GetPlannedCardOrNull(SqlInt32 employeeID) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT CardActivation, CardType FROM CardUpdates WHERE " +
                    "EmployeeID = @employeeID AND ValidationDate =" + sqlFirstDayOfNextMonth, connection);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    return ReadCardOrNull(reader);
                }
            }
        }

        public static void AddCardUpdate(SqlInt32 employeeID, Card card) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO CardUpdates VALUES (" + sqlFirstDayOfNextMonth + ", " +
                    "@employeeID, @cardActivation, @cardType)", connection);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                AddParametersFromCard(command.Parameters, card);
                command.ExecuteNonQuery();
            }
        }

        public static void ModifyPlannedCardUpdate(SqlInt32 employeeID, Card card) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE CardUpdates SET CardActivation = @cardActivation, CardType = @cardType WHERE " +
                    "ValidationDate = " + sqlFirstDayOfNextMonth +  " AND EmployeeID = @employeeID", connection);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                AddParametersFromCard(command.Parameters, card);
                command.ExecuteNonQuery();
            }
        }

        public static void DeletePlannedCardUpdate(SqlInt32 employeeID) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM CardUpdates WHERE " +
                    "ValidationDate = " + sqlFirstDayOfNextMonth + " AND EmployeeID = @employeeID", connection);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                command.ExecuteNonQuery();
            }
        }

        public static void ApplyDeptUpdate(DeptUpdate update) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction()) {
                    if (update.DeletedDepts.Count > 0) {
                        foreach (EditedDept deletedDept in update.DeletedDepts) {
                            SqlCommand command = new SqlCommand("DELETE FROM Departments WHERE DepartmentID = @deptID", connection, transaction);
                            command.Parameters.AddWithValue("@deptID", deletedDept.DepartmentID);
                            command.ExecuteNonQuery();
                        } 
                    }
                    foreach (EditedDept editedDept in update.EditedDepts) {
                        if (editedDept.Added) {
                            SqlCommand command = new SqlCommand("INSERT INTO Departments (Name) OUTPUT INSERTED.DepartmentID VALUES (@deptName)", connection, transaction);
                            command.Parameters.AddWithValue("@deptName", editedDept.Name);
                            editedDept.DepartmentID = (int) command.ExecuteScalar();
                        } else if (editedDept.Renamed) {
                            SqlCommand command = new SqlCommand("UPDATE Departments SET Name = @newName WHERE DepartmentID = @deptID", connection, transaction);
                            command.Parameters.AddWithValue("@newName", editedDept.Name);
                            command.Parameters.AddWithValue("@deptID", editedDept.DepartmentID);
                            command.ExecuteNonQuery();
                        }
                    }
                    if (update.Permuted) {
                        int ordering = 1;
                        foreach (EditedDept editedDept in update.EditedDepts) {
                            SqlCommand command = new SqlCommand("UPDATE Departments SET Ordering = @ordering WHERE DepartmentID = @deptID", connection, transaction);
                            command.Parameters.AddWithValue("@ordering", ordering);
                            command.Parameters.AddWithValue("@deptID", editedDept.DepartmentID);
                            command.ExecuteNonQuery();
                            ++ordering;
                        }
                    }
                    transaction.Commit();
                }
            }
        }

    }

}
