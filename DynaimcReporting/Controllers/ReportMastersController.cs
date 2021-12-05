using ClosedXML.Excel;
using DynaimcReporting.Context;
using DynaimcReporting.DTO;
using DynaimcReporting.Helpers;
using DynaimcReporting.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DynaimcReporting.Controllers
{
    public class ReportMastersController : Controller
    {
        private ReportContext db;
        public IConfiguration Configuration { get; }
        private readonly IHostingEnvironment _hostingEnvironment;
        //private string _fileName;
        private string _filePath;
        public ReportMastersController(ReportContext _db, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            db = _db;
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _filePath = _hostingEnvironment.WebRootPath + "\\ExcelFile";
        }
        // GET: ReportMasters
        public ActionResult Index(int id = 0)
        {
            var reportMasters = new List<ReportMaster>();
            if (id == 0)
            {
                return Redirect("\\");
            }
            else
            {
                reportMasters = db.ReportMasters.Include(r => r.Categories).Include(r => r.ReportTypes).Where(x => x.CategorieId == id).ToList();
            }

            return View(reportMasters);
        }
        public ActionResult SetParameters(int reportId)
        {
            var query = db.ReportMasters.Where(x => x.Id == reportId).FirstOrDefault();
            var oldParameters = db.ReportParameters.Where(x => x.ReportMasterId == reportId).ToList();
            List<ParametersDTO> parameters = new List<ParametersDTO>();
            foreach (var item in query.Query.Split(' '))
            {
                if (item.StartsWith("#"))
                {
                    ParametersDTO parameter = new ParametersDTO();
                    var oldParameter = oldParameters.Where(x => x.Label == item).FirstOrDefault();
                    if (oldParameter != null)
                    {
                        parameter.Label = oldParameter.Label;
                        parameter.ReportMasterId = oldParameter.ReportMasterId;
                        parameter.QueryOfMasterReport = query.Query;
                        parameter.ParameterDataType = oldParameter.ParameterDataType;
                        parameter.Query = oldParameter.Query;
                        parameter.DisplayName = oldParameter.DisplayName;
                    }
                    else
                    {
                        parameter.Label = item;
                        parameter.ReportMasterId = reportId;
                        parameter.QueryOfMasterReport = query.Query;
                    }
                    if (parameters.Where(x => x.Label == parameter.Label).Count() == 0)
                        parameters.Add(parameter);
                }
            }
            return View(parameters);
        }
        [HttpPost]
        public ActionResult SetParameters(List<ParametersDTO> listParameters)
        {
            var rptId = listParameters.FirstOrDefault().ReportMasterId;
            db.ReportParameters.RemoveRange(db.ReportParameters.Where(x => x.ReportMasterId == rptId).ToList());
            List<ReportParameter> parameters = new List<ReportParameter>();
            foreach (var item in listParameters)
            {
                var para = new ReportParameter();
                para.Label = item.Label;
                para.ParameterDataType = item.ParameterDataType;
                para.Query = item.Query;
                para.ReportMasterId = item.ReportMasterId;
                para.DisplayName = item.DisplayName;
                parameters.Add(para);
            }
            db.ReportParameters.AddRange(parameters);
            db.SaveChanges();
            return View(listParameters);
        }

        public ActionResult ViewReports(int? reportId)
        {
            var query = db.ReportMasters.Where(x => x.Id == reportId).FirstOrDefault();
            var oldParameters = db.ReportParameters.Where(x => x.ReportMasterId == reportId).ToList();
            List<ParametersDTO> parameters = new List<ParametersDTO>();
            foreach (var item in oldParameters)
            {
                ParametersDTO parameter = new ParametersDTO();
                var oldParameter = oldParameters.Where(x => x.Label == item.Label).FirstOrDefault();
                parameter.Label = oldParameter.Label;
                parameter.ReportMasterId = oldParameter.ReportMasterId;
                parameter.QueryOfMasterReport = query.Query;
                parameter.ParameterDataType = oldParameter.ParameterDataType;
                parameter.Query = oldParameter.Query;
                parameter.DisplayName = oldParameter.DisplayName;
                var con = Configuration.GetConnectionString("DefaultConnection");
                if (oldParameter.ParameterDataType == ENUM.ParameterDataType.DropDown)
                {
                    var ddl = ExecuteSQL.GetSelectList(oldParameter.Query, con);
                    parameter.DDL = ddl;
                }
                if (parameters.Where(x => x.Label == parameter.Label).Count() == 0)
                    parameters.Add(parameter);
            }
            ViewBag.Table = "";
            ViewBag.RptName = query.Name;
            return View(parameters);
        }
        //[HttpPost]
        //public ActionResult ViewReports(List<ParametersDTO> listParameters)
        //{
        //    var listOfQueryString = new List<string>();
        //    var reportMasterId = listParameters.FirstOrDefault().ReportMasterId;
        //    var rpt = db.ReportMasters.Where(x => x.Id == reportMasterId).FirstOrDefault();
        //    var databaseName = "use " + rpt.DatabaseName + "; ";
        //    var prevPreviousWord = ""; //2 step previous
        //    var previousWord = ""; //1 step previous
        //    foreach (var item in listParameters.FirstOrDefault().QueryOfMasterReport.Split(' '))
        //    {
        //        string word = item;
        //        if (item.StartsWith("#"))
        //        {
        //            var searchval = listParameters.Where(x => x.Label.ToLower().Trim() == item.ToLower().Trim()).Select(x => x.SearchValue).FirstOrDefault();
        //            if (string.IsNullOrEmpty(searchval))
        //            {
        //                word = prevPreviousWord;
        //            }
        //            else
        //            {
        //                if (previousWord.ToLower().Trim() == "like")
        //                    word = "'%" + searchval + "%'";
        //                else
        //                    word = "'" + searchval + "'";
        //            }
        //        }
        //        prevPreviousWord = previousWord;
        //        previousWord = item;
        //        listOfQueryString.Add(word);
        //    }
        //    var finalQuery = string.Join(" ", listOfQueryString);
        //    var con =   Configuration.GetConnectionString("DefaultConnection");
        //    var datatable = ExecuteSQL.GetDatatable( databaseName + finalQuery, con);
        //    string htmltable = "";
        //    if (datatable.Rows.Count > 0)
        //    {
        //        var reportType = db.ReportMasters.Where(x => x.Id == reportMasterId).Select(x => x.ReportTypes);
        //        if (reportType.FirstOrDefault().Type == "Diagram")
        //        {
        //            htmltable = "Diagram report comming soon"; //ExecuteSQL.GetDataForChart(datatable);
        //        }
        //        else
        //            htmltable = ExecuteSQL.ConvertDataTableToHTML(datatable);
        //    }
        //    ViewBag.Table = htmltable;
        //    ViewBag.RptName = rpt.Name;
        //    foreach (var item in listParameters)
        //    {
        //        if (item.ParameterDataType == ENUM.ParameterDataType.DropDown)
        //        {
        //            var ddl = ExecuteSQL.GetSelectList(item.Query, con);
        //            item.DDL = ddl;
        //        }
        //    }

        //    return View(listParameters);
        //}
        [HttpPost]
        public string ViewReports(List<ParametersDTO> listParameters, string sEcho = "", int iDisplayStart = 0, int iDisplayLength = 10, string sSearch = "")
        {
            var listOfQueryString = new List<string>();
            var reportMasterId = listParameters.FirstOrDefault().ReportMasterId;
            var rpt = db.ReportMasters.Where(x => x.Id == reportMasterId).FirstOrDefault();
            var databaseName = "use " + rpt.DatabaseName + "; ";
            var prevPreviousWord = ""; //2 step previous
            var previousWord = ""; //1 step previous
            foreach (var item in listParameters.FirstOrDefault().QueryOfMasterReport.Split(' '))
            {
                string word = item;
                if (item.StartsWith("#"))
                {
                    var searchval = listParameters.Where(x => x.Label.ToLower().Trim() == item.ToLower().Trim()).Select(x => x.SearchValue).FirstOrDefault();
                    if (string.IsNullOrEmpty(searchval))
                    {
                        word = prevPreviousWord;
                    }
                    else
                    {
                        if (previousWord.ToLower().Trim() == "like")
                            word = "'%" + searchval + "%'";
                        else
                            word = "'" + searchval + "'";
                    }
                }
                prevPreviousWord = previousWord;
                previousWord = item;
                listOfQueryString.Add(word);
            }
            var finalQuery = string.Join(" ", listOfQueryString);
            var countQuery = " select count(*) as Total from ( " + finalQuery + " )x";
            finalQuery = finalQuery + " " + "order by 1 OFFSET " + iDisplayStart + " ROWS FETCH NEXT " + iDisplayLength + " ROWS ONLY";
            var con = Configuration.GetConnectionString("DefaultConnection");
            var datatable = ExecuteSQL.GetDatatable(databaseName + finalQuery, con);
            var totaldt = ExecuteSQL.GetDatatable(databaseName + countQuery, con);
            var totalRecord = Convert.ToInt32(totaldt.Rows[0][0].ToString());
            //  var dat = datatable.FirstOrDefault().Value;
            //string htmltable = "";
            //if (datatable.Rows.Count > 0)
            //{
            //    var reportType = db.ReportMasters.Where(x => x.Id == reportMasterId).Select(x => x.ReportTypes);
            //    if (reportType.FirstOrDefault().Type == "Diagram")
            //    {
            //        htmltable = "Diagram report comming soon"; //ExecuteSQL.GetDataForChart(datatable);
            //    }
            //    else
            //        htmltable = ExecuteSQL.ConvertDataTableToHTML(datatable);
            //}
            // ViewBag.Table = htmltable;
            ViewBag.RptName = rpt.Name;
            foreach (var item in listParameters)
            {
                if (item.ParameterDataType == ENUM.ParameterDataType.DropDown)
                {
                    var ddl = ExecuteSQL.GetSelectList(item.Query, con);
                    item.DDL = ddl;
                }
            }
            string finaldata = JsonConvert.SerializeObject(datatable);
            string resultData = ExecuteSQL.DataTableToJSONWithStringBuilder(datatable);


            //return sqlData;
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("{");
            //sb.Append("\"sEcho\": ");
            //if (!string.IsNullOrEmpty(sEcho))
            //{
            //    sb.Append(sEcho);
            //}
            //else
            //{
            //    sb.Append("\"\"");
            //}
            //sb.Append(",");
            sb.Append("\"iTotalRecords\": ");
            sb.Append(totalRecord);
            sb.Append(",");
            sb.Append("\"iTotalDisplayRecords\": ");
            sb.Append(totalRecord);
            sb.Append(",");
            sb.Append("\"aaData\": ");
            sb.Append(resultData);
            sb.Append("}");
            return sb.ToString();
        }


        [HttpPost]
        public ActionResult Download(List<ParametersDTO> listParameters)
        {


            string handle = Guid.NewGuid().ToString();
            var listOfQueryString = new List<string>();
            var reportMasterId = listParameters.FirstOrDefault().ReportMasterId;
            var rpt = db.ReportMasters.Where(x => x.Id == reportMasterId).FirstOrDefault();
            var databaseName = "use " + rpt.DatabaseName + "; ";
            var prevPreviousWord = ""; //2 step previous
            var previousWord = ""; //1 step previous
            foreach (var item in listParameters.FirstOrDefault().QueryOfMasterReport.Split(' '))
            {
                string word = item;
                if (item.StartsWith("#"))
                {
                    var searchval = listParameters.Where(x => x.Label.ToLower().Trim() == item.ToLower().Trim()).Select(x => x.SearchValue).FirstOrDefault();
                    if (string.IsNullOrEmpty(searchval))
                    {
                        word = prevPreviousWord;
                    }
                    else
                    {
                        if (previousWord.ToLower().Trim() == "like")
                            word = "'%" + searchval + "%'";
                        else
                            word = "'" + searchval + "'";
                    }
                }
                prevPreviousWord = previousWord;
                previousWord = item;
                listOfQueryString.Add(word);
            }
            var finalQuery = string.Join(" ", listOfQueryString);
            var con = Configuration.GetConnectionString("DefaultConnection");
            var datatable = ExecuteSQL.GetDatatable(databaseName + finalQuery, con);
            var filename = rpt.Name + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx";
            var FilePath = string.Format("{0}\\{1}", _filePath, filename);
            using (var wb = new XLWorkbook())
            {
                datatable.TableName = "Report";
                var ws = wb.Worksheets.Add(datatable);
                using (FileStream fileStream = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
                {
                    wb.SaveAs(fileStream);
                }
            }
            return Json(new { File = filename });
        }

        [HttpGet]
        public ActionResult DownloadExcel(string file)
        {
            var FilePath = string.Format("{0}\\{1}", _filePath, file);
            byte[] fileByteArray = System.IO.File.ReadAllBytes(FilePath);
            return File(fileByteArray, "application/vnd.ms-excel", file);
        }
        //[HttpGet]
        //public virtual ActionResult DownloadExcel(string fileGuid, string fileName)
        //{
        //    if (TempData[fileGuid] != null)
        //    {
        //        byte[] data = TempData[fileGuid] as byte[];
        //        return File(data, "application/vnd.ms-excel", fileName);
        //    }
        //    else
        //    {

        //        return new EmptyResult();
        //    }
        //}
        // GET: ReportMasters/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ReportMaster reportMaster = db.ReportMasters.Find(id);
            //if (reportMaster == null)
            //{
            //    return HttpNotFound();
            //}
            return View(reportMaster);
        }

        // GET: ReportMasters/Create
        public ActionResult Create()
        {
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.ReportTypeId = new SelectList(db.ReportType, "Id", "Type");
            return View();
        }

        // POST: ReportMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReportMaster reportMaster)
        {
            if (ModelState.IsValid)
            {
                db.ReportMasters.Add(reportMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Name", reportMaster.CategorieId);
            ViewBag.ReportTypeId = new SelectList(db.ReportType, "Id", "Type", reportMaster.ReportTypeId);
            return View(reportMaster);
        }

        // GET: ReportMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ReportMaster reportMaster = db.ReportMasters.Find(id);
            //if (reportMaster == null)
            //{
            //    return HttpNotFound();
            //}
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Name", reportMaster.CategorieId);
            ViewBag.ReportTypeId = new SelectList(db.ReportType, "Id", "Type", reportMaster.ReportTypeId);
            return View(reportMaster);
        }

        // POST: ReportMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReportMaster reportMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Name", reportMaster.CategorieId);
            ViewBag.ReportTypeId = new SelectList(db.ReportType, "Id", "Type", reportMaster.ReportTypeId);
            return View(reportMaster);
        }

        // GET: ReportMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ReportMaster reportMaster = db.ReportMasters.Find(id);
            //if (reportMaster == null)
            //{
            //    return HttpNotFound();
            //}
            return View(reportMaster);
        }

        // POST: ReportMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportMaster reportMaster = db.ReportMasters.Find(id);
            db.ReportMasters.Remove(reportMaster);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
