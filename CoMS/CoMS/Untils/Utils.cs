using CoMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CoMS.Entities_Framework;
using CoMS.Resources;
using System.Text;
using CoMS.Untils;
using System.Configuration;
using System.Net.Mail;

namespace CoMS.Untils
{
    public class Utils
    {
        //Kiểm tra có đúng định dạng hay không
        //True là đúng, false là không đúng
        public static bool IsValidEmail(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Tách họ và tên
        //Vị trí mảng thứ 0 là họ, 1 là chữ lót, 2 là tên
        public static string[] GetFirstMiddleLastName(string fullName)
        {
            var names = fullName.Split(' ');
            string first = null;
            string last = null;
            string midle = null;
            int length = names.Length;
            if (length == 1)
            {
                first = names[0];
            }
            else if (length == 2)
            {
                first = names[0];
                last = names[1];
            }
            else if (length > 2)
            {
                first = names[0];
                last = names[length - 1];
                for (int i = 1; i < length - 1; i++)
                {
                    if (i == 1)
                    {
                        midle += names[i];
                    }
                    else
                    {
                        midle += " " + names[i];
                    }
                }
            }

            return new string[] { first, midle, last };
        }

        //Lấy họ tên đầy đủ
        public static string GetFullName(string firstName, string middleName, string lastName)
        {
            string fullName = null;
            if (!string.IsNullOrEmpty(firstName))
            {
                fullName += firstName.Trim();
            }
            if (!string.IsNullOrEmpty(middleName))
            {
                fullName += " " + middleName.Trim();
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                fullName += " " + lastName.Trim();
            }
            return fullName.Trim();
        }

        //Gửi email
        public static void SendEmail(string toEmailAdress, string subject, string content)
        {
            var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
            var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
            var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();
            bool enableSsl = bool.Parse(ConfigurationManager.AppSettings["EnableSSL"].ToString());

            string body = content;

            MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAdress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            client.Host = smtpHost;
            client.EnableSsl = enableSsl;
            client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
            client.Send(message);
        }

        
    }
}