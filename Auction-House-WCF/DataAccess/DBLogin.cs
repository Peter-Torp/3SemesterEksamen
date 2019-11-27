using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction_House_WCF.Models;

namespace Auction_House_WCF.DataAccess
{
    public class DBLogin
    {
        static string _connectionString = null;

        public DBLogin()
        {
            try
            {
                _connectionString = ConfigurationManager.ConnectionStrings["KrakaDB"].ConnectionString;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        internal Login GetPassword(int person_id)        
        {
            Login login = new Login(null, null);
            const string getPasswordInfoQuery = "SELECT * FROM password WHERE Person_id =?";

            
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmdILogin = new SqlCommand(getPasswordInfoQuery, conn))      //query command + connection
                {
                    try
                    {
                        cmdILogin.Parameters.AddWithValue("Person_id", person_id);  //query string id
                        SqlDataReader reader = cmdILogin.ExecuteReader();       //execute query

                        if (reader.Read())
                        {
                            login = new Login(reader.GetString(1), reader.GetString(2));        //column 2 + 3
                        }
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }

                    finally
                    {
                        if (conn != null)
                        {
                            conn.Close();
                        }
                    }

                    
                }

                
            }

            return login;

        }


    }
}
