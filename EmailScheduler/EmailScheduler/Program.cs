using System;
using EmailScheduler.Model;
using EmailScheduler.DataContext;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;

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


            pm.Test();
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
    }
}
