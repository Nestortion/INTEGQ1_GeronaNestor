using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace OnlineShopping
{
    public class SqlData
    {
        static string connString = "datasource = localhost; username = root; password = ;database = online_shopping";
        private static MySqlConnection conn = new MySqlConnection(connString);
        public void connectDB()
        {
            
            
        }
        static public string DisplayName(string category)
        {
            string query = $"SELECT `category` FROM `availableproducts` WHERE category = \"{category}\" ";
            conn.Open();
            string name = "";
            MySqlCommand view = new MySqlCommand(query, conn);
            MySqlDataReader rdr = view.ExecuteReader();
            while (rdr.Read())
            {
                name = rdr[0].ToString();
            }
            conn.Close();
            return name;

            
        }
        static public int DisplayStocks(string productCategory, string brand)
        {
            string query = $"SELECT `stocks` FROM `availableproducts` WHERE category = \"{productCategory}\" AND brand = \"{brand}\" ";
            conn.Open();
            int stocks = 0;
            MySqlCommand view = new MySqlCommand(query, conn);
            MySqlDataReader rdr = view.ExecuteReader();
            while (rdr.Read())
            {
                stocks += Convert.ToInt32(rdr[0]);
                
            }
            conn.Close();
            return stocks;
        }
        static public int DisplayPrice(string productCategory, string brand)
        {
            string query = $"SELECT `price` FROM `availableproducts` WHERE category = \"{productCategory}\" AND brand = \"{brand}\" ";
            conn.Open();
            int price = 0;
            MySqlCommand view = new MySqlCommand(query, conn);
            MySqlDataReader rdr = view.ExecuteReader();
            while (rdr.Read())
            {
                price += Convert.ToInt32(rdr[0]);

            }
            conn.Close();
            return price;
        }
        static public bool VerifyUser(string username, string password)
        {
            string query = $"SELECT * FROM `users` WHERE username = \"{username}\" AND password = \"{password}\"";
            conn.Open();
            MySqlCommand view = new MySqlCommand(query, conn);
            MySqlDataReader rdr = view.ExecuteReader();
            
            if (rdr.Read())
            {
                
                CheckOut.username = rdr[0].ToString();
                CheckOut.credits = Convert.ToInt32(rdr[2]);
                conn.Close();
                return true;

            }
            else
            {
                conn.Close();
                return false;
                
            }
            
            
        }
        static public bool UpdateCredits(int amount, string user)
        {
            string sql = $"UPDATE `users` SET `credits`=\'{amount}\' WHERE username = \"{user}\"";
            MySqlCommand update = new MySqlCommand(sql, conn);
            conn.Open();
            update.ExecuteNonQuery();
            if(update.ExecuteNonQuery() == 1)
            {
                
                conn.Close();
                return true;
            }
            else
            {
                Console.WriteLine("Purchase Failed");
                conn.Close();
                return false;
            }
            
        }
       
        

    }
}
