using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeDesktopTask.Model
{

    [Table("tblEmployee")]
    public class tblEmployee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeSalary { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeContact { get; set; }
    }
}
