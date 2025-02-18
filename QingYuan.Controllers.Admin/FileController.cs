
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using QingYuan.Common;
using QingYuan.Model.Tables;


namespace QingYuan.Controllers.Admin
{
    public class FileController : QingYuanAdminControllerBase
    {
        [HttpPost("upload")]
        public async Task<ActionResult<ApiResponseResult>> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return ApiResponseResult.Fail();
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage(file.OpenReadStream());
            if (package == null)
            {
                return ApiResponseResult.Fail();
            }
            var worksheets = package.Workbook.Worksheets;
            var result = await ReadAsync(worksheets);
            return Ok(result);
        }

        private static async Task<List<List<Member>>> ReadAsync(ExcelWorksheets worksheets)
        {
            var result = await Task.WhenAll(worksheets.Select(sheet => Task.Run(() => Invoke(sheet))));
            return result.SelectMany(inner => inner).ToList();
        }


        private static List<List<Member>> Invoke(ExcelWorksheet worksheet)
        {
            int rowCount = worksheet.Dimension.Rows;
            var groups = new List<List<Member>>();
            var currentGroup = new List<Member>();
            for (int row = 2 ; row <= rowCount ; row++)
            {
                var rowData = new Member
                {
                    Name = worksheet.Cells[row, 1].Text,
                    DepartingFlight = worksheet.Cells[row, 2].Text,
                    ArrivalFlight = worksheet.Cells[row, 3].Text,
                    Identity = worksheet.Cells[row, 4].Text,
                    Gender = worksheet.Cells[row, 5].Text,
                    //Birthday = worksheet.Cells[row, 6].Text,
                    //Age = worksheet.Cells[row, 7].Text,
                    Contact = worksheet.Cells[row, 8].Text,
                    Remark = worksheet.Cells[row, 9].Text,
                    OrderDate = DateOnly.Parse(worksheet.Name)
                };

                // 如果身份证号为空，则表示一个组的数据读取完毕
                if (string.IsNullOrEmpty(rowData.Identity))
                {
                    if (currentGroup.Count > 0)
                    {
                        groups.Add(currentGroup);
                        currentGroup = [ ];
                    }
                }
                else
                {
                    currentGroup.Add(rowData);
                }
            }

            if (currentGroup.Count > 0)
            {
                groups.Add(currentGroup);
            }
            return groups;
        }
    }
}
