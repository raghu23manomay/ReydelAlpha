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
        public ActionResult ProductionEntryList()
        {
            ReydeldbContext _db = new ReydeldbContext();
            IEnumerable<Production_Entry> result = _db.ProductionEntry.SqlQuery(@"exec USPGetProduction_Entry").ToList<Production_Entry>();


            return View("ProductionEntryList", result);
        }
        public ActionResult DownTimeEntryList()
        {
            ReydeldbContext _db = new ReydeldbContext();
            IEnumerable<DownTime_Entry> result = _db.DownTime_Entry.SqlQuery(@"exec USPGetDownTimeEntry").ToList<DownTime_Entry>();


            return View("DownTimeEntryList", result);
        }
        public ActionResult RejectionEntryDetailsList()
        {
            ReydeldbContext _db = new ReydeldbContext();
            IEnumerable<RejectionEntryDetails> result = _db.RejectionEntryDetails.SqlQuery(@"exec USPGetRejectionEntryDetails").ToList<RejectionEntryDetails>();


            return View("RejectionEntryDetailsList", result);
        }
        public ActionResult ChangeOver_EntryList()
        {
            ReydeldbContext _db = new ReydeldbContext();
            IEnumerable<ChangeOver_Entry> result = _db.ChangeOver_Entry.SqlQuery(@"exec USPGetChangeOver_Entry").ToList<ChangeOver_Entry>();


            return View("ChangeOver_EntryList", result);
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
        public ActionResult AddChangeTypeConfiguration(ChangeTypeConfiguration CTC)
        {

            ReydeldbContext dbc = new ReydeldbContext();
            var res = dbc.Database.ExecuteSqlCommand(@"exec USPInsertChangeTypeConfiguration  @Machine_Id, @Machine_operation, @Change_Over_Target_Time, @Expected_Lumps, @STD_Material_loading_OST, @STD_Change_over_OST, @STD_Material_change_over, @STD_ASSY_OST, @STD_Inspection_OST, @STD_material_movement, @System_regrind_management, @OST_For_daily_monitoring",
                 new SqlParameter("@Machine_Id", CTC.Machine_Id),
                 new SqlParameter("@Machine_operation", CTC.Machine_operation),
                 new SqlParameter("@Change_Over_Target_Time", CTC.Change_Over_Target_Time),
                 new SqlParameter("@Expected_Lumps", CTC.Expected_Lumps),
                 new SqlParameter("@STD_Material_loading_OST", CTC.STD_Material_loading_OST),
                 new SqlParameter("@STD_Change_over_OST", CTC.STD_Change_over_OST),
                 new SqlParameter("@STD_Material_change_over", CTC.STD_Material_change_over),
                 new SqlParameter("@STD_ASSY_OST", CTC.STD_ASSY_OST),
                 new SqlParameter("@STD_Inspection_OST", CTC.STD_Inspection_OST),
                 new SqlParameter("@STD_material_movement",CTC.STD_Material_Movement),
                 new SqlParameter("@System_regrind_management", CTC.System_Regrind_Management),
                 new SqlParameter("@OST_For_daily_monitoring", CTC.OST_For_daily_Monitoring));

            return Json("data inserted");
        }
        [HttpPost]
        public ActionResult AddChangeOver_Entry(ChangeOver_Entry COE)
        {

            ReydeldbContext dbc = new ReydeldbContext();
            var res = dbc.Database.ExecuteSqlCommand(@"exec USPInsertChangeOver_Entry  @Entry_Date,@Calendar_id,@Emp_Id,@ChangeOver_Config_Type,@Change_From_REI_ID,@Change_From_Part_Id,@Change_From_Mat_Grade_Id,@Change_To_REI_ID,@Change_To_Part_Id,@Change_To_Mat_Grade_Id,@StandardRunQty,@Actual_RunQty,@Increase_in_Scrap_Percent,@Increase_in_scrap_Value,@ChangeOver_Start,@ChangeOver_End,@TotalChangeOver,@Std_ChangeOverTime,@Difference,@LossInPrecentage,@Expected_Lumps,@Actual_Lumps,@Difference_Lumps,@ScrapPercentIncrease",
                 new SqlParameter("@Entry_Date", COE.Entry_Date),
                 new SqlParameter("@Calendar_id", COE.Calendar_id),
                 new SqlParameter("@Emp_Id", COE.Emp_Id),
                 new SqlParameter("@ChangeOver_Config_Type", COE.ChangeOver_Config_Type),
                 new SqlParameter("@Change_From_REI_ID", COE.Change_From_REI_ID),
                 new SqlParameter("@Change_From_Part_Id", COE.Change_From_Part_Id),
                 new SqlParameter("@Change_From_Mat_Grade_Id", COE.Change_From_Mat_Grade_Id),
                 new SqlParameter("@Change_To_REI_ID", COE.Change_To_REI_ID),
                  new SqlParameter("@Change_To_Part_Id", COE.Change_To_Part_Id),
                 new SqlParameter("@Change_To_Mat_Grade_Id", COE.Change_To_Mat_Grade_Id),
                 new SqlParameter("@StandardRunQty", COE.StandardRunQty),
                  new SqlParameter("@Actual_RunQty", COE.Actual_RunQty),
                 new SqlParameter("@Increase_in_Scrap_Percent", COE.Increase_in_Scrap_Percent),
                 new SqlParameter("@Increase_in_scrap_Value", COE.Increase_in_scrap_Value),
                 new SqlParameter("@ChangeOver_Start", COE.ChangeOver_Start),
                 new SqlParameter("@ChangeOver_End", COE.ChangeOver_End),
                 new SqlParameter("@TotalChangeOver", COE.TotalChangeOver),
                 new SqlParameter("@Std_ChangeOverTime", COE.Std_ChangeOverTime),
                   new SqlParameter("@Difference", COE.Difference),
                 new SqlParameter("@LossInPrecentage", COE.LossInPrecentage),
                 new SqlParameter("@Expected_Lumps", COE.Expected_Lumps),
                   new SqlParameter("@Actual_Lumps", COE.Actual_Lumps),
                 new SqlParameter("@Difference_Lumps", COE.Difference_Lumps),
                 new SqlParameter("@ScrapPercentIncrease", COE.ScrapPercentIncrease));

            return Json("data inserted");
        }
        [HttpPost]
        public ActionResult AddProductionEntry(Production_Entry PE)
        {

            ReydeldbContext dbc = new ReydeldbContext();
            var res = dbc.Database.ExecuteSqlCommand(@"exec USPInsertProductionEntry  @Entry_Date,@Calender_Id,@Emp_Id,@Shift_Id,@Machine_Id,@REI_Id,@Part_Id,@Plan_Qty,@Cumm_Accepted_Qty,@Accepted_Qty,@Operator_Emp_Id,@Shift_superviser",
                 new SqlParameter("@Entry_Date", PE.Entry_Date),
                 new SqlParameter("@Calender_Id", PE.Calendar_id),
                 new SqlParameter("@Emp_Id", PE.Emp_name),
                 new SqlParameter("@Shift_Id", PE.Shift),
                 new SqlParameter("@Machine_Id", PE.Machine),
                 new SqlParameter("@REI_Id", PE.REI),
                 new SqlParameter("@Part_Id", PE.Part),
                 new SqlParameter("@Plan_Qty", PE.Plan_Qty),
                 new SqlParameter("@Cumm_Accepted_Qty", PE.Cumm_Accepted_Qty),
                 new SqlParameter("@Accepted_Qty", PE.Accepted_Qty),
                 new SqlParameter("@Operator_Emp_Id", PE.Operator_Emp),
                 new SqlParameter("@Shift_superviser", PE.Shift_superviser));

            return Json("data inserted");
        }
        [HttpPost]
        public ActionResult AddRejectionEntryDetails(RejectionEntryDetails RED)
        {

            ReydeldbContext dbc = new ReydeldbContext();
            var res = dbc.Database.ExecuteSqlCommand(@"exec USPInsertRejection_Entry_Details  @Rejection_from,@Prod_Entry_Id,@Rejection_Type_Id,@Rejection_Reason_Id,@Rejection_Qty,@Lumps",
                 new SqlParameter("@Rejection_from", RED.Rejection_from),
                 new SqlParameter("@Prod_Entry_Id", RED.Prod_Entry_Id),
                 new SqlParameter("@Rejection_Type_Id", RED.Rejection_Type_Id),
                 new SqlParameter("@Rejection_Reason_Id", RED.Rejection_Reason_Id),
                 new SqlParameter("@Rejection_Qty", RED.Rejection_Qty),
                 new SqlParameter("@Lumps", RED.lumps));
               

            return Json("data inserted");
        }
        [HttpPost]
        public ActionResult AddDownTime_Entry(DownTime_Entry DE)
        {

            ReydeldbContext dbc = new ReydeldbContext();
            var res = dbc.Database.ExecuteSqlCommand(@"exec USPInsertDownTime_Entry  @Entry_Date, @Calender_Id, @Emp_Id, @IsPlanned, @Planned_from, @Planned_to , @Total_Planned, @Downtime_description, @Supoort_Function_Id,@Downtime_SlipSerialNo, @Downtime_From, @Downtime_to, @Total_Downtime",
                 new SqlParameter("@Entry_Date", DE.Entry_Date),
                 new SqlParameter("@Calender_Id", DE.Calendar_id),
                 new SqlParameter("@Emp_Id", DE.Emp_Id),
                 new SqlParameter("@IsPlanned", DE.IsPlanned),
                 new SqlParameter("@Planned_from", DE.Planned_from),
                 new SqlParameter("@Planned_to", DE.Planned_to),
                 new SqlParameter("@Total_Planned", DE.Total_Planned),
                 new SqlParameter("@Downtime_description", DE.Downtime_description),
                 new SqlParameter("@Supoort_Function_Id", DE.Supoort_Function_Id),
                 new SqlParameter("@Downtime_SlipSerialNo", DE.Downtime_SlipSerialNo),
                 new SqlParameter("@Downtime_From", DE.Downtime_From),
                 new SqlParameter("@Downtime_to", DE.Downtime_to),
                 new SqlParameter("@Total_Downtime", DE.Total_Downtime));

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

        public ActionResult ChangeTypeConfigurationList()
        {
            ReydeldbContext _db = new ReydeldbContext();
            IEnumerable<ChangeTypeConfiguration> result = _db.ChangeTypeConfigurations.SqlQuery(@"exec USPGetChangeTypeConfiguration").ToList<ChangeTypeConfiguration>();
            return View("ChangeTypeConfigurationList", result);
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
        //public ActionResult AddEmployee()
        //{
        //    Employee data = new Employee();
        //    data.EmployeeID = 2;
        //    ViewData["NameEmployee"] = binddropdown("NameEmployee", 0);

        //    return View("NameEmployee", data);
        //}
        //public List<SelectListItem> EmpNamebinddropdown(string action, int val = 0)
        //{
        //    ReydeldbContext _db = new ReydeldbContext();

        //    var res = _db.Database.SqlQuery<SelectListItem>("exec USP_EmpNamebinddropdown @action , @val",
        //           new SqlParameter("@action", action),
        //            new SqlParameter("@val", val))
        //           .ToList()
        //           .AsEnumerable()
        //           .Select(r => new SelectListItem
        //           {
        //               Text = r.Text.ToString(),
        //               Value = r.Value.ToString(),
        //               Selected = r.Value.Equals(Convert.ToString(val))
        //           }).ToList();

        //    return res;
        //}
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login", "Home");
        }

       
        
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
        [HttpPost]
        public ActionResult AddRejectionType(int Rejection_Reason_Id ,string RejectionTypeName)
    {
            ReydeldbContext dbc = new ReydeldbContext();
            var res = dbc.Database.ExecuteSqlCommand(@"exec USPInsertRejectionTypeMaster @Rejection_Reason_Id,@RejectionTypeName",
                  new SqlParameter("@Rejection_Reason_Id", Rejection_Reason_Id),
                new SqlParameter("@RejectionTypeName", RejectionTypeName));

            return Json("data inserted");
           
        }
        public ActionResult AddRejectionType()
        {
            RejectionReasonTypeMaster data = new RejectionReasonTypeMaster();
            data.Rejection_Reason_Id = 2;
            ViewData["RejectionReason"] = binddropdown("RejectionReason", 0);

            return View("AddRejectionType", data);
        }
        public ActionResult AddRejectionReason()
    {
        MaterialGradeMaster data = new MaterialGradeMaster();
        ViewData["RejectionReason"] = binddropdown("RejectionReason", 0);
        return View("AddRejectionReason", data);
    }
        public ActionResult AddRejectionReasonMaster(string RejectionReasonName)
        {
            ReydeldbContext dbc = new ReydeldbContext();
            var res = dbc.Database.ExecuteSqlCommand(@"exec USPInsertRejectionReasonMaster @RejectionReasonName",
                new SqlParameter("@RejectionReasonName", RejectionReasonName));
            return Json("data inserted");
        }
        public ActionResult ExportImportTypeList()
    {
        ReydeldbContext _db = new ReydeldbContext();
        IEnumerable<ExcelImportTypeMaster> result = _db.ExcelImportTypeMasters.SqlQuery(@"exec uspGetExportImportTypeList").ToList<ExcelImportTypeMaster>();
        return View("ExportImportTypeList", result);
    }

        public ActionResult AddExcelImportType(string ImportTypeName,string ImportTypeModes)
    {
            ReydeldbContext dbc = new ReydeldbContext();
            var res = dbc.Database.ExecuteSqlCommand(@"exec USPInsertExcelImportsTypes @ImportTypeName,@ImportTypeModes",
                new SqlParameter("@ImportTypeName", ImportTypeName),
                new SqlParameter("@ImportTypeModes", ImportTypeModes));
            return Json("data inserted");
           // return View("AddExcelImportType");
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
        [HttpPost]
        public ActionResult UpdateREIMaster(int REI_Id, string REI_Name)
        {
            ReydeldbContext _db = new ReydeldbContext();
            var res = _db.Database.ExecuteSqlCommand(@"exec USPUpdateREIMaster @REI_Id,@REI_Name",
            new SqlParameter("@REI_Id", REI_Id),
            new SqlParameter("@REI_Name", REI_Name));
            return Json("data Updated"); 
        }
        [HttpPost]
        public ActionResult UpdateColourMaster(int Colour_Id, string Colour_Name)
        {
            ReydeldbContext _db = new ReydeldbContext();
            var res = _db.Database.ExecuteSqlCommand(@"exec USPUpdateColourMaster @Colour_Id,@Colour_Name",
            new SqlParameter("@Colour_Id", Colour_Id),
            new SqlParameter("@Colour_Name", Colour_Name));
            return Json("data Updated");
        }
        [HttpPost]
        public ActionResult UpdateSupportFunctionMaster(int SupportFunction_Id, string SupportFunction_Name, string SupportFunction_Code)
        {
            ReydeldbContext _db = new ReydeldbContext();
            var res = _db.Database.ExecuteSqlCommand(@"exec USPUpdateSupportFunctionMaster @SupportFunction_Id,@SupportFunction_Name,@SupportFunction_Code",
            new SqlParameter("@SupportFunction_Id", SupportFunction_Id),
            new SqlParameter("@SupportFunction_Name", SupportFunction_Name),
             new SqlParameter("@SupportFunction_Code", SupportFunction_Code));
            return Json("data Updated");
        }
        [HttpPost]
        public ActionResult UpdateChangeTypeMaster(int Change_Type_Id,string Change_Type_Name, string Change_Type_Code)
        {
            ReydeldbContext _db = new ReydeldbContext();
            var res = _db.Database.ExecuteSqlCommand(@"exec USPUpdateChangeTypeMaster @Change_Type_Id, @Change_Type_Name, @Change_Type_Code",
            new SqlParameter("@Change_Type_Id", Change_Type_Id),
            new SqlParameter("@Change_Type_Name", Change_Type_Name),
             new SqlParameter("@Change_Type_Code", Change_Type_Code));
            return Json("data Updated");
        }
        [HttpPost]
        public ActionResult UpdateRejectionTypeMaster(int Rejection_Type_Id, string Rejection_Type_Name)
        {
            ReydeldbContext _db = new ReydeldbContext();
            var res = _db.Database.ExecuteSqlCommand(@"exec USPUpdateRejectionTypeMaster @Rejection_Type_Id,@Rejection_Type_Name",
            new SqlParameter("@Rejection_Type_Id", Rejection_Type_Id),
            new SqlParameter("@Rejection_Type_Name", Rejection_Type_Name));
            return Json("data Updated");
        }
        [HttpPost]
        public ActionResult UpdateRejectionReasonMaster(int Rejection_Reason_Id, string Rejection_Reason_Name)
        {
            ReydeldbContext _db = new ReydeldbContext();
            var res = _db.Database.ExecuteSqlCommand(@"exec USPUpdateRejectionReasonMaster @Rejection_Reason_Id,@Rejection_Reason_Name",
            new SqlParameter("@Rejection_Reason_Id", Rejection_Reason_Id),
            new SqlParameter("@Rejection_Reason_Name", Rejection_Reason_Name));
            return Json("data Updated");
        }
        [HttpPost]
        public ActionResult UpdateExcelImportsTypes(int M_Import_Type_ID, string M_Import_Type_Name, string M_Import_Type_Modes)
        {
            ReydeldbContext _db = new ReydeldbContext();
            var res = _db.Database.ExecuteSqlCommand(@"exec USPUpdateExcelImportsTypes @Change_Type_Id, @M_Import_Type_Name, @M_Import_Type_Modes",
            new SqlParameter("@Change_Type_Id", M_Import_Type_ID),
            new SqlParameter("@M_Import_Type_Name", M_Import_Type_Name),
             new SqlParameter("@M_Import_Type_Modes", M_Import_Type_Modes));
            return Json("data Updated");
        }
    }
}