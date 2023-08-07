using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EMS___ABC_Company
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source = YASANTHA; Initial Catalog = ems; Integrated Security = True");

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                int no = Convert.ToInt32(cmbReg.Text);
                //string no = cmbReg.Text;
                string firstName = txtFname.Text;
                string lastName = txtLname.Text;
                string gender = rbMale.Checked ? "Male" : "Female";
                string address = txtAddress.Text;
                string email = txtEmail.Text;
                int mobilePhone = Convert.ToInt32(txtMobile.Text);
                int homePhone = Convert.ToInt32(txtHphone.Text);
                string departmentName = txtDName.Text;
                string designation = txtDesignation.Text;
                string employeeType = txtEtype.Text;

                string query_insert = "INSERT INTO Employee (EmpNo, firstName, lastName, dateOfBirth, gender, address, email, mobilePhone, homePhone, departmentName, designation, employeeType) " +
                                      "VALUES (@EmpNo, @FirstName, @LastName, @Dob, @Gender, @Address, @Email, @MobilePhone, @HomePhone, @DepartmentName, @Designation, @EmployeeType)";

                using (SqlConnection con = new SqlConnection("Data Source = YASANTHA; Initial Catalog = ems; Integrated Security = True"))
                {
                    using (SqlCommand cmnd = new SqlCommand(query_insert, con))
                    {
                        cmnd.Parameters.AddWithValue("@EmpNo", no);
                        cmnd.Parameters.AddWithValue("@FirstName", firstName);
                        cmnd.Parameters.AddWithValue("@LastName", lastName);
                        cmnd.Parameters.AddWithValue("@Dob", dtpDob.Value);
                        cmnd.Parameters.AddWithValue("@Gender", gender);
                        cmnd.Parameters.AddWithValue("@Address", address);
                        cmnd.Parameters.AddWithValue("@Email", email);
                        cmnd.Parameters.AddWithValue("@MobilePhone", mobilePhone);
                        cmnd.Parameters.AddWithValue("@HomePhone", homePhone);
                        cmnd.Parameters.AddWithValue("@DepartmentName", departmentName);
                        cmnd.Parameters.AddWithValue("@Designation", designation);
                        cmnd.Parameters.AddWithValue("@EmployeeType", employeeType);

                        con.Open();
                        cmnd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                MessageBox.Show("Record Added Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while inserting the record: " + ex.Message);
            }
            //try
            //{
            //    string firstName = txtFname.Text;
            //    string lastName = txtLname.Text;
            //    dtpDob.Format = DateTimePickerFormat.Custom;
            //    dtpDob.CustomFormat = "yyyy/MM/dd";
            //    string gender;
            //    if (rbMale.Checked)
            //    {
            //        gender = "Male";
            //    }
            //    else
            //    {
            //        gender = "Female";
            //    }
            //    string address = txtAddress.Text;
            //    string email = txtEmail.Text;
            //    int mobilePhone = Convert.ToInt32(txtMobile.Text);
            //    int homePhone = Convert.ToInt32(txtHphone.Text);
            //    string departmentName = txtDName.Text;
            //    string designation = txtDesignation.Text;
            //    string employeeType = txtEtype.Text;

            //    string query_insert = "insert into Employee values('" + firstName + "','" + lastName + "','" + dtpDob.Value + "','" + gender + "','" + address + "','" + email + "','" +
            //    mobilePhone + "','" + homePhone + "','" + departmentName + "','" + designation + "','" + employeeType + "')";

            //    if (con.State == ConnectionState.Closed)
            //    {
            //        con.Open();
            //    }

            //    SqlCommand cmnd = new SqlCommand(query_insert, con);

            //    cmnd.ExecuteNonQuery();
            //    con.Close();
            //    MessageBox.Show("Record Added Successfully!");


            //}
            //catch (SqlException ex)
            //{
            //    string msg = "Insert Error:";
            //    msg += ex.Message;
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string no = cmbReg.Text;

            if (no != "New Register")
            {
                try
                {
                    string firstName = txtFname.Text;
                    string lastName = txtLname.Text;
                    string gender = rbMale.Checked ? "Male" : "Female";
                    string address = txtAddress.Text;
                    string email = txtEmail.Text;
                    int mobilePhone = Convert.ToInt32(txtMobile.Text);
                    int homePhone = Convert.ToInt32(txtHphone.Text);
                    string departmentName = txtDName.Text;
                    string designation = txtDesignation.Text;
                    string employeeType = txtEtype.Text;

                    string query_update = "UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, dateOfBirth = @Dob, Gender = @Gender, Address = @Address, Email = @Email, " +
                        "MobilePhone = @MobilePhone, HomePhone = @HomePhone, DepartmentName = @DepartmentName, Designation = @Designation, EmployeeType = @EmployeeType " +
                        "WHERE empNo = @EmpNo";

                    using (SqlConnection con = new SqlConnection("Data Source = YASANTHA; Initial Catalog = ems; Integrated Security = True"))
                    {
                        using (SqlCommand cmnd = new SqlCommand(query_update, con))
                        {
                            cmnd.Parameters.AddWithValue("@FirstName", firstName);
                            cmnd.Parameters.AddWithValue("@LastName", lastName);
                            cmnd.Parameters.AddWithValue("@Dob", dtpDob.Value);
                            cmnd.Parameters.AddWithValue("@Gender", gender);
                            cmnd.Parameters.AddWithValue("@Address", address);
                            cmnd.Parameters.AddWithValue("@Email", email);
                            cmnd.Parameters.AddWithValue("@MobilePhone", mobilePhone);
                            cmnd.Parameters.AddWithValue("@HomePhone", homePhone);
                            cmnd.Parameters.AddWithValue("@DepartmentName", departmentName);
                            cmnd.Parameters.AddWithValue("@Designation", designation);
                            cmnd.Parameters.AddWithValue("@EmployeeType", employeeType);
                            cmnd.Parameters.AddWithValue("@EmpNo", no);

                            con.Open();
                            int rowsAffected = cmnd.ExecuteNonQuery();
                            con.Close();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record Updated Successfully!");
                            }
                            else
                            {
                                MessageBox.Show("No matching record found for the given employee number.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred while updating the record: " + ex.Message);
                }
            }
            //string no = cmbReg.Text;

            //if (no != "New Register")
            //{
            //    string firstName = txtFname.Text;
            //    string lastName = txtLname.Text;
            //    dtpDob.Format = DateTimePickerFormat.Custom;
            //    dtpDob.CustomFormat = "yyyy/MM/dd";
            //    string gender;
            //    if (rbMale.Checked)
            //    {
            //        gender = "Male";
            //    }
            //    else
            //    {
            //        gender = "Female";
            //    }
            //    string address = txtAddress.Text;
            //    string email = txtEmail.Text;
            //    int mobilePhone = Convert.ToInt32(txtMobile.Text);
            //    int homePhone = Convert.ToInt32(txtHphone.Text);
            //    string departmentName = txtDName.Text;
            //    string designation = txtDesignation.Text;
            //    string employeeType = txtEtype.Text;

            //    string query_insert = "UPDATE Employee SET firstName = '" + firstName + "',lastName = '" + lastName + "',dateofBirth = '" + dtpDob.Text + "',gender = '" +
            //        gender + "',address = '" + address + "',email = '" + email + "',mobilePhone = '" + mobilePhone + ",homePhone = " + homePhone + ",departmentName = '" +
            //        departmentName + "',designation = '" + designation + "',employeeType = " + employeeType + "WHERE empNo = " + no;

            //}
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbReg.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            dtpDob.Format = DateTimePickerFormat.Custom;
            dtpDob.CustomFormat = "yyyy/MM/dd";
            DateTime thisDay = DateTime.Today;
            dtpDob.Text = thisDay.ToString();

            rbMale.Checked = false;
            rbFemale.Checked = false;

            txtAddress.Text = "";
            txtEmail.Text = "";
            txtMobile.Text = "";
            txtHphone.Text = "";
            txtDName.Text = "";
            txtDesignation.Text = "";
            txtEtype.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you really want to Delete this Record...?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string no = cmbReg.Text;

                string query_insert = "DELETE FROM Employee WHERE empNo = " + no + "";
                con.Open();
                SqlCommand cmnd = new SqlCommand(query_insert, con);
                cmnd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!", "Deleted Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            cmbReg.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            dtpDob.Format = DateTimePickerFormat.Custom;
            dtpDob.CustomFormat = "yyyy/MM/dd";
            DateTime thisDay = DateTime.Today;
            dtpDob.Text = thisDay.ToString();

            rbMale.Checked = false;
            rbFemale.Checked = false;

            txtAddress.Text = "";
            txtEmail.Text = "";
            txtMobile.Text = "";
            txtHphone.Text = "";
            txtDName.Text = "";
            txtDesignation.Text = "";
            txtEtype.Text = "";
        }

        private void cmbReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            string no = cmbReg.Text;
            if (no != "New Register")
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query_select = "SELECT * FROM Employee WHERE empNo =" + no;
                SqlCommand cmd = new SqlCommand(query_select, con);
                SqlDataReader row = cmd.ExecuteReader();
                while (row.Read())
                {
                    txtFname.Text = row[1].ToString();
                    txtLname.Text = row[2].ToString();
                    dtpDob.Format = DateTimePickerFormat.Custom;
                    dtpDob.CustomFormat = "yyyy/MM/dd";
                    dtpDob.Text = row[3].ToString();
                    if (row[4].ToString() == "Male")
                    {
                        rbMale.Checked = true;
                        rbFemale.Checked = false;
                    }
                    else
                    {
                        rbMale.Checked = false;
                        rbFemale.Checked = true;
                    }
                    txtAddress.Text = row[5].ToString();
                    txtEmail.Text = row[6].ToString();
                    txtMobile.Text = row[7].ToString();
                    txtHphone.Text = row[8].ToString();
                    txtDName.Text = row[9].ToString();
                    txtDesignation.Text = row[10].ToString();
                    txtEtype.Text = row[11].ToString();
                }
                con.Close();
                //btnClear.Enabled = false;
                //btnUpdate.Enabled = false;
                //btnDelete.Enabled = false;
            }
            else
            {
                txtFname.Text = "";
                txtLname.Text = "";
                dtpDob.Format = DateTimePickerFormat.Custom;
                dtpDob.CustomFormat = "yyyy/MM/dd";
                DateTime thisDay = DateTime.Today;
                dtpDob.Text = thisDay.ToString();

                rbMale.Checked = true;
                rbFemale.Checked = false;

                txtAddress.Text = "";
                txtEmail.Text = "";
                txtMobile.Text = "";
                txtHphone.Text = "";
                txtDName.Text = "";
                txtDesignation.Text = "";
                txtEtype.Text = "";
                btnRegister.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            con.Open();
            string query_select = "SELECT * FROM Employee";
            SqlCommand cmnd = new SqlCommand(query_select, con);
            SqlDataReader row = cmnd.ExecuteReader();
            cmbReg.Items.Add("New Register");
            while (row.Read())
            {
                cmbReg.Items.Add(row[0].ToString());
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you really want to exit...?", "Exit ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


