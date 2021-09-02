using EmployeeDesktopTask.DAL;
using EmployeeDesktopTask.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeDesktopTask
{
    public partial class Form1 : Form
    {

        int Deleteid;
        int Updateid;
        DataContext db = new DataContext();
        tblEmployee emp = new tblEmployee();
        public Form1()
        {
            DataContext db = new DataContext();
            InitializeComponent();
            Display();

            panel2.Visible = false;
            panel3.Visible = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public void Display()
        {
            try
            {
               
                var dt = db.tblEmployees.SqlQuery("spGetEmployees").ToList();
                //var data = db.tblEmployees.ToList();
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;

            empName.Text = "";
            Salary.Text = "";
            Address.Text = "";
            Contact.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
               
                var output = db.tblEmployees.SqlQuery("spAddNewEmployee @EmployeeName,@EmployeeSalary,@EmployeeAddress,@EmployeeContact",                     
                    new SqlParameter("@EmployeeName", empName.Text),
                    new SqlParameter("@EmployeeSalary", Convert.ToInt32(Salary.Text)),
                    new SqlParameter("@EmployeeAddress", Address.Text),
                    new SqlParameter("@EmployeeContact", Contact.Text)).SingleOrDefault();



                //var output= db.tblEmployees.SqlQuery("exec spAddNewEmployee @Name = " + empName.Text + 
                //     ",@Salary= " + Convert.ToInt32(Salary.Text) + 
                //     ",@Address= " + Address.Text + 
                //     ",@Contact = " + Contact.Text).SingleOrDefault();




                //emp.EmployeeName = empName.Text;
                //emp.EmployeeAddress = Address.Text;
                //emp.EmployeeSalary = Convert.ToInt32(Salary.Text);
                //emp.EmployeeContact = Contact.Text;
                //db.tblEmployees.Add(emp);
                //db.SaveChanges();               
               
                
                MessageBox.Show("the data has been Added successfully..");
                Display();
                panel3.Visible = false;
                panel2.Visible = false;
                panel1.Visible = true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                Deleteid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                try
                {

                  var DelEmp=  db.tblEmployees.SqlQuery("spDeleteEmployeeById @id ", new SqlParameter("@id", Deleteid)).FirstOrDefault();

                    //var DelEmployee = db.tblEmployees.Find(Deleteid);
                    //db.tblEmployees.Remove(DelEmployee);

                    db.SaveChanges();

                    MessageBox.Show("The record is deleted successfully...");

                    Display();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Update")
            {
                Updateid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

                var Data = db.tblEmployees.Where(c => c.EmployeeID == Updateid).FirstOrDefault();
                panel3.Visible = true;
                panel1.Visible = false;
                panel2.Visible = false;

                uEmpName.Text = Data.EmployeeName;
                uAddress.Text = Data.EmployeeAddress;
                uContact.Text = Data.EmployeeContact;
                uSalary.Text = Data.EmployeeSalary.ToString();
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {

                var output = db.tblEmployees.SqlQuery("spUpdateEmployeeById @id,@Name,@Salary,@Address,@Contact",
                    new SqlParameter("@id",Updateid),
                    new SqlParameter("@Name", uEmpName.Text),
                    new SqlParameter("@Salary", Convert.ToInt32(uSalary.Text)),
                    new SqlParameter("@Address", uAddress.Text),
                    new SqlParameter("@Contact", uContact.Text)).SingleOrDefault();






                //var UpdEmployee = db.tblEmployees.Find(Updateid);

                //UpdEmployee.EmployeeName = uEmpName.Text;
                //UpdEmployee.EmployeeAddress = uAddress.Text;
                //UpdEmployee.EmployeeContact = uContact.Text;
                //UpdEmployee.EmployeeSalary =Convert.ToInt32( uSalary.Text);

                //db.Entry(UpdEmployee).State = EntityState.Modified;
                //db.SaveChanges();

                MessageBox.Show("The record is Updated successfully...");
                panel3.Visible = false;
                panel1.Visible = true;

                Display();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
