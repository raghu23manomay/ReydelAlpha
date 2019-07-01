using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyVitarak.Models
{
    public partial class UserLogin
    {
        public Int32 UserTypeID { get; set; }
        public string FullName { get; set; }
        public string DeviceID { get; set; }
        public Int32 UserId { get; set; }
    }

    public partial class Payment
    {
        [Key]
        public int t_id { get; set; }
        public string payment_id { get; set; }
        public Int64 registration_id { get; set; }
        public int p_id { get; set; }
        public DateTime payment_date { get; set; }
        public Decimal amount { get; set; }
    }

    public partial class MailCheck
    {
        [Key]
        public Int64 RegistrationID { get; set; }
        public string Email { get; set; }
        public string mobile { get; set; }
        public string UserName { get; set; }
        public string BusinessName { get; set; }
    }

    public partial class Registration
    {
        [Key]
        public Int64 RegistrationID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public Int64 Mobile { get; set; }
        public string ContactPerson { get; set; }
        public string SecurityCode { get; set; }
        public bool isactive { get; set; }
        public bool isreadonly { get; set; }
        public string DbName { get; set; }
        public string BusinessName { get; set; }
        public string ContactPersonMobile { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string UserName { get; set; }

    }

    public partial class RegistrationDetails
    {
        [Key]
        public Int64 RegistrationID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string Mobile { get; set; }
        public string ContactPerson { get; set; }
        public string BusinessName { get; set; }
        public string UserName { get; set; }
    }

    public partial class SecurityCode
    {
        [Key]
        public int CodeId { get; set; }
        public string Code { get; set; }
    }

    public partial class Tenant
    {
        [Key]
        public Int64 TenantID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string ContactPerson { get; set; }
        public string SecurityCode { get; set; }
        public bool isActive { get; set; }
        public bool isReadOnly { get; set; }
        public string DbName { get; set; }
        public Int32 PlanID { get; set; }
        public Int64 PaidAmount { get; set; }
    }

    public partial class CheckDbSchema
    {
        [Key]
        public Int64 TenantID { get; set; }
        public Int64 RegistrationID { get; set; }
        public Boolean isSchemaCreated { get; set; }
    }

    public partial class CustomerList
    { 
        public Int32 CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Route { get; set; }
        public Int32 BillId { get; set; }
        public decimal BalanceDue { get; set; }
        public string PaymentStatus { get; set; }
        public Int32 TotalDue { get; set; }
        public Int32 CashPaid { get; set; }
    }
    
    public partial class DeliveryList
    {
        public Int32 CustomerID { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Amount { get; set; }
        public string CustomerName { get; set; }
        public string AddressDetails { get; set; }
        public string Route { get; set; }
        
    }
    
    public partial class VendorList
    {
        public Int32 VendorID { get; set; }
        public string VendorName { get; set; }
        public string Address { get; set; }
        public Int32 UserId { get; set; }
        public Int32? DeviceId { get; set; } 
    }
    public partial class OrderDetails
    {
        [Key]
        public Int32 BillId { get; set; }
        public Int32 ProductId { get; set; } 
        public string Product { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Rate { get; set; }
        public decimal Lickage { get; set; }
        public decimal CashAmount { get; set; }
        public decimal ChequeAmount { get; set; }
        public decimal BalanceDue { get; set; }
    }
    public partial class DeliveryOrderDetails
    {
        [Key]
        public Int32 BillId { get; set; }
        public Int32 ProductId { get; set; }
        public string Product { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Rate { get; set; }
        public decimal Lickage { get; set; }
        public decimal CashAmount { get; set; }
        public decimal ChequeAmount { get; set; }
        public decimal BalanceDue { get; set; }
    }

       public partial class PurchaseOrderDetails
    {
        [Key]
        public Int32 BillId { get; set; }
        public String BillDate { get; set; }
        public Int32 VendorID { get; set; }
        public decimal Rate { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public Int32 CratesIn { get; set; }
        public Int32 CratesOut { get; set; }
        public Int32 ProductId { get; set; }  
        public String ProductName { get; set; }
        public String VendorName { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal BalanceDue { get; set; }
    }
}