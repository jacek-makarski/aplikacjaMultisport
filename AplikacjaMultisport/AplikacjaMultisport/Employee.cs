using System.Data.SqlTypes;

namespace AppMultisport {

    public class Employee {

        public SqlInt32 EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SqlInt32 DeptID { get; set; }
        public bool Retirement { get; set; }

        public Employee(SqlInt32 employeeID, string firstName, string lastName, SqlInt32 deptID, bool retirement) {
            EmployeeID = employeeID;
            FirstName = firstName;
            LastName = lastName;
            DeptID = deptID;
            Retirement = retirement;
        }

    }

}
