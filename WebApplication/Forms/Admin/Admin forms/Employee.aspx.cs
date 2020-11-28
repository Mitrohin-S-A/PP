using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication
{
    public partial class Employee : System.Web.UI.Page
    {
        //Подключение при загрузке страницы
        string date;
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            date = DateTime.Now.ToString("dd.MM.yyyy");
            QR = DBConnection.qrEmployee;
            if (!IsPostBack)
            {
                gvFill(QR);
            }
        }

        //Работа с БД
        private void gvFill(string qr)
        {
            sdsEmployee.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsEmployee.SelectCommand = qr;
            sdsEmployee.DataSourceMode = SqlDataSourceMode.DataReader;
            gvEmployee.DataSource = sdsEmployee;
            gvEmployee.DataBind();
        }

        //Переход в регистрацию
        protected void ibInsert_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Forms/Admin/Adding data/Registration.aspx");
        }

        //Удаление
        protected void ibDelete_Click(object sender, ImageClickEventArgs e)
        {
            if (DBConnection.IDrecord != 0)
            {
                SqlCommand commandDelete = new SqlCommand("", DBConnection.connection);
                commandDelete.CommandText = "delete from [dbo].[Authorization] " +
                    "where ID_Authorization = " + DBConnection.IDrecord + "";

                SqlCommand commandDismissed = new SqlCommand("", DBConnection.connection);
                commandDismissed.CommandText = "insert into [dbo].[Dismissed] ([Surname_Employee], [Name_Employee], [Middlename_Employee], [Position], [Data_of_Dismissed])" +
                    " values ('" + tbSurname_Employee.Text + "','" + tbName_Employee.Text + "','" + tbMiddlename_Employee.Text + "','" + dlPosition.SelectedValue + "','" + date + "')";

                DBConnection.connection.Open();
                commandDelete.ExecuteNonQuery();
                commandDismissed.ExecuteNonQuery();
                DBConnection.connection.Close();
                Page_Load(sender, e);
                gvFill(QR);
                lblSelected.Text = "";
                SuccessDelete.Visible = true;
                WarningDelete.Visible = false;
            }
            else
            {
                SuccessDelete.Visible = false;
                WarningDelete.Visible = true;
                DBConnection.connection.Close();
            }
        }

        //Скрыть столбец
        protected void gvEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[6].Visible = false;
        }

        //Выбрать даныне
        protected void gvEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvEmployee.SelectedRow;
            lblSelected.Text = row.Cells[2].Text.ToString() + " " + row.Cells[3].Text.ToString() + " " + row.Cells[4].Text.ToString();
            tbSurname_Employee.Text = row.Cells[2].Text.ToString();
            tbName_Employee.Text = row.Cells[3].Text.ToString();
            tbMiddlename_Employee.Text = row.Cells[4].Text.ToString();
            tbLogin.Text = row.Cells[5].Text.ToString();
            tbPassword.Text = row.Cells[6].Text.ToString();
            tbPhone_Number.Text = row.Cells[8].Text.ToString();
            tbMail.Text = row.Cells[9].Text.ToString();
            DBConnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
        }

        //Сортировка данных
        protected void gvEmployee_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Фамилия сотрудника"):
                    e.SortExpression = "[Surname_Employee]";
                    break;
                case ("Имя сотрудника"):
                    e.SortExpression = "[Name_Employee]";
                    break;
                case ("Отчество сотрудника"):
                    e.SortExpression = "[Middlename_Employee]";
                    break;
                case ("Логин"):
                    e.SortExpression = "[Login]";
                    break;
                case ("Должность"):
                    e.SortExpression = "[Position]";
                    break;
                case ("Телефонный номер"):
                    e.SortExpression = "[Phone_Number]";
                    break;
                case ("Почта"):
                    e.SortExpression = "[Mail]";
                    break;
                case ("Роль"):
                    e.SortExpression = "[Role]";
                    break;
            }
            sortGridView(gvEmployee, e, out sortDirection, out strField);
            string strDirection = sortDirection
                == SortDirection.Ascending ? "ASC" : "DESC";
            gvFill(QR + " order by " + e.SortExpression + " " + strDirection);
        }

        //Сортировка
        private void sortGridView(GridView gridView, GridViewSortEventArgs e, out SortDirection sortDirection, out string strSortField)
        {
            strSortField = e.SortExpression;
            sortDirection = e.SortDirection;

            if (gridView.Attributes["CurrentSortField"] != null &&
                gridView.Attributes["CurrentSortDirection"] != null)
            {
                if (strSortField ==
                    gridView.Attributes["CurrentSortField"])
                {
                    if (gridView.Attributes["CurrentSortDirection"]
                        == "ASC")
                    {
                        sortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        sortDirection = SortDirection.Ascending;
                    }
                }
            }
            gridView.Attributes["CurrentSortField"] = strSortField;
            gridView.Attributes["CurrentSortDirection"] =
                (sortDirection == SortDirection.Ascending ? "ASC"
                : "DESC");
        }

        //Поиск
        protected void ibSearch_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow row in gvEmployee.Rows)
            {
                if (row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[3].Text.Equals(tbSearch.Text)
                    || row.Cells[4].Text.Equals(tbSearch.Text)
                    || row.Cells[5].Text.Equals(tbSearch.Text)
                    || row.Cells[7].Text.Equals(tbSearch.Text)
                    || row.Cells[8].Text.Equals(tbSearch.Text)
                    || row.Cells[9].Text.Equals(tbSearch.Text)
                    || row.Cells[10].Text.Equals(tbSearch.Text))
                    row.BackColor = System.Drawing.Color.DarkGray;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }

        //Обновление данных
        protected void ibUpdate_Click(object sender, ImageClickEventArgs e)
        {
            if (DBConnection.IDrecord != 0)
            {
                WarningDelete.Visible = false;
                divUpdate.Visible = true;
                divSelected.Visible = false;
                divSearch.Visible = false;
                gvEmployee.Visible = false;
                divButton.Visible = false;
                divLabel.Visible = false;
            }
            else
            {
                WarningDelete.Visible = true;
            }
        }

        //Отменить изменнения
        protected void btCancel_Click(object sender, EventArgs e)
        {
            divUpdate.Visible = false;
            Vis();
        }

        //Скрыть
        public void UnVis()
        {
            divSelected.Visible = false;
            divSearch.Visible = false;
            gvEmployee.Visible = false;
            divButton.Visible = false;
            divLabel.Visible = false;
        }

        //Показать 
        public void Vis()
        {
            divSelected.Visible = true;
            divSearch.Visible = true;
            gvEmployee.Visible = true;
            divButton.Visible = true;
            divLabel.Visible = true;
        }

        //Обновить данные
        protected void btUpdate_Click(object sender, EventArgs e)
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
                                                                    SqlCommand command_Employee = new SqlCommand("", DBConnection.connection);
                                                                    SqlCommand command_Authorization = new SqlCommand("", DBConnection.connection);
                                                                    command_Employee.CommandText = "update [dbo].[Employee] set " +
                                                                        "[Surname_Employee] = '" + tbSurname_Employee.Text + "', " +
                                                                        "[Name_Employee] = '" + tbName_Employee.Text + "', " +
                                                                        "[Middlename_Employee] = '" + tbMiddlename_Employee.Text + "', " +
                                                                        "[Position] = '" + dlPosition.Text + "', " +
                                                                        "[Phone_Number] = '" + tbPhone_Number.Text + "', " +
                                                                        "[Mail] = '" + tbMail.Text + "' " +
                                                                        "where Authorization_ID = " + DBConnection.IDrecord + "";
                                                                    command_Authorization.CommandText = "update [dbo].[Authorization] set " +
                                                                        "[Login] = '" + tbLogin.Text + "', " +
                                                                        "[Password] = '" + tbPassword.Text + "', " +
                                                                        "[Role] = '" + dlRole.Text + "' " +
                                                                        "where ID_Authorization = " + DBConnection.IDrecord + "";

                                                                    try
                                                                    {
                                                                        DBConnection.connection.Open();
                                                                        command_Employee.ExecuteNonQuery();
                                                                        command_Authorization.ExecuteNonQuery();
                                                                        DBConnection.connection.Close();
                                                                        Page_Load(sender, e);
                                                                        gvFill(QR);
                                                                        SuccessUpdate.Visible = true;
                                                                        Vis();
                                                                        divUpdate.Visible = false;
                                                                    }
                                                                    catch
                                                                    {
                                                                        WarningUpdate.Visible = true;
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
    }
}