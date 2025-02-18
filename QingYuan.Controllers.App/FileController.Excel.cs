using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using QingYuan.Model.Tables;

namespace QingYuan.Controllers.App
{
    public partial class FileController : QingYuanAppControllerBase
    {
        [HttpPost("excel/upload")]
        public async Task<ActionResult> Upload(IFormFile file)
        {

            if (file == null || file.Length == 0)
            {
                return BadRequest();
            }

            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            stream.Position = 0;

            XSSFWorkbook workbook = new(stream);
            var result = await ReadAsync(workbook);
            return Ok(result);
        }

        public static int? CalculateAge(DateOnly? birthDate)
        {
            if (birthDate == null)
            {
                return null;
            }
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            int age = today.Year - birthDate.Value.Year;

            // If birth date is greater than today's date then decrement age by 1
            if (birthDate.Value > today.AddYears(-age))
            {
                age--;
            }

            return age;
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

                var member = new Member
                {
                    Name = currentRow.GetCell(0)?.ToString(),
                    DepartingFlight = currentRow.GetCell(1)?.ToString(),
                    ArrivalFlight = currentRow.GetCell(2)?.ToString(),
                    Identity = currentRow.GetCell(3)?.ToString(),
                    Gender = currentRow.GetCell(4)?.ToString(),
                    Birthday = currentRow.GetCell(5)?.DateCellValue?.ToString("yyyy-MM-dd"),
                    Contact = currentRow.GetCell(7)?.ToString(),
                    Remark = currentRow.GetCell(8)?.ToString(),
                    OrderDate = DateOnly.Parse(sheet.SheetName)
                };
                if (DateTime.TryParse(member.Birthday, out DateTime birthDate))
                {
                    member.Age = CalculateAge(birthDate).ToString();
                }
                else
                {
                    member.Age = null;
                }
                // 如果身份证号为空，则表示一个组的数据读取完毕
                if (string.IsNullOrEmpty(member.Identity))
                {
                    if (currentGroup.Count > 0)
                    {
                        groups.Add(currentGroup);
                        currentGroup = [ ];
                    }
                }
                else
                {
                    currentGroup.Add(member);
                }
            }

            if (currentGroup.Count > 0)
            {
                groups.Add(currentGroup);
            }
            return groups;
        }

        private static int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now < birthDate.AddYears(age))
                age--;
            return age;
        }
    }
}
