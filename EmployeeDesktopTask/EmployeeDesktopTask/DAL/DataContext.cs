using EmployeeDesktopTask.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace EmployeeDesktopTask.DAL
{
    public class DataContext : DbContext
    {
         public static string path = @"Data Source=DESKTOP-02RFMSI\SQLEXPRESS;Initial Catalog=DesktopEmployeeTask;Integrated Security=true;";
        public DataContext() : base(path)
        {
            if (!Database.Exists(path))
                Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<tblEmployee>().MapToStoredProcedures();
        //    base.OnModelCreating(modelBuilder);
        //}


        public DbSet<tblEmployee> tblEmployees { get; set; }
    }
}
