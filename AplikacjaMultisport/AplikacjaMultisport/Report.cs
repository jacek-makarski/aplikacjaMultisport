using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace AppMultisport {

    public class Report {

        public class DeptReport {

            public Dept Dept { get; private set; }
            public List<EmployeeWithCard> EmployeesWithActiveCards { get; private set; }

            public DeptReport(Dept dept) {
                Dept = dept;
                EmployeesWithActiveCards = new List<EmployeeWithCard>();
            }

        }

        public DateTime Date { get; private set; }
        public List<EmployeeWithCard> EmployeesWhoJoined { get; private set; }
        public List<Employee> EmployeesWhoDeactivatedCards { get; private set; }
        public List<DeptReport> DeptReports { get; private set; }
        public int MultiActiveCount { get; private set; }
        public int MultiPlusCount { get; private set; }

        public Report(DateTime date) {
            Date = date;
            EmployeesWhoJoined = DAO.GetEmployeesWhoJoined(Date);
            EmployeesWhoDeactivatedCards = DAO.GetEmployeesWhoDeactivatedCards(Date);
            DeptReports = DAO.GetDeptReports(Date);
            foreach(DeptReport currentDeptReport in DeptReports) {
                foreach(EmployeeWithCard currentEmployee in currentDeptReport.EmployeesWithActiveCards) {
                    if (currentEmployee.Card.Type == Card.CardType.MultiActive) {
                        ++MultiActiveCount;
                    }
                    if (currentEmployee.Card.Type == Card.CardType.MultiPlus) {  //Alternatywnie: else
                        ++MultiPlusCount;
                    }
                }
            }
        }

        public static DeptReport FindDeptReport(List<DeptReport> deptReportList, SqlInt32 deptID) {
            foreach (DeptReport currentDeptReport in deptReportList) {
                if (currentDeptReport.Dept.DepartmentID == deptID) {
                    return currentDeptReport;
                }
            }
            throw new KeyNotFoundException();
        }      
        
    }

}
