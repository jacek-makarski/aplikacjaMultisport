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
        public decimal InvoiceTotal { get; private set; }
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

            decimal retiredTotal = 0;
            foreach (EmployeeWithCard currentRetiredEmployee in EmployeesReport.RetiredEmployeesWithActiveCards) {
                if (currentRetiredEmployee.Card.Type == Card.CardType.MultiActive) {
                    retiredTotal += Rules.MultiActivePrice;
                }
                if (currentRetiredEmployee.Card.Type == Card.CardType.MultiPlus) {
                    retiredTotal += Rules.MultiPlusPrice;
                }
            }
            decimal? invoiceTotalOrNull = DAO.GetInvoiceTotalOrNull(date);
            InvoiceTotalDialog dialog = new InvoiceTotalDialog();
            dialog.Summary = MultiActiveNotRetiredCount * Rules.MultiActivePrice + MultiPlusNotRetiredCount * Rules.MultiPlusPrice + retiredTotal;
            if (invoiceTotalOrNull != null) {
                dialog.InvoiceTotal = invoiceTotalOrNull.Value;
                dialog.ShowDialog();
                if (dialog.InvoiceTotal != invoiceTotalOrNull.Value) {
                    DAO.UpdateInvoiceTotal(date, dialog.InvoiceTotal);
                }
            } else {
                dialog.ShowDialog();
                DAO.AddInvoiceTotal(date, dialog.InvoiceTotal);
            }
            InvoiceTotal = dialog.InvoiceTotal;
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
