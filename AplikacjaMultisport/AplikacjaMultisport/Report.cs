using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace AppMultisport {

    public class Report {

        public class DeptReport {  //Raport działu - lista pracowników z aktywnymi kartami dla działu

            public Dept Dept { get; private set; }
            public List<EmployeeWithCard> EmployeesWithActiveCards { get; private set; }

            public DeptReport(Dept dept) {
                Dept = dept;
                EmployeesWithActiveCards = new List<EmployeeWithCard>();
            }

        }

        public class FullEmployeesReport {  //Pełen raport pracowników - raporty działów oraz lista pracowników emerytowanych posiadająych aktywne karty

            public List<DeptReport> DeptReports { get; private set; } = new List<DeptReport>();
            public List<EmployeeWithCard> RetiredEmployeesWithActiveCards { get; private set; } = new List<EmployeeWithCard>();
            
        }

        public DateTime Date { get; private set; }
        public List<EmployeeWithCard> EmployeesWhoJoined { get; private set; }
        public List<Employee> EmployeesWhoDeactivatedCards { get; private set; }
        public FullEmployeesReport EmployeesReport { get; private set; }
        public int MultiActiveNotRetiredCount { get; private set; }
        public int MultiPlusNotRetiredCount { get; private set; }

        public Report(DateTime date) {
            Date = date;
            EmployeesWhoJoined = DAO.GetEmployeesWhoJoined(Date);
            EmployeesWhoDeactivatedCards = DAO.GetEmployeesWhoDeactivatedCards(Date);
            EmployeesReport = DAO.GetFullEmployeesReport(Date);
            foreach (DeptReport currentDeptReport in EmployeesReport.DeptReports) {
                foreach (EmployeeWithCard currentEmployee in currentDeptReport.EmployeesWithActiveCards) {
                    if (currentEmployee.Card.Type == Card.CardType.MultiActive) {
                        ++MultiActiveNotRetiredCount;
                    }
                    if (currentEmployee.Card.Type == Card.CardType.MultiPlus) {  //Alternatywnie: else
                        ++MultiPlusNotRetiredCount;
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
