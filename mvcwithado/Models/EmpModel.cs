using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcwithado.Models
{
    public class EmpModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeGender { get; set; }
        public string EmployeeDesignation { get; set; }
        public string Image { get; set; }
        public HttpPostedFileBase file { get; set; }

    }
}