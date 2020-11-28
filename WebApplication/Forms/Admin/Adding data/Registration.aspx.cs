using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication
{
    public partial class Registration : System.Web.UI.Page
    {
        //Подключение при загрузке страницы
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBConnection.qrEmployee;
            if (!IsPostBack)
            {
                gvFill(QR);
            }
        }

        //Подключение БД
        private void gvFill(string qr)
        {
            sdsEmployee.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsEmployee.SelectCommand = qr;
            sdsEmployee.DataSourceMode = SqlDataSourceMode.DataReader;
        }

        //Добавлениие в БД
        protected void btRegister_Click(object sender, EventArgs e)
        {
            switch (tbSurname_Employee.Text == "")
            {
                case (true):
                    tbSurname_Employee.BorderColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbSurname_Employee.BorderColor = System.Drawing.Color.LightGray;
                    switch (tbName_Employee.Text == "")
                    {
                        case (true):
                            tbName_Employee.BorderColor = System.Drawing.Color.Red;
                            break;
                        case (false):
                            tbName_Employee.BorderColor = System.Drawing.Color.LightGray;
                            switch (tbMiddlename_Employee.Text == "")
                            {
                                case (true):
                                    tbMiddlename_Employee.BorderColor = System.Drawing.Color.Red;
                                    break;
                                case (false):
                                    tbMiddlename_Employee.BorderColor = System.Drawing.Color.LightGray;
                                    switch (tbLogin.Text == "")
                                    {
                                        case (true):
                                            tbLogin.BorderColor = System.Drawing.Color.Red;
                                            break;
                                        case (false):
                                            tbLogin.BorderColor = System.Drawing.Color.LightGray;
                                            switch (tbPassword.Text == "")
                                            {
                                                case (true):
                                                    tbPassword.BorderColor = System.Drawing.Color.Red;
                                                    break;
                                                case (false):
                                                    tbPassword.BorderColor = System.Drawing.Color.LightGray;
                                                    switch (tbPhone_Number.Text == "")
                                                    {
                                                        case (true):
                                                            tbPhone_Number.BorderColor = System.Drawing.Color.Red;
                                                            break;
                                                        case (false):
                                                            tbPhone_Number.BorderColor = System.Drawing.Color.LightGray;
                                                            switch (tbMail.Text == "")
                                                            {
                                                                case (true):
                                                                    tbMail.BorderColor = System.Drawing.Color.Red;
                                                                    break;
                                                                case (false):
                                                                    tbMail.BorderColor = System.Drawing.Color.LightGray;
                                                                    SqlCommand command = new SqlCommand("", DBConnection.connection);
                                                                    command.CommandText = "insert into [dbo].[Authorization] ([Login], [Password], [Role])" +
                                                                        " values ('" + tbLogin.Text + "','" + tbPassword.Text + "','" + dlRole.SelectedValue + "')" +
                                                                        "select @@identity " +
                                                                        "insert into [dbo].[Employee] ([Authorization_ID], [Surname_Employee], [Name_Employee], [Middlename_Employee], [Position], [Phone_Number], [Mail]" +
                                                                        ") values (@@identity, '" + tbSurname_Employee.Text + "','" + tbName_Employee.Text + "','" + tbMiddlename_Employee.Text + "','" + dlPosition.SelectedValue + "','" + tbPhone_Number.Text + "','" + tbMail.Text + "')";
                                                                    try
                                                                    {
                                                                        DBConnection.connection.Open();
                                                                        command.ExecuteNonQuery();
                                                                        DBConnection.connection.Close();
                                                                        Page_Load(sender, e);
                                                                        gvFill(QR);
                                                                        Warning.Visible = false;
                                                                        Success.Visible = true;
                                                                        Clear();
                                                                    }
                                                                    catch
                                                                    {
                                                                        Success.Visible = false;
                                                                        Warning.Visible = true;
                                                                        DBConnection.connection.Close();
                                                                        Clear();
                                                                    }
                                                                    break;
                                                            };
                                                            break;
                                                    };
                                                    break;
                                            };
                                            break;
                                    };
                                    break;
                            };
                            break;
                    };
                    break;
            };
        }

        //Переход
        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Admin/Admin forms/Employee.aspx");
        }

        //Очистка полей
        public void Clear()
        {
            tbSurname_Employee.Text = "";
            tbName_Employee.Text = "";
            tbMiddlename_Employee.Text = "";
            tbLogin.Text = "";
            tbPassword.Text = "";
            tbPhone_Number.Text = "";
            tbMail.Text = "";
        }
    }
}