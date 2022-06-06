using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitTekno.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Title { get; set; }
        public string Reference1 { get; set; }
        public string Reference2 { get; set; }
        public Nullable<bool> IsValid { get; set; }
        public string Description { get; set; }
    }
}