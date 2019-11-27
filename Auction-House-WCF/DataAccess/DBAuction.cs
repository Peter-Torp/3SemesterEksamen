﻿using Auction_House_WCF.DataAccess.Interfaces;
using Auction_House_WCF.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Auction_House_WCF.DataAccess
{
    public class DBAuction : ICRUD<AuctionData>
    {
        private string _connectionString;

        public DBAuction()
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

        public int Create(AuctionData entity)
        {
            // Set return value
            entity.Id = -1;

            //Set isolation level
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.Serializable
            };

            //SQL statements
            string getUser = "SELECT * FROM Person WHERE UserName = @userName";
            string getCategory = "SELECT * FROM Category WHERE Name = @category";
            string insertAuction = "INSERT INTO Auction (StartPrice, BuyOutPrice, BidInterval, Description, StartDate, EndDate, Category_Id, User_Id) " +
"               Values(@startPrice, @buyOutPrice, @bidInterval, @description, @startDate, @endDate, @cat_Id, @user_Id)";


            //Transaction
            using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    try
                    {
                        //Open connection to database.
                        conn.Open();

                        int user_Id = -1;
                        using (var cmdGUser = new SqlCommand(getUser, conn))
                        {
                            cmdGUser.Parameters.AddWithValue("userName", entity.UserName);
                            SqlDataReader reader = cmdGUser.ExecuteReader();
                                while (reader.Read())
                                {
                                    user_Id = Convert.ToInt32(reader["Id"]);
                                }
                            reader.Close();
                        }

                        int cat_Id = -1;
                        using (var cmdGCat = new SqlCommand(getCategory, conn))
                        {
                            cmdGCat.Parameters.AddWithValue("category", entity.Category);
                            SqlDataReader reader = cmdGCat.ExecuteReader();
                            while (reader.Read())
                            {
                                cat_Id = Convert.ToInt32(reader["Cat_Id"]);
                            }
                            reader.Close();
                        }

                        using (var cmdIAuction = new SqlCommand(insertAuction, conn))
                        {
                            cmdIAuction.Parameters.AddWithValue("startPrice", entity.StartPrice);
                            cmdIAuction.Parameters.AddWithValue("buyOutPrice", entity.BuyOutPrice);
                            cmdIAuction.Parameters.AddWithValue("bidInterval", entity.BidInterval);
                            cmdIAuction.Parameters.AddWithValue("description", entity.Description);
                            cmdIAuction.Parameters.AddWithValue("startDate", entity.StartDate);
                            cmdIAuction.Parameters.AddWithValue("endDate", entity.EndDate);
                            cmdIAuction.Parameters.AddWithValue("cat_Id", cat_Id); // Get category id.
                            cmdIAuction.Parameters.AddWithValue("user_Id", user_Id); // Get user id.
                            entity.Id = (int)Convert.ToInt32(cmdIAuction.ExecuteScalar());
                        }


                        //If everything went well, will commit.
                            scope.Complete();
                    }
                    catch (TransactionAbortedException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        scope.Dispose();
                    }
                }
            }
            return entity.Id;
        }

        public AuctionData Get(int id)
        {
            throw new NotImplementedException();
        }


    }
}
