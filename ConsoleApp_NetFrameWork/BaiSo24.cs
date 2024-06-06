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
    }
}
