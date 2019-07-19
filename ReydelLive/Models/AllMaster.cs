using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;


namespace ReyDel.Models
{
    public class RejectionEntryDetails
    {
        [Key]
        public int? Rejection_Entry_Id { get; set; }
        public DateTime Rejection_from { get; set; }
        public int Prod_Entry_Id { get; set; }
        public int Rejection_Type_Id { get; set; }
        public int Rejection_Reason_Id { get; set; }
        public int Rejection_Qty { get; set; }
        public int Lumps { get; set; }

    }
    public class RejectionEntryDetailsList
    {
        [Key]
        public int? Rejection_Entry_Id { get; set; }
        public String Rejectionfrom { get; set; }
        public int Prod_Entry_Id { get; set; }
        public String RejectionReasonName { get; set; }
        public String RejectionTypeName { get; set; }
        public int Rejection_Type_Id { get; set; }
        public int Rejection_Reason_Id { get; set; }
        public int Rejection_Qty { get; set; }
        public int Lumps { get; set; }

    }
    public class ChangeOver_Entry
    {
        [Key]
        public int? Entry_Id { get; set; }
        public DateTime Entry_Date { get; set; }
        public int Calendar_id { get; set; }
        public int Emp_Id { get; set; }
        public int ChangeOver_Config_Type { get; set; }
        public int Change_From_REI_ID { get; set; }
        public int Change_From_Part_Id { get; set; }
        public int Change_From_Mat_Grade_Id { get; set; }
        public int Change_To_REI_ID { get; set; }
        public int Change_To_Part_Id { get; set; }
        public int Change_To_Mat_Grade_Id { get; set; }
        public int StandardRunQty { get; set; }
        public int Actual_RunQty { get; set; }
        public decimal Increase_in_Scrap_Percent { get; set; }
        public decimal Increase_in_scrap_Value { get; set; }
        public TimeSpan ChangeOver_Start { get; set; }
        public TimeSpan ChangeOver_End { get; set; }
        public int TotalChangeOver { get; set; }
        public int Std_ChangeOverTime { get; set; }
        public decimal Difference { get; set; }
        public decimal LossInPrecentage { get; set; }
        public decimal Expected_Lumps { get; set; }
        public decimal Actual_Lumps { get; set; }
        public decimal Difference_Lumps { get; set; }
        public decimal ScrapPercentIncrease { get; set; }
    }
    public class ChangeOverEntryList
    {
        [Key]
        public int? Entry_Id { get; set; }
        public String EntryDate { get; set; }
        public int Calendar_id { get; set; }
        public int Emp_Id { get; set; }
        public int ChangeOver_Config_Type { get; set; }
        public int Change_From_REI_ID { get; set; }
        public int Change_From_Part_Id { get; set; }
        public int Change_From_Mat_Grade_Id { get; set; }
        public int Change_To_REI_ID { get; set; }
        public int Change_To_Part_Id { get; set; }
        public int Change_To_Mat_Grade_Id { get; set; }
        public int StandardRunQty { get; set; }
        public int Actual_RunQty { get; set; }
        public decimal Increase_in_Scrap_Percent { get; set; }
        public decimal Increase_in_scrap_Value { get; set; }
        public TimeSpan ChangeOver_Start { get; set; }
        public TimeSpan ChangeOver_End { get; set; }
        public int TotalChangeOver { get; set; }
        public int Std_ChangeOverTime { get; set; }
        public decimal Difference { get; set; }
        public decimal LossInPrecentage { get; set; }
        public decimal Expected_Lumps { get; set; }
        public decimal Actual_Lumps { get; set; }
        public decimal Difference_Lumps { get; set; }
        public decimal ScrapPercentIncrease { get; set; }
    }
    public class Production_Entry
    {
        [Key]
        public int? Entry_Id { get; set; }
        public int Calendar_id { get; set; }
        public DateTime Entry_Date { get; set; }
        public int Emp_id { get; set; }
        public int Shift { get; set; }
        public int Machine { get; set; }
        public int REI { get; set; }
        public int Part { get; set; }
        public int Plan_Qty { get; set; }
        public decimal Cumm_Accepted_Qty { get; set; }
        public decimal Accepted_Qty { get; set; }
        public int Operator_Emp { get; set; }
        public int Shift_superviser { get; set; }
    }
    public class ProductionEntryList
    {
        [Key]
        public int? Entry_Id { get; set; }
        public int? Calendar_id { get; set; }
        public String EntryDate { get; set; }
        public int Emp_id { get; set; }
        public int Shift { get; set; }
        public int Machine { get; set; }
        public int REI { get; set; }
        public int Part { get; set; }
        public int Plan_Qty { get; set; }
        public decimal Cumm_Accepted_Qty { get; set; }
        public decimal Accepted_Qty { get; set; }
        public int Operator_Emp { get; set; }
        public int Shift_superviser { get; set; }
    }
    public class DownTime_Entry
    {
        [Key]
        public int? Entry_Id { get; set; }
        public DateTime Entry_Date { get; set; }
        public int Calendar_id { get; set; }
        public int Emp_Id { get; set; }
        public Boolean IsPlanned { get; set; }
        public TimeSpan Planned_from { get; set; }
        public TimeSpan Planned_to { get; set; }
        public int Total_Planned { get; set; }
        public string Downtime_description { get; set; }
        public int Supoort_Function_Id { get; set; }
        public string Downtime_SlipSerialNo { get; set; }
        public TimeSpan Downtime_From { get; set; }
        public TimeSpan Downtime_to { get; set; }
        public int Total_Downtime { get; set; }
    }
    public class DownTimeEntryList
    {
        [Key]
        public int? Entry_Id { get; set; }
        public String EntryDate { get; set; }
        public int Calendar_id { get; set; }
        public int Emp_Id { get; set; }
        public Boolean IsPlanned { get; set; }
        public TimeSpan Planned_from { get; set; }
        public TimeSpan Planned_to { get; set; }
        public int Total_Planned { get; set; }
        public string Downtime_description { get; set; }
        public int Supoort_Function_Id { get; set; }
        public string Downtime_SlipSerialNo { get; set; }
        public TimeSpan Downtime_From { get; set; }
        public TimeSpan Downtime_to { get; set; }
        public int Total_Downtime { get; set; }
    }
    public class MaterialGradeMaster
    {
        [Key]
        public int? Material_Grade_Id { get; set; }
        public string Material_Grade_name { get; set; }
        public double Material_Grade_Rate { get; set; }
    }
    public class REIMaster
    {
        [Key]
        public int? REI_Id { get; set; }
        public string REI_Name { get; set; }
      
    }
    public class ColourMaster
    {
        [Key]
        public int? Colour_Id { get; set; }
        public string Colour_Name { get; set; }

    }
    public class SupportFunctionMaster
    {
        [Key]
        public int? SupportFunction_Id { get; set; }
        public string SupportFunction_Name { get; set; }
        public string SupportFunction_Code { get; set; }

    }
    public class ChangeTypeMaster
    {
        [Key]
        public int? Change_Type_Id { get; set; }
        public string Change_Type_Name { get; set; }
        public string Change_Type_Code { get; set; }

    }
    //public class ChangeTypeConfiguration
    //{
    //    [Key]
    //    public int? ChangeTypeConfigID { get; set; }
    //    public int? Machine_Id { get; set; }
    //    public string Machine_operation { get; set; }
    //    public string Change_Over_Target_Time { get; set; }
    //    public string Expected_Lumps { get; set; }
    //    public string STD_Material_loading_OST { get; set; }
    //    public string STD_Change_over_OST { get; set; }
    //    public string STD_Material_change_over { get; set; }
    //    public string STD_ASSY_OST { get; set; }
    //    public string STD_Inspection_OST { get; set; }
    //    public string STD_material_movement { get; set; }
    //    public string System_regrind_management { get; set; }
    //    public string OST_For_daily_monitoring { get; set; }
    //}
    public class AllMaster
    {
    }
  
