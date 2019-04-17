using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection ...");
            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                conn.Open();
                Console.WriteLine("Connection successful!");
                //query(conn);

                //string sql = "insert into info values (@fname, @address, @age) ";
                //string sql = "update info set fname=@nname where age=15 ";
                string sql = "delete from info where age=15 ";
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                /*cmd.Parameters.AddWithValue("@fname", "hsdsi");
                cmd.Parameters.AddWithValue("@address", "sjds");
                cmd.Parameters.AddWithValue("@age", 15);*/
                //cmd.Parameters.AddWithValue("@nname","agarwal");

                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();
        }
        private static void query(MySqlConnection conn)
        {
            string sql = "Select * from info";

            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sql;


            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        Console.WriteLine("--------------------");
                        Console.WriteLine("empIdIndex:" + reader.GetValue(0));
                        Console.WriteLine("EmpId:" + reader.GetValue(1));
                        Console.WriteLine("EmpNo:" + reader.GetValue(2));
                    }
                }
            }
        }
    }
}
