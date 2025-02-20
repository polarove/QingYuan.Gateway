using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using QingYuan.Common;
using QingYuan.Model.Tables;

namespace QingYuan.Controllers.App
{
    public partial class FileController : QingYuanAppControllerBase
    {
        [HttpPost("excel/read")]
        public async Task<ActionResult<ApiResponseResult>> Read(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("无效文件");
            }
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            stream.Position = 0;

            XSSFWorkbook workbook = new(stream);
            var result = await ReadAsync(workbook);
            return ApiResponseResult.Success(result);
        }

        private static async Task<List<List<Member>>> ReadAsync(XSSFWorkbook workbook)
        {
            var result = await Task.WhenAll(Enumerable.Range(0, workbook.NumberOfSheets)
                .Select(sheetIndex => Task.Run(() => Invoke(workbook.GetSheetAt(sheetIndex)))));
            return result.SelectMany(inner => inner).ToList();
        }

        private static List<List<Member>> Invoke(ISheet sheet)
        {
            int rowCount = sheet.LastRowNum;
            var groups = new List<List<Member>>();
            var currentGroup = new List<Member>();

            for (int row = 1 ; row <= rowCount ; row++)
            {
                IRow currentRow = sheet.GetRow(row);
                if (currentRow == null)
                    continue;

                var rowData = new Member(sheet.SheetName)
                {
                    Name = currentRow.GetCell(0)?.ToString(),
                    DepartingFlight = currentRow.GetCell(1)?.ToString(),
                    ArrivalFlight = currentRow.GetCell(2)?.ToString(),
                    Identity = currentRow.GetCell(3)?.ToString(),
                    Gender = currentRow.GetCell(4)?.ToString(),
                    Birthday = currentRow.GetCell(5)?.DateCellValue?.ToString("yyyy-MM-dd"),
                    Contact = currentRow.GetCell(7)?.ToString(),
                    Remark = currentRow.GetCell(8)?.ToString(),
                };

                if (rowData.AreAllPropertiesNull())
                {
                    if (currentGroup.Count > 0)
                    {
                        groups.Add(currentGroup);
                        currentGroup = [ ];
                    }
                }
                else
                {
                    rowData.SetData();
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
