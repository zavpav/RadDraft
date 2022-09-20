using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet.Export;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppRep
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpreadController : ControllerBase
    {
        // GET: api/<SpreadController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SpreadController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var workbook = new Workbook();
            workbook.LoadDocument(@"BudgetEstimateReportRbs.xlsx");
            var opt = new HtmlDocumentExporterOptions();
            var stream = new MemoryStream();
            workbook.ExportToHtml(stream, opt);
            stream.Position = 0;
            var streamReader = new StreamReader(stream);
            var content = streamReader.ReadToEnd();


            var contentResult = new ContentResult()
            {
                StatusCode = 200,
                ContentType = "text/html",
                Content = content
            };

            return contentResult;
        }

        // POST api/<SpreadController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SpreadController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpreadController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
