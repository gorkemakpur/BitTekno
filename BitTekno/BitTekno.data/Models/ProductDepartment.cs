//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BitTekno.data.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductDepartment
    {
        public int ID { get; set; }
        public Nullable<int> ProductDescriptionID { get; set; }
        public Nullable<System.DateTime> RecordDate { get; set; }
        public string Reference1 { get; set; }
        public string Reference2 { get; set; }
        public Nullable<bool> IsValid { get; set; }
        public Nullable<int> DepartmentID { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual ProductDescription ProductDescription { get; set; }
    }
}