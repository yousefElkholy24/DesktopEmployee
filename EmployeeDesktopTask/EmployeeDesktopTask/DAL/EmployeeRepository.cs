using EmployeeDesktopTask.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EmployeeDesktopTask.DAL
{
    public class EmployeeRepository
    {

        DataContext db = new DataContext();

        public List<tblEmployee> GetEmployees()
        {
            return db.tblEmployees.ToList();
        }

        public void InsertEmployee(tblEmployee employee)
        {
            db.tblEmployees.Add(employee);
            db.SaveChanges();
        }

        public void UpdateEmployee (tblEmployee employee)
        {
            tblEmployee updEmp = db.tblEmployees.Find(employee.EmployeeID);
            updEmp.EmployeeName = employee.EmployeeName;
            updEmp.EmployeeSalary = employee.EmployeeSalary;
            updEmp.EmployeeContact = employee.EmployeeContact;
            updEmp.EmployeeAddress = employee.EmployeeAddress;

            db.Entry(updEmp).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteEmployee (tblEmployee employee)
        {
            tblEmployee delEmp = db.tblEmployees.Find(employee.EmployeeID);
            db.tblEmployees.Remove(delEmp);
            db.SaveChanges();
        }
    }
}
