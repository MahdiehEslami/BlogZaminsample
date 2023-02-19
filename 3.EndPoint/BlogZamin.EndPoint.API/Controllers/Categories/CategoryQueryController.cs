using BlogZamin.Core.Contract.Categories.Queries;
using BlogZamin.Core.Contract.Categories.Queries.GetAllCategory;
using BlogZamin.Core.Contract.Categories.Queries.GetCategoryById;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.EndPoints.Web.Controllers;

namespace BlogZamin.EndPoint.API.Controllers.Categories
{
    [Route("api/[controller]")]
    public class CategoryQueryController : BaseController
    {
        [HttpGet("GetCategoryList")]
        public async Task<IActionResult> GetCategoryList(GetAllCategoryQuery getAllCategory)
           => await Query<GetAllCategoryQuery, PagedData<CategoryQr>>(getAllCategory);

        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(GetCategoryByIdQuery query)
         => await Query<GetCategoryByIdQuery, CategoryQr>(query);

        #region CreateFileWithPDFSharp
        //[HttpGet("GeneratePdf")]
        //public async Task<IActionResult> GeneratePdf(string InvoiceNo)
        //{
          
        //    var document = new PdfDocument();
        //    GetCategoryByIdQuery query = new GetCategoryByIdQuery() { CategoryId = 2 };
        //    var header = GetCategoryById(query);

        //    string htmlcontent = "<div style='width:100%; text-align:center'>";
        //    htmlcontent += "<h2>Welcome to SupperApp Teams</h2>";

        //    if (header != null)
        //    {
        //        htmlcontent += "<h2> Invoice No:" + "FishNo" + " & Invoice Date:" + "FishDate " + "</h2>";
        //        htmlcontent += "<div>";
        //    }
        //    htmlcontent += "<table style ='width:100%; border: 1px solid #000'>";
        //    htmlcontent += "<thead style='font-weight:bold'>";
        //    htmlcontent += "<tr>";
        //    htmlcontent += "<td style='border:1px solid #000'> Product Code </td>";
        //    htmlcontent += "<td style='border:1px solid #000'> Description </td>";
        //    htmlcontent += "<td style='border:1px solid #000'>Qty</td>";
        //    htmlcontent += "<td style='border:1px solid #000'>Price</td >";
        //    htmlcontent += "<td style='border:1px solid #000'>Total</td>";
        //    htmlcontent += "</tr>";
        //    htmlcontent += "</thead >";

        //    htmlcontent += "<tbody>";
        //    for (int j = 1; j < 10; j++)
        //    {
        //        htmlcontent += "<tr>";
        //        htmlcontent += "<td style='border:1px solid #000'>" + "procuct" + j + "</td>";
        //        htmlcontent += "<td style='border:1px solid #000'>" + "ProductName" + j + "</td>";
        //        htmlcontent += "<td style='border:1px solid #000'>" + "Qty" + j + "</td >";
        //        htmlcontent += "<td style='border:1px solid #000'>" + "SalesPrice" + j + "</td>";
        //        htmlcontent += "<td style='border:1px solid #000'> " + "Total" + j + "</td >";
        //        htmlcontent += "</tr>";
        //    }
        //    //if (detail != null && detail.Count > 0)
        //    //{
        //    //    detail.ForEach(item =>
        //    //    {
        //    //        htmlcontent += "<tr>";
        //    //        htmlcontent += "<td>" + item.ProductCode + "</td>";
        //    //        htmlcontent += "<td>" + item.ProductName + "</td>";
        //    //        htmlcontent += "<td>" + item.Qty + "</td >";
        //    //        htmlcontent += "<td>" + item.SalesPrice + "</td>";
        //    //        htmlcontent += "<td> " + item.Total + "</td >";
        //    //        htmlcontent += "</tr>";
        //    //    });
        //    //}
        //    htmlcontent += "</tbody>";

        //    htmlcontent += "</table>";
        //    htmlcontent += "</div>";

        //    htmlcontent += "<div style='text-align:right'>";
        //    htmlcontent += "<h1> Summary Info </h1>";
        //    htmlcontent += "<table style='border:1px solid #000;float:right' >";
        //    htmlcontent += "<tr>";
        //    htmlcontent += "<td style='border:1px solid #000'> Summary Total </td>";
        //    htmlcontent += "<td style='border:1px solid #000'> Summary Tax </td>";
        //    htmlcontent += "<td style='border:1px solid #000'> Summary NetTotal </td>";
        //    htmlcontent += "</tr>";
        //    if (header != null)
        //    {
        //        htmlcontent += "<tr>";
        //        htmlcontent += "<td style='border: 1px solid #000'> " + "Total" + " </td>";
        //        htmlcontent += "<td style='border: 1px solid #000'>" + "Tax" + "</td>";
        //        htmlcontent += "<td style='border: 1px solid #000'> " + "NetTotal" + "</td>";
        //        htmlcontent += "</tr>";
        //    }
        //    htmlcontent += "</table>";
        //    htmlcontent += "</div>";

        //    htmlcontent += "</div>";

        //    PdfGenerator.AddPdfPages(document, htmlcontent, PdfSharp.PageSize.A5);

        //    byte[]? response = null;
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        document.Save(ms);
        //        response = ms.ToArray();
        //    }
        //    string Filename = InvoiceNo + ".pdf";
        //    return File(response, "application/pdf", Filename);
           
        //}
 #endregion

        #region StimuleModel

        [HttpGet("PrintPdf")]
        public async Task<IActionResult> PrintPdf()
        {
            var report = this.GetReport();
            return (StiNetCoreReportResponse.PrintAsPdf(report));
        }

        private StiReport GetReport()
        {
            var reportPath = StiNetCoreHelper.MapPath(this, "Reports/FactorReport.mrt");
            var report = new StiReport();
            report["name"] = "علی";
            report["family"] = "احمدیان"; 
            report["date"] = "1401-11-27";
            report["FactorNo"] = "125489";
            report["CompanyName"] = "سروش همراه";
            report.Load(reportPath);
            return report;
        }
        #endregion
    }
}
