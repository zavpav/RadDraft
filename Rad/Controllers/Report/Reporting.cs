//using DevExpress.Spreadsheet;
//using DevExpress.XtraSpreadsheet.Export;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Rad.Controllers.Report
{
    [Route("api/[controller]")]
    [ApiController]
    public class Reporting : ControllerBase
    {
        [HttpGet("Html")]
        public Task<IActionResult> GetExcelHtml()
        {
            //var workbook = new Workbook();
            //workbook.LoadDocument(@"C:\Projects\Fsf\CS\Sphaera.Bp\bin\Debug\Reports\Br2019\BudgetEstimateReportRbs.xlsx");
            //var opt = new HtmlDocumentExporterOptions();
            //var stream = new MemoryStream();
            //workbook.ExportToHtml(stream, opt);
            //stream.Position = 0;
            //var streamReader = new StreamReader(stream);
            //var content = await streamReader.ReadToEndAsync();


            //var contentResult = new ContentResult() {
            //    StatusCode = 200,
            //    ContentType = "text/html",
            //    Content = content
            //};

            //return contentResult;
            return Task.FromResult((IActionResult)Ok());
        }
    }
}
