using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_NetFrameWork
{
    public class BaiSo24
    {
        public void GiaiBai24()
        {
            try
            {
                var checkInput = new BE_2505.Common.ValidateData();
                var valid = checkInput.CheckIputData("TEXT CAN KIEM TRA");


                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage())
                {
                    // khai báo wooksheet
                    var worksheet = package.Workbook.Worksheets.Add("SinhVien");
                    worksheet.Cells[1, 1].Value = "Id";
                    worksheet.Cells[1, 2].Value = "Họ tên";
                    worksheet.Cells[1, 3].Value = "Tuổi";
                    worksheet.Cells[1, 4].Value = "Điểm tổng kết HK1";
                    worksheet.Cells[1, 5].Value = "Điểm tổng kết HK2";
                    worksheet.Cells[1, 6].Value = "Hoc Luc";


                    for (int i = 2; i < 10; i++)
                    {
                        worksheet.Cells[2 + i, 1].Value = "1";
                        worksheet.Cells[2 + i, 2].Value = "Nguyễn văn a";
                        worksheet.Cells[2 + i, 3].Value = "29";
                        worksheet.Cells[2 + i, 4].Value = "10";
                        worksheet.Cells[2 + i, 5].Value = "10";
                        worksheet.Cells[2 + i, 6].Value = "GOOD";
                    }

                    // Lưu file Excel
                    var filePath = @"C:\Users\MIT\Documents\temp\SinhVien.xlsx";
                    FileInfo fi = new FileInfo(filePath);
                    package.SaveAs(fi);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public StringBuilder ReadExcelFile()
        {
            var errItem = new StringBuilder();
            string itemErr = string.Empty;
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(@"C:\Users\Admin\Desktop\NhanVien.xlsx")))
                {
                    // Get the first worksheet in the file
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    for (int row = 3; row <= worksheet.Dimension.End.Row; row++)
                    {
                        var maNhanVien = worksheet.Cells[row, 1].Value?.ToString();
                        var tenNhanVien = worksheet.Cells[row, 2].Value?.ToString();
                        var heSoNhanVien = worksheet.Cells[row, 3].Value?.ToString();

                        if (string.IsNullOrEmpty(maNhanVien) && string.IsNullOrEmpty(tenNhanVien)
                            && string.IsNullOrEmpty(heSoNhanVien))
                        {
                            continue;
                        }

                        if (string.IsNullOrEmpty(maNhanVien))
                        {
                            errItem.Append("maNhanVien Dòng số " + row + " cột số 1 bị trống");
                           // itemErr += "maNhanVien Dòng số " + row + " cột số 1 bị trống";
                            continue;
                        }

                        if (string.IsNullOrEmpty(tenNhanVien))
                        {
                            errItem.Append("tenNhanVien Dòng số " + row + " cột số 2 bị trống");
                            continue;
                        }

                        if (string.IsNullOrEmpty(heSoNhanVien))
                        {
                            errItem.Append("heSoNhanVien Dòng số " + row + " cột số 3 bị trống");
                            continue;
                        }
                    }

                    if (errItem != null)
                    {
                        Console.WriteLine("Lõi ở : {0}", errItem.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return errItem;
        }
    }
}
