﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SohelAfzalShajol_Playon24.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SohelAfzalShajol_Playon24Entities : DbContext
    {
        public SohelAfzalShajol_Playon24Entities()
            : base("name=SohelAfzalShajol_Playon24Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer_Register> Customer_Register { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Pro_Order> Pro_Order { get; set; }
    
        public virtual int SP_Customer_Register(string customer_Name, string cus_Email, string cus_Gender, string cus_Type, string cus_Password, string cus_RePassword, Nullable<bool> isActive)
        {
            var customer_NameParameter = customer_Name != null ?
                new ObjectParameter("Customer_Name", customer_Name) :
                new ObjectParameter("Customer_Name", typeof(string));
    
            var cus_EmailParameter = cus_Email != null ?
                new ObjectParameter("Cus_Email", cus_Email) :
                new ObjectParameter("Cus_Email", typeof(string));
    
            var cus_GenderParameter = cus_Gender != null ?
                new ObjectParameter("Cus_Gender", cus_Gender) :
                new ObjectParameter("Cus_Gender", typeof(string));
    
            var cus_TypeParameter = cus_Type != null ?
                new ObjectParameter("Cus_Type", cus_Type) :
                new ObjectParameter("Cus_Type", typeof(string));
    
            var cus_PasswordParameter = cus_Password != null ?
                new ObjectParameter("Cus_Password", cus_Password) :
                new ObjectParameter("Cus_Password", typeof(string));
    
            var cus_RePasswordParameter = cus_RePassword != null ?
                new ObjectParameter("Cus_RePassword", cus_RePassword) :
                new ObjectParameter("Cus_RePassword", typeof(string));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Customer_Register", customer_NameParameter, cus_EmailParameter, cus_GenderParameter, cus_TypeParameter, cus_PasswordParameter, cus_RePasswordParameter, isActiveParameter);
        }
    
        public virtual ObjectResult<Customer_Register> Fn_Customer_Register(string customer_Name, string cus_Email, string cus_Gender, string cus_Type, string cus_Password, string cus_RePassword, Nullable<bool> isActive)
        {
            var customer_NameParameter = customer_Name != null ?
                new ObjectParameter("Customer_Name", customer_Name) :
                new ObjectParameter("Customer_Name", typeof(string));
    
            var cus_EmailParameter = cus_Email != null ?
                new ObjectParameter("Cus_Email", cus_Email) :
                new ObjectParameter("Cus_Email", typeof(string));
    
            var cus_GenderParameter = cus_Gender != null ?
                new ObjectParameter("Cus_Gender", cus_Gender) :
                new ObjectParameter("Cus_Gender", typeof(string));
    
            var cus_TypeParameter = cus_Type != null ?
                new ObjectParameter("Cus_Type", cus_Type) :
                new ObjectParameter("Cus_Type", typeof(string));
    
            var cus_PasswordParameter = cus_Password != null ?
                new ObjectParameter("Cus_Password", cus_Password) :
                new ObjectParameter("Cus_Password", typeof(string));
    
            var cus_RePasswordParameter = cus_RePassword != null ?
                new ObjectParameter("Cus_RePassword", cus_RePassword) :
                new ObjectParameter("Cus_RePassword", typeof(string));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Customer_Register>("Fn_Customer_Register", customer_NameParameter, cus_EmailParameter, cus_GenderParameter, cus_TypeParameter, cus_PasswordParameter, cus_RePasswordParameter, isActiveParameter);
        }
    
        public virtual ObjectResult<Customer_Register> Fn_Customer_Register(string customer_Name, string cus_Email, string cus_Gender, string cus_Type, string cus_Password, string cus_RePassword, Nullable<bool> isActive, MergeOption mergeOption)
        {
            var customer_NameParameter = customer_Name != null ?
                new ObjectParameter("Customer_Name", customer_Name) :
                new ObjectParameter("Customer_Name", typeof(string));
    
            var cus_EmailParameter = cus_Email != null ?
                new ObjectParameter("Cus_Email", cus_Email) :
                new ObjectParameter("Cus_Email", typeof(string));
    
            var cus_GenderParameter = cus_Gender != null ?
                new ObjectParameter("Cus_Gender", cus_Gender) :
                new ObjectParameter("Cus_Gender", typeof(string));
    
            var cus_TypeParameter = cus_Type != null ?
                new ObjectParameter("Cus_Type", cus_Type) :
                new ObjectParameter("Cus_Type", typeof(string));
    
            var cus_PasswordParameter = cus_Password != null ?
                new ObjectParameter("Cus_Password", cus_Password) :
                new ObjectParameter("Cus_Password", typeof(string));
    
            var cus_RePasswordParameter = cus_RePassword != null ?
                new ObjectParameter("Cus_RePassword", cus_RePassword) :
                new ObjectParameter("Cus_RePassword", typeof(string));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Customer_Register>("Fn_Customer_Register", mergeOption, customer_NameParameter, cus_EmailParameter, cus_GenderParameter, cus_TypeParameter, cus_PasswordParameter, cus_RePasswordParameter, isActiveParameter);
        }
    }
}
