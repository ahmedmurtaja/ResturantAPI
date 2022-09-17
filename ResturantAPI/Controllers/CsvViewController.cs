using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.IO;
using System.Linq;
using ResturantAPI.Models;
using Spire.Xls;
using System.Drawing;

namespace ResturantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvViewController : ControllerBase
    {
        private readonly resturantdbContext _db;

        public CsvViewController(resturantdbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var viewList = _db.CsvViews.ToList();
            using (var writer = new StreamWriter("ItemsDB.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(viewList);
            }
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(@"ItemsDB.csv", ",", 1, 1);
            Worksheet sheet = workbook.Worksheets[0];
            sheet.Range["A1:F1"].Style.Color = Color.Orange;
            workbook.SaveToFile("result.xlsx", ExcelVersion.Version2013);
            return Ok();
        }
    }
}
