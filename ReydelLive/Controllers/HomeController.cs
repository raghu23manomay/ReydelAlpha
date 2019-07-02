using ReyDel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReyDel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult MaterialGradeList()
        {
            ReydeldbContext _db = new ReydeldbContext();
            IEnumerable<MaterialGradeMaster> result = _db.MaterialGradeMasters.SqlQuery(@"exec USPGetMaterialGrade").ToList<MaterialGradeMaster>();


            return View("MaterialGradeList", result);
        }
        public ActionResult REIMasterList()
        {
            ReydeldbContext _db = new ReydeldbContext();
            IEnumerable<REIMaster> result = _db.REIMasters.SqlQuery(@"exec USPGetREIMaster").ToList<REIMaster>();


            return View("REIMasterList", result);
        }
        public ActionResult ColourMasterList()
        {
            ReydeldbContext _db = new ReydeldbContext();
            IEnumerable<ColourMaster> result = _db.ColourMasters.SqlQuery(@"exec USPGetColourMaster").ToList<ColourMaster>();
            return View("ColourMasterList", result);
        }
        public ActionResult SupportFunctionMasterList()
        {
            ReydeldbContext _db = new ReydeldbContext();
            IEnumerable<SupportFunctionMaster> result = _db.SupportFunctionMasters.SqlQuery(@"exec USPGetSupportFunctionMaster").ToList<SupportFunctionMaster>();
            return View("SupportFunctionMasterList", result);
        }
        public ActionResult ChangeTypeMasterList()
        {
            ReydeldbContext _db = new ReydeldbContext();
            IEnumerable<ChangeTypeMaster> result = _db.ChangeTypeMasters.SqlQuery(@"exec USPGetChangeTypeMaster").ToList<ChangeTypeMaster>();
            return View("ChangeTypeMasterList", result);
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {

            try
            {
                // ReydeldbContext _db = new ReydeldbContext();

                //var result = _db.LoginDetail.SqlQuery(@"exec usp_login 
                //@username,@password",
                //    new SqlParameter("@username", L.UserName),
                //    new SqlParameter("@password", L.password)).ToList<Login>();
                //Login data = new Login();
                //data = result.FirstOrDefault();
                if (UserName == "Test" && Password == "1234")
                {
                    Session["UserName"] = "Test";
                    Session["UserID"] = 1;
                    return Json(true, "Sucess");
                }
                else
                    return Json(false, "failed");

            }


            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }
        public ActionResult AddMaterialGrade()
        {
            MaterialGradeMaster data = new MaterialGradeMaster();

            return View("AddMaterialGrade", data);
        }
        [HttpPost]
        public ActionResult AddMaterialGrade(String GradeName, String GradeRate)
        {

            ReydeldbContext dbc = new ReydeldbContext();
            var res = dbc.Database.ExecuteSqlCommand(@"exec USPInsertMaterialGrade @GradeName,@GradeRate",
                new SqlParameter("@GradeName", GradeName),
                new SqlParameter("@GradeRate", GradeRate));
            return Json("data inserted");
        }
        [HttpPost]
        public ActionResult AddREIMaster(String REIName)
        {

            ReydeldbContext dbc = new ReydeldbContext();
            var res = dbc.Database.ExecuteSqlCommand(@"exec USPInsertREIMaster @REIName",
                new SqlParameter("@REIName", REIName));
            return Json("data inserted");
        }
        [HttpPost]
        public ActionResult AddColourMaster(String ColourName)
        {

            ReydeldbContext dbc = new ReydeldbContext();
            var res = dbc.Database.ExecuteSqlCommand(@"exec USPInsertColourMaster @ColourName",
                new SqlParameter("@ColourName", ColourName));
            return Json("data inserted");
        }
        [HttpPost]
        public ActionResult AddSupportFunctionMaster(String SupportFunctionName, string SupportFunctionCode)
        {

            ReydeldbContext dbc = new ReydeldbContext();
            var res = dbc.Database.ExecuteSqlCommand(@"exec USPInsertSupportFunctionMaster @SupportFunctionName,@SupportFunctionCode",
                new SqlParameter("@SupportFunctionName", SupportFunctionName),
                 new SqlParameter("@SupportFunctionCode", SupportFunctionCode));
            return Json("data inserted");
        }
        [HttpPost]
        public ActionResult AddChangeTypeMaster(String ChangeTypeName, string ChangeTypeCode)
        {
            ReydeldbContext dbc = new ReydeldbContext();
            var res = dbc.Database.ExecuteSqlCommand(@"exec USPInsertChangeTypeMaster @ChangeTypeName,@ChangeTypeCode",
                new SqlParameter("@ChangeTypeName", ChangeTypeName),
                 new SqlParameter("@ChangeTypeCode", ChangeTypeCode));
            return Json("data inserted");
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public List<SelectListItem> binddropdown(string action, int val = 0)
        {
            ReydeldbContext _db = new ReydeldbContext();

            var res = _db.Database.SqlQuery<SelectListItem>("exec USP_BindDropDown @action , @val",
                   new SqlParameter("@action", action),
                    new SqlParameter("@val", val))
                   .ToList()
                   .AsEnumerable()
                   .Select(r => new SelectListItem
                   {
                       Text = r.Text.ToString(),
                       Value = r.Value.ToString(),
                       Selected = r.Value.Equals(Convert.ToString(val))
                   }).ToList();

            return res;
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login", "Home");
        }

        //public ActionResult UpdateREIMaster(int REI_Id)
        //{
        //    ReydeldbContext _db = new ReydeldbContext();
        //    var res = _db.Database.ExecuteSqlCommand(@"exec USPUpdateREIMaster @REI_Id",
        //       new SqlParameter("@REI_Id", REI_Id));
        //    return Json("data Updated");

        public ActionResult RejectionTypeList()
        {
            ViewData["RejectionReason"] = binddropdown("RejectionReason", 0);
            ReydeldbContext _db = new ReydeldbContext();
            IEnumerable<RejectionReasonTypeMaster> result = _db.RejectionReasonTypeMasters.SqlQuery(@"exec uspGetRejectionTypeList").ToList<RejectionReasonTypeMaster>();

            return View("RejectionTypeList", result);
        }
        public ActionResult RejectionReasonList()
        {
            ReydeldbContext _db = new ReydeldbContext();
            IEnumerable<RejectionReasonMaster> result = _db.RejectionReasonMasters.SqlQuery(@"exec uspGetRejectionReasonList").ToList<RejectionReasonMaster>();

            return View("RejectionReasonList", result);
        }
        public JsonResult GetRejecteionReason()
        {
            ReydeldbContext _db = new ReydeldbContext();
            var lstItem = binddropdown("City", 0).Select(i => new { i.Value, i.Text }).ToList();
            return Json(lstItem, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddRejectionType()
        {
            RejectionReasonTypeMaster data = new RejectionReasonTypeMaster();
            data.Rejection_Reason_Id = 1;
            ViewData["RejectionReason"] = binddropdown("RejectionReason", 0);
            return View("AddRejectionType", data);
        }
        public ActionResult AddRejectionReason()
        {
            MaterialGradeMaster data = new MaterialGradeMaster();
            ViewData["RejectionReason"] = binddropdown("RejectionReason", 0);
            return View("AddRejectionReason", data);
        }
        public ActionResult ExportImportTypeList()
        {
            ReydeldbContext _db = new ReydeldbContext();
            IEnumerable<ExcelImportTypeMaster> result = _db.ExcelImportTypeMasters.SqlQuery(@"exec uspGetExportImportTypeList").ToList<ExcelImportTypeMaster>();
            return View("ExportImportTypeList", result);
        }

        public ActionResult AddExcelImportType()
        {
            return View("AddExcelImportType");
        }
        
        [HttpPost]
        public ActionResult UpdateMaterialGrade(int Material_Grade_Id, string Material_Grade_Name, float Material_Grade_Rate = 0)
        {
            ReydeldbContext _db = new ReydeldbContext();
            var res = _db.Database.ExecuteSqlCommand(@"exec USPUpdateMaterialGrade @Material_Grade_Id,@Material_Grade_Name ,@Material_Grade_Rate",
               new SqlParameter("@Material_Grade_Id", Material_Grade_Id),
               new SqlParameter("@Material_Grade_Name", Material_Grade_Name),
               new SqlParameter("@Material_Grade_Rate", Material_Grade_Rate));
            return Json("data Updated");
        }
    }
}