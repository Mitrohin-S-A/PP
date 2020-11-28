using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;

namespace WebApplication
{
    public partial class Template : System.Web.UI.MasterPage
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = DBConnection.qrEmployee;
            if (!IsPostBack)
            {
                gvFill(QR);
            }
        }

        private void gvFill(string qr)
        {
            sdsAuthorization.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsAuthorization.SelectCommand = qr;
            sdsAuthorization.DataSourceMode = SqlDataSourceMode.DataReader;
        }

        public string GetPass()
        {
            int[] arr = new int[10];
            Random rnd = new Random();
            string Password = "";
            string[] arr1 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Z", "b", "c", "d", "f", "g", "h", "j", "k", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z", "A", "E", "U", "Y", "a", "e", "i", "o", "u", "y" };
            for (int i = 0; i < arr.Length; i++)
            {
                Password += arr1[rnd.Next(0, 57)];
            }
            return Password;
        }

        protected void btnAuthorization_Click(object sender, EventArgs e)
        {
            DBConnection connection = new DBConnection();
            connection.dbEnter(tbLogin.Text, tbPassword.Text);
            switch (DBConnection.IDuser)
            {
                case (0):
                    tbLogin.BorderColor = System.Drawing.Color.Red;
                    tbPassword.BorderColor = System.Drawing.Color.Red;
                    tbPassword.Text = "";
                    tbLogin.Text = "";
                    break;
                default:
                    Response.Redirect("~/Forms/MainPage.aspx");
                    break;
            }
        }

        protected void btnPasswordRecovery_Click(object sender, EventArgs e)
        {
            var Password = GetPass();
            int port = 587;
            bool enableSSL = true;

            DBConnection connection = new DBConnection();
            connection.dbEmail(tbEmail.Text);
            connection.dbLogin();
            SqlCommand command = new SqlCommand("", DBConnection.connection);
            command.CommandText = "update [dbo].[Authorization] set " +
              "[Password] = '" + Password + "' " +
              " where ID_Authorization = " + DBConnection.IDusers + "";
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
            Page_Load(sender, e);
            gvFill(QR);

            string emailFrom = "mpt.bot@bk.ru";
            string password = "SeregaGame123g123lol";
            string emailTo = tbEmail.Text;
            string subject = "Восстановление пароля";
            string log = "Ваш логин: " + DBConnection.Login;
            string pass = "Ваш новый пароль: " + Password;
            string smtpAddress = "smtp.mail.ru";

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(emailFrom);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = log + "\r\n" + pass;
            mail.IsBodyHtml = false;

            using (SmtpClient smtp = new SmtpClient(smtpAddress, port))
            {
                smtp.Credentials = new NetworkCredential(emailFrom, password);
                smtp.EnableSsl = enableSSL;
                smtp.Send(mail);
            }
        }
    }
}