using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;

namespace WebApplication.Forms
{
    public partial class Feedback : System.Web.UI.Page
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
            sdsEmployee.ConnectionString = DBConnection.connection.ConnectionString.ToString();
            sdsEmployee.SelectCommand = qr;
            sdsEmployee.DataSourceMode = SqlDataSourceMode.DataReader;
        }

        protected void btSend_Click(object sender, EventArgs e)
        {
            int port = 587;
            bool enableSSL = true;

            string emailFrom = "mpt.bot@bk.ru";
            string password = "SeregaGame123g123lol";
            string emailTo = "i_s.a.mitrohin@mpt.ru";
            string subject = dlReason.Text;
            string name = "ФИО сотрудника: " + tbFull_Name.Text;
            string email = "Почта: " + tbMail.Text;
            string message = "Текст сообщения: " + tbMessage.Text;
            string smtpAddress = "smtp.mail.ru";

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(emailFrom);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = name + "\r\n" + email + "\r\n" + message;
            mail.IsBodyHtml = false;

            using (SmtpClient smtp = new SmtpClient(smtpAddress, port))
            {
                smtp.Credentials = new NetworkCredential(emailFrom, password);
                smtp.EnableSsl = enableSSL;
                smtp.Send(mail);
            }
        }

        protected void btSend_Click1(object sender, EventArgs e)
        {
            DBConnection connection = new DBConnection();
            connection.dbFeedback();
            tbMail.Text = DBConnection.eMail;
        }
    }
}