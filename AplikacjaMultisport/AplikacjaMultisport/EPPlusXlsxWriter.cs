using System;

using System.IO;
using OfficeOpenXml;
using System.Globalization; 

namespace AppMultisport {

    public class EPPlusXlsxWriter {

        private readonly string currencyFormat = "#,##0.00\\ \"zł\"";

        private static string EmployeeStr(int count) {
            if (count == 1) {
                return "pracownik";
            } else {
                return "pracowników";
            }
        }

        private static string JoinedStr(int count) {
            if (count == 1) {
                return "dołączył";
            } else {
                return "dołączyło";
            }
        }

        private static string ResignationStr(int count) {
            if (count == 1) {
                return "rezygnacja";
            } else {
                int remainder = count % 10;
                if ((remainder == 2 || remainder == 3 || remainder == 4) && (count / 10 != 1)) {
                    return "rezygnacje";
                } else {
                    return "rezygnacji";
                }
            }
        }

        public void CreateOrOverwriteFile(string fileName, Report report) {
            FileInfo file = new FileInfo(fileName);
            if (file.Exists) {
                file.Delete();
            }
            using (ExcelPackage package = new ExcelPackage(file)) {

                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Arkusz1");

                worksheet.Cells.Style.Font.Size = 12;

                //Szerokości kolumn jak w dokumencie-wzorze
                worksheet.Column(1).Width = 10.76171875;
                worksheet.Column(2).Width = 21.38671875;
                worksheet.Column(3).Width = 15.46875;
                worksheet.Column(4).Width = 20.84765625;
                worksheet.Column(5).Width = 21.65625;

                //1. Opis dokumentu ----------
                worksheet.Row(1).Height = 42;
                worksheet.Row(1).Style.Font.Size = 14;
                worksheet.Row(1).Style.WrapText = true;
                worksheet.Row(1).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Bottom;
                worksheet.Cells["A1:E1"].Merge = true;
                worksheet.Cells["A1:E1"].Value = "Wykaz pracowników, którzy przystąpili do programu motywacyjnego realizowanego przez firmę " + Rules.MotivationProgramCompanyName + ".";

                //2. Tytuł dokumentu ----------
                worksheet.Row(2).Height = 49.5;
                worksheet.Row(2).Style.Font.Name = "Arial";
                worksheet.Row(2).Style.Font.Size = 16;
                worksheet.Row(2).Style.WrapText = true;
                worksheet.Row(2).Style.Font.Bold = true;
                worksheet.Row(2).Style.Font.Italic = true;
                worksheet.Row(2).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Row(2).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                worksheet.Cells["A2:E2"].Merge = true;
                worksheet.Cells["A2:E2"].Value = "WYKAZ POTRĄCEŃ Z POBORÓW ZA KARTY motywacyjne"
                    + Environment.NewLine
                    + CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[report.Date.Month - 1]
                    + " "
                    + report.Date.Year
                    + "/ Płace";

                //3. Wykaz zmian ----------
                worksheet.Row(3).Height = 38.25;
                worksheet.Row(3).Style.Font.Size = 14;
                worksheet.Cells["A3:E3"].Merge = true;
                worksheet.Cells["A3:E3"].IsRichText = true;
                worksheet.Cells["A3:E3"].RichText.Add("Z dniem ");
                OfficeOpenXml.Style.ExcelRichText richText = worksheet.Cells["A3:E3"].RichText.Add("1 "
                    + CultureInfo.CurrentCulture.DateTimeFormat.MonthGenitiveNames[report.Date.Month - 1]
                    + " " + report.Date.Year + " r."
                );
                richText.Bold = true;
                richText.UnderLine = true;
                richText = worksheet.Cells["A3:E3"].RichText.Add(" zmiany w programie BM:");
                richText.Bold = false;
                richText.UnderLine = false;

                int rowCaret = 4;

                if (report.EmployeesWhoJoined.Count == 0 && report.EmployeesWhoDeactivatedCards.Count == 0) {
                    worksheet.Row(rowCaret).Height = 18.75;
                    worksheet.Row(rowCaret).Style.Font.Size = 14;
                    worksheet.Cells["A4"].Value = "brak";
                    ++rowCaret;
                    worksheet.Row(rowCaret).Height = 18.75;
                    worksheet.Row(rowCaret).Style.Font.Size = 14;
                    ++rowCaret;
                } else {
                    if (report.EmployeesWhoJoined.Count > 0) {
                        worksheet.Row(rowCaret).Height = 18.75;
                        worksheet.Row(rowCaret).Style.Font.Size = 14;
                        worksheet.Cells[rowCaret, 1].Value = report.EmployeesWhoJoined.Count + " "
                            + EmployeeStr(report.EmployeesWhoJoined.Count) + " "
                            + JoinedStr(report.EmployeesWhoJoined.Count) + " "
                            + "do programu:";
                        ++rowCaret;
                        foreach (EmployeeWithCard currentWhoJoined in report.EmployeesWhoJoined) {
                            worksheet.Row(rowCaret).Height = 18.75;
                            worksheet.Row(rowCaret).Style.Font.Size = 14;
                            worksheet.Cells[rowCaret, 1].Value = currentWhoJoined.Employee.LastName 
                                + " "  + currentWhoJoined.Employee.FirstName 
                                + " (opcja " + Rules.CardPrice(currentWhoJoined.Card) + " zł)";
                            ++rowCaret;
                        }
                        worksheet.Row(rowCaret).Height = 18.75;
                        worksheet.Row(rowCaret).Style.Font.Size = 14;
                        ++rowCaret;
                    }
                    if (report.EmployeesWhoDeactivatedCards.Count > 0) {
                        worksheet.Row(rowCaret).Height = 18.75;
                        worksheet.Row(rowCaret).Style.Font.Size = 14;
                        worksheet.Cells[rowCaret, 1].Value = report.EmployeesWhoDeactivatedCards.Count + " "
                            + ResignationStr(report.EmployeesWhoDeactivatedCards.Count) + ":";
                        ++rowCaret;
                        foreach (Employee currentWhoDeactivated in report.EmployeesWhoDeactivatedCards) {
                            worksheet.Row(rowCaret).Height = 18.75;
                            worksheet.Row(rowCaret).Style.Font.Size = 14;
                            worksheet.Cells[rowCaret, 1].Value = currentWhoDeactivated.LastName + " " + currentWhoDeactivated.FirstName;
                            ++rowCaret;
                        }
                        worksheet.Row(rowCaret).Height = 18.75;
                        worksheet.Row(rowCaret).Style.Font.Size = 14;
                        ++rowCaret;
                    }
                }

                //4. Tabela pracowników wg. działu ----------
                worksheet.Row(rowCaret).Height = 95; //74.25;
                worksheet.Row(rowCaret).Style.Font.Size = 12;
                worksheet.Row(rowCaret).Style.Font.Bold = true;
                worksheet.Row(rowCaret).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Row(rowCaret).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                worksheet.Row(rowCaret).Style.WrapText = true;
                worksheet.Cells[rowCaret, 1, rowCaret, 5].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells[rowCaret, 1, rowCaret, 5].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells[rowCaret, 1, rowCaret, 5].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells[rowCaret, 1, rowCaret, 5].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells[rowCaret, 1].Value = "Lp.";
                worksheet.Cells[rowCaret, 2].Value = "Nazwisko";
                worksheet.Cells[rowCaret, 3].Value = "Pierwsze imię";
                worksheet.Cells[rowCaret, 4].Value = "Część programu dla pracownika w wysokości " + Rules.MultiActivePrice + " zł, stanowiąca przychód pracownika";
                worksheet.Cells[rowCaret, 5].Value = "Pakiet rodzinny/dodatkowy w wys. ...... zł, " + Environment.NewLine + "w całości opłacany przez pracownika";
                ++rowCaret;

                int employeeCounter = 1;

                for(int i = 0; i < report.DeptReports.Count; ++i) {
                    
                    //Nagłówek działu
                    Report.DeptReport currentDeptReport = report.DeptReports[i];
                    int deptStartRow = rowCaret;
                    worksheet.Row(rowCaret).Height = 25.5;
                    worksheet.Cells[rowCaret, 2].Style.Font.Bold = true;
                    worksheet.Cells[rowCaret, 2].Value = RomanNumerals.Numeral(i + 1) + ". " + currentDeptReport.Dept.Name;
                    ++rowCaret;

                    //Pracownicy działu
                    foreach(EmployeeWithCard currentEmployee in currentDeptReport.EmployeesWithActiveCards) {
                        worksheet.Cells[rowCaret, 1].Value = employeeCounter;
                        worksheet.Cells[rowCaret, 2].Value = currentEmployee.Employee.LastName;
                        worksheet.Cells[rowCaret, 3].Value = currentEmployee.Employee.FirstName;
                        worksheet.Cells[rowCaret, 4].Value = Rules.CardPrice(currentEmployee.Card);
                        ++employeeCounter;
                        ++rowCaret;
                    }

                    //Podsumowanie działu
                    worksheet.Cells[rowCaret, 1].Value = "Podsumowanie Działu";
                    worksheet.Cells[rowCaret, 3].Value = currentDeptReport.EmployeesWithActiveCards.Count + " os.";
                    worksheet.Cells[rowCaret, 4].Style.Font.Bold = true;
                    if (currentDeptReport.EmployeesWithActiveCards.Count > 0) {
                        worksheet.Cells[rowCaret, 4].Formula = "SUM(D" + (deptStartRow + 1) + ":D" + (rowCaret - 1) + ")";
                    } else {
                        worksheet.Cells[rowCaret, 4].Value = 0;
                    }
                    
                    //Styl podtabeli obejmującej dział
                    using (ExcelRange deptRange = worksheet.Cells[deptStartRow, 1, rowCaret, 5]) {
                        deptRange.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        deptRange.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        deptRange.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        deptRange.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    }

                    rowCaret += 2;
                }
                ++rowCaret;

                //5. Podsumowanie wszystkich działów ----------
                worksheet.Cells[rowCaret, 1].Value = Rules.MultiActivePrice + " zł (" + Rules.MultiActiveName + ")";
                worksheet.Cells[rowCaret, 3].Value = report.MultiActiveCount + " x " + Rules.MultiActivePrice;
                worksheet.Cells[rowCaret, 4].Style.Numberformat.Format = currencyFormat;
                worksheet.Cells[rowCaret, 4].Value = Rules.MultiActivePrice * report.MultiActiveCount;
                ++rowCaret;

                worksheet.Cells[rowCaret, 1].Value = Rules.MultiPlusPrice + " zł (" + Rules.MultiPlusName + ")";
                worksheet.Cells[rowCaret, 3].Value = report.MultiPlusCount + " x " + Rules.MultiPlusPrice;
                worksheet.Cells[rowCaret, 4].Style.Numberformat.Format = currencyFormat;
                worksheet.Cells[rowCaret, 4].Value = Rules.MultiPlusPrice * report.MultiPlusCount;
                ++rowCaret;

                worksheet.Cells[rowCaret, 1].Value = "razem";
                worksheet.Cells[rowCaret, 4].Style.Numberformat.Format = currencyFormat;
                worksheet.Cells[rowCaret, 4].Formula = "SUM(D" + (rowCaret - 2) + ":D" + (rowCaret - 1) + ")";
                ++rowCaret;
                
                //6. Podsumowanie dokumentu ----------
                rowCaret += 2;
                worksheet.Cells[rowCaret, 1, rowCaret + 2, 4].Style.Font.Bold = true;
                worksheet.Cells[rowCaret, 4, rowCaret + 2, 4].Style.Numberformat.Format = currencyFormat;
                worksheet.Cells[rowCaret, 1].Value = "Podsumowanie ogółem:";
                /*worksheet.Cells[rowCaret, 4].Value = */
                ++rowCaret;
                worksheet.Cells[rowCaret, 1].Value = "ZFŚS";
                worksheet.Cells[rowCaret, 4].Formula = "D" + (rowCaret + 1) + "-D" + (rowCaret - 1);
                ++rowCaret;
                worksheet.Cells[rowCaret, 1].Value = "Kwota faktury:";

                rowCaret += 2;

                //7. Stopka ----------
                worksheet.Cells[rowCaret, 1].Value = "Opracował:";
                ++rowCaret;
                worksheet.Cells[rowCaret, 1].Value = "Dział:";
                worksheet.Cells[rowCaret, 2].Value = "Informatyki";
                ++rowCaret;
                worksheet.Cells[rowCaret, 1].Value = "Sporządzono dnia: " + DateTime.Today.ToString("dd.MM.yyyy");

                //Ustawienia drukowania
                worksheet.Column(5).PageBreak = true;
                worksheet.PrinterSettings.Scale = 97;
                worksheet.PrinterSettings.PaperSize = ePaperSize.A4;
                worksheet.View.PageBreakView = true;

                //Zapis
                package.Save();
            }
        }

    }

}

