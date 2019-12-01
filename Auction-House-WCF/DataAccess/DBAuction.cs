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
                            if (user_Id == -1)
                            {
                                scope.Dispose();
                                throw new TransactionAbortedException(("Username not found " + user_Id.ToString()));
                            }
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
                            if (cat_Id == -1)
                            {
                                scope.Dispose();
                                throw new TransactionAbortedException(("Username not found " + cat_Id.ToString()));
                            }
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

        public bool InsertPictures(List<ImageData> images)
        {
            bool successful = false;

            //Set isolation level
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.Serializable
            };

            string insertImage = "INSERT INTO Image (Auction_Id, Img_URL, DateAdded, Description, Name) VALUES(@auctionId,@imgUrl,@dateAdded, @description, @name)";

            //Transaction
            using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    try
                    {
                        //Open connection to database.
                        conn.Open();

                        foreach (ImageData image in images)
                        {
                            using (var cmdIImage = new SqlCommand(insertImage, conn))
                            {
                                cmdIImage.Parameters.AddWithValue("auctionId", image.AuctionId);
                                cmdIImage.Parameters.AddWithValue("imgUrl", image.ImgUrl);
                                cmdIImage.Parameters.AddWithValue("dateAdded", image.DateAdded);
                                cmdIImage.Parameters.AddWithValue("description", image.Description);
                                cmdIImage.Parameters.AddWithValue("name", image.FileName);

                                cmdIImage.ExecuteScalar();
                            }
                        }

                        ImageHandler iHandler = new ImageHandler();
                        bool succsesful = iHandler.InsertPicturesToFolder(images);
                        if (!succsesful)
                        {
                            scope.Dispose();
                            return successful = false;
                        }


                        //If everything went well, will commit.
                        scope.Complete();
                    }
                    catch (TransactionAbortedException e)
                    {
                        successful = false;
                        throw e;
                    }
                    finally
                    {
                        scope.Dispose();
                    }
                }
            }
            return successful;
        }

        public AuctionData Get(int auctionId)
        {
            //Set isolation level
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.Serializable
            };

            // SQL query
            string getAuctions = "SELECT A.Id, P.UserName, A.StartPrice, A.BuyOutPrice, A.BidInterval, A.Description, A.StartDate, A.EndDate, C.Name, A.Id " +
                "FROM Auction AS A " +
                "INNER JOIN Category AS C ON A.Category_Id = C.Cat_Id " +
                "INNER JOIN Person AS P ON A.User_Id = P.Id " +
                "WHERE A.Id = @auctionId";

            //Create return Object
            AuctionData auctionData = new AuctionData();

            //Create transaction.
            using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    try
                    {
                        //Open connection to database.
                        conn.Open();
                        using (var cmdGAuctions = new SqlCommand(getAuctions, conn))
                        {
                            cmdGAuctions.Parameters.AddWithValue("auctionId", auctionId);
                            SqlDataReader reader = cmdGAuctions.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    auctionData = ToObject(reader.GetInt32(0), reader.GetString(1), reader.GetString(5),
                                       reader.GetString(8), reader.GetDateTime(6), reader.GetDateTime(7), reader.GetDouble(2),
                                       reader.GetDouble(4), reader.GetDouble(3));
                                }
                            }
                            reader.Close();
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
            return auctionData;
        }

        public List<AuctionData> GetUserAuctions(string userName)
        {
            //Set isolation level
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.Serializable
            };

            // SQL query
            string getAuctions = "SELECT A.Id, P.UserName, A.StartPrice, A.BuyOutPrice, A.BidInterval, A.Description, A.StartDate, A.EndDate, C.Name " +
                "FROM Auction AS A " +
                "INNER JOIN Category AS C ON A.Category_Id = C.Cat_Id " +
                "INNER JOIN Person AS P ON A.User_Id = P.Id " +
                "WHERE UserName = @userName";

            //Create auctions list to return.
            List<AuctionData> auctions = new List<AuctionData>();

            //Create transaction.
            using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    try
                    {
                        //Open connection to database.
                        conn.Open();
                        using (var cmdGAuctions = new SqlCommand(getAuctions, conn))
                        {
                            cmdGAuctions.Parameters.AddWithValue("userName", userName);
                            SqlDataReader reader = cmdGAuctions.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    AuctionData auctionData = ToObject(reader.GetInt32(0), reader.GetString(1), reader.GetString(5),
                                       reader.GetString(8), reader.GetDateTime(6), reader.GetDateTime(7), reader.GetDouble(2),
                                       reader.GetDouble(4), reader.GetDouble(3));
                                    auctions.Add(auctionData);
                                }
                            }
                            reader.Close();
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
            return auctions;
        }

        private AuctionData ToObject(int auctionId, string userName, string description, string category,
            DateTime startDate, DateTime endDate, double startPrice, double bidInterval, double buyOutPrice)
        {
            AuctionData auction = new AuctionData
            {
                Id = auctionId,
                UserName = userName,
                Description = description,
                Category = category,
                StartDate = startDate,
                EndDate = endDate,
                StartPrice = startPrice,
                BidInterval = bidInterval,
                BuyOutPrice = buyOutPrice
            };
            return auction;
        }
        /*
         * Return a list of auction selected from the database.
         * */
        internal List<AuctionData> GetAuctions(string auctionName)
        {
            List<AuctionData> auctionDatas = new List<AuctionData>();
            string getAuctions = "SELECT * FROM Auction WHERE something something = ?";//ret

            using (var conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();

                    using (var DBAuctions = new SqlCommand(getAuctions, conn))
                    {

                        DBAuctions.Parameters.AddWithValue("auctionName", auctionName);


                        SqlDataReader reader = DBAuctions.ExecuteReader();

                        while (reader.Read())
                        {
                            AuctionData auction = new AuctionData
                            {
                                Id = reader.GetInt32(1),
                                StartPrice = reader.GetDouble(2),
                                BuyOutPrice = reader.GetDouble(3),
                                BidInterval = reader.GetDouble(4),
                                Description = reader.GetString(5),
                                StartDate = reader.GetDateTime(6),
                                EndDate = reader.GetDateTime(7),
                                Category = reader.GetString(8), //category id (SQL)
                                UserId = reader.GetInt32(9)

                            };
                            auctionDatas.Add(auction);
                        }

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
                return auctionDatas;
            }


        }
    }
}
