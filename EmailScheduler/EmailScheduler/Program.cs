using System;
using EmailScheduler.Model;
using EmailScheduler.DataContext;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;




using System.Net;
using System.Net.Mail;


using System.Data;
using System.IO;

namespace EmailScheduler
{
    class Program
    {
        SqlConnection sqlCon = null;
        String SqlconString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

        static void Main(string[] args)
        {
            Program pm = new Program();
            using (var result = new ApplicationDbContext())
            {
                List<Tbl_Admin> data = result.tbl_admin.ToList();
                

            }


            //pm.Test();

            pm.bttn_Send_Click();
            Console.ReadLine();
        }

        

        public void Test()
        {
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("USP_GetSampleData", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@IsActive", SqlDbType.Bit).Value = true;
                sql_cmnd.Parameters.AddWithValue("@UserId", SqlDbType.Int).Value = 11;
                SqlDataReader reader =  sql_cmnd.ExecuteReader();

                while (reader.Read())
                {
                    Console.Write(reader[0].ToString());
                    Console.Write(reader[1].ToString());
                    Console.WriteLine(reader[2].ToString());
                }
                Console.Read();
                reader.Close();
                sqlCon.Close();


            }
        }


        public void bttn_Send_Click()
        {

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("noreplyehstesting78@gmail.com.com");
                mail.To.Add("devpranayc@outlook.com");
                mail.Subject = "Hello World";
                mail.Body = "<h1>Hello</h1>";
                mail.IsBodyHtml = true;
                
                string filePath = "P:\\downloads\\1653625128_traineesforaonla.pdf";
      
                string fileName = Path.GetFileName(filePath);
                byte[] bytes = File.ReadAllBytes(filePath);
                mail.Attachments.Add(new Attachment(new MemoryStream(bytes), fileName));
              
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("noreplyehstesting78@gmail.com", "cntpraqgsaqjlxpi");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