    public class Route
    {
        public DataTable dtTable;
        [Key]
        public int RouteId { get; set; }
        public int CityId { get; set; }
        [Required]
        public string Area { get; set; }

    }
   
    public class copyrate
    {
        [Key]
        public int? Sr_No { get; set; }
        public string CustomerName { get; set; }
        public string Area { get; set; }
    }
  
    public class ProductDetails
    {

        [Key]
        public int ProductID { get; set; }
        public string Product { get; set; }
        public int? ProductBrandID { get; set; }
        public int CrateSize { get; set; }
        public Decimal? GST { get; set; }
        public int? TotalRows { get; set; }

    }

    public class ProductMaster
    {

        [Key]
        public int ProductID { get; set; }
        public string Product { get; set; }
        public int? ProductBrandID { get; set; }
        public int? StockCount { get; set; }
        public Decimal? SalePrice { get; set; }
        public int CrateSize { get; set; }
        public Decimal GST { get; set; }

    }

    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public int AreaID { get; set; }
        public string Mobile { get; set; }
    }

    public class EmployeeList
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public int AreaID { get; set; }
        public string Mobile { get; set; }
    }

    public class EmployeeDetails
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        IEnumerable<EmployeeDetails> EmployeeDetail { get; set; }
        public string Address { get; set; }
        public int AreaID { get; set; }
        public string Area { get; set; }
        public string Mobile { get; set; }
        public int? TotalRows { get; set; }
    }

    public class Vehical
    {
        [Key]
        public int VechicleID { get; set; }
        public string Transport { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string VechicleNo { get; set; }
        public string Marathi { get; set; }
        public Decimal RatePerTrip { get; set; }
        public int PrintOrder { get; set; }
    }

    public class VehicalDetails
    {
        [Key]
        public int VechicleID { get; set; }
        public string Transport { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string VechicleNo { get; set; }
        public string Marathi { get; set; }
        public Decimal RatePerTrip { get; set; }
        public int PrintOrder { get; set; }
        public int? TotalRows { get; set; }
    }


    public class SupplierDetails
    {
        [Key]
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string PersonMobileNo { get; set; }
        public string ContactPerson { get; set; }
        public string EmailID { get; set; }
        public Boolean IsActive { get; set; }
        public int? TotalRows { get; set; }

    }

    public class SupplierMaster
    {
        [Key]
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string PersonMobileNo { get; set; }
        public string ContactPerson { get; set; }
        public string EmailID { get; set; }
        public Boolean IsActive { get; set; }
        public string OfficeNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Address { get; set; }
        public Int64? TenantID { get; set; }
        public Int64? userid { get; set; }

    }

    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public int AreaID { get; set; }
        public string Area { get; set; }
        public int SalesPersonID { get; set; }
        public string EmployeeName { get; set; }
        public int VehicleID { get; set; }
        public string VechicleNo { get; set; }
        public int? CustomerTypeId { get; set; }
        public string CustomerType { get; set; }
        public string CustomerNameEnglish { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Boolean isBillRequired { get; set; }
        public Boolean isActive { get; set; }
        public Decimal DeliveryCharges { get; set; }
    }



    //public class CustomerList
    //{
    //    [Key]
    //    public int CustomerID { get; set; }
    //    public string CustomerName { get; set; }
    //    public string Address { get; set; }
    //    public string Mobile { get; set; }
    //    public int AreaID { get; set; }
    //    public string Area { get; set; }
    //    public int SalesPersonID { get; set; }
    //    public string EmployeeName { get; set; }
    //    public int VehicleID { get; set; }
    //    public string VechicleNo { get; set; }
    //    public int? CustomerTypeId { get; set; }
    //    public string CustomerType { get; set; }
    //    public Boolean isBillRequired { get; set; }
    //    public Boolean isActive { get; set; }
    //    public Decimal? DeliveryCharges { get; set; }
    //}


    public class CustomerDetails
    {

        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public int AreaID { get; set; }
        public int SalesPersonID { get; set; }
        public string CustomerNameEnglish { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string EmployeeName { get; set; }
        public int? VehicleID { get; set; }
        public Boolean? isBillRequired { get; set; }
        public Boolean? isActive { get; set; }
        public Decimal? DeliveryCharges { get; set; }
        public string Area { get; set; }
        public string VechicleNo { get; set; }
        public int? TotalRows { get; set; }
    }

    public class OpeningBalance
    {
        [Key]
        public int CustomerID { get; set; }
        public Decimal PreviousBalance { get; set; }
    }

    public class RouteDetails
    {

        [Key] public int AreaID { get; set; }
        public string Area { get; set; }
        IEnumerable<RouteDetails> RouteDetail { get; set; }
        public int? TotalRows { get; set; }

    }


    public class EditRoute
    {
        [Key]
        public int AreaID { get; set; }
        public int CityID { get; set; }
        public string Area { get; set; }

    }
    public class OpeningBalanceDeatils
    {
        [Key]
        public int Sr_No { get; set; }
        public string CustomerName { get; set; }
        public string Area { get; set; }
        public int TotalRows { get; set; }
        public Decimal BalanceAmount { get; set; }
    }

    public class CustomerProductDetails
    {

        [Key]
        public int ProductID { get; set; }
        public int CustRateID { get; set; }
        public int Customerid { get; set; }
        public string Product { get; set; }
        public decimal Rate { get; set; }
        public int CrateSize { get; set; }

    }
    public class DashboardCounts
    {

        [Key]
        public Int64 vendorCount { get; set; }
        public Int64 PurchaseAmount { get; set; }
        public Int64 salesAmount { get; set; }
        public Int64 CustomerCount { get; set; }

    }


    public class NotificationDetails
    {

        [Key]
        public Int64 NotificationID { get; set; }
        public Int64 FromTenantID { get; set; }
        public Int64 ToTenantID { get; set; }
        public int? NotType { get; set; }
        public int? IsApprove { get; set; }
        public String Messege { get; set; }
        public int CreatedBy { get; set; }
        public String CreatedDate { get; set; }
        public String MessegeFrom { get; set; }
        public String Mobile { get; set; }
        public String Address { get; set; }
        public int? IsRead { get; set; }

    }
    public class Chart
    {

        [Key]
        public string Label { get; set; }
        public Int32 Value1 { get; set; }
        public Int32 Value2 { get; set; }
        
    }

    public class NotoficationCount
    {

        [Key]
        public int CountAll { get; set; }

    }


    public class RejectionReasonTypeMaster
    {
        [Key]
        public int? Rejection_Type_Id { get; set; }
        public string Rejection_Type_Name { get; set; }
        public int Rejection_Reason_Id { get; set; }
        public string Rejection_Reason_Name { get; set; }
    }
    public class RejectionReasonMaster
    {
        [Key]
        public int Rejection_Reason_Id { get; set; }
        public string Rejection_Reason_Name { get; set; }
    }
    public class ExcelImportTypeMaster
    {
        [Key]
        public int M_Import_Type_ID { get; set; }
        public string M_Import_Type_Name { get; set; }
        public string M_Import_Type_Modes { get; set; }
    }
    public class ChangeTypeConfiguration
    {
        [Key]
        public int ChangeTypeConfigID { get; set; }
        public int Machine_Id { get; set; }
        public Decimal Machine_operation { get; set; }
        public decimal Change_Over_Target_Time { get; set; }
        public decimal Expected_Lumps { get; set; }
        public decimal STD_Material_loading_OST { get; set; }
        public decimal STD_Change_over_OST { get; set; }
        public decimal STD_Material_change_over { get; set; }
        public decimal STD_ASSY_OST { get; set; }
        public decimal STD_Inspection_OST { get; set; }
        public decimal STD_Material_Movement { get; set; }
        public decimal System_Regrind_Management { get; set; }
        public decimal OST_For_daily_Monitoring { get; set; }
    }                 
}
