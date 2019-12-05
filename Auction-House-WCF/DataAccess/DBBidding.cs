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
    class DBBidding : ICRUD<BidData>
    {
        private string _connectionString;
        public DBBidding()
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

        public List<BidData> GetBids(int id)
        {
            //Set isolation level
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            };

            // SQL query
            string getBids =
                "SELECT B.Bid_Id, B.Auction_Id, B.User_Id, B.Date, B.Amount, P.UserName " +
                "FROM Bid AS B " +
                "INNER JOIN Person AS P ON B.User_Id = P.Id " +
                "WHERE B.Auction_Id = @auctionId " +
                "ORDER BY B.Amount DESC";

            //Create bids list to return.
            List<BidData> bidData = new List<BidData>();

            //Create transaction.
            using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    try
                    {
                        //Open connection to database.
                        conn.Open();
                        using (var cmdGBids = new SqlCommand(getBids, conn))
                        {
                            cmdGBids.Parameters.AddWithValue("auctionId", id);
                            SqlDataReader reader = cmdGBids.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    BidData bid = ToObject(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
                                        reader.GetDateTime(3), Convert.ToDouble(reader.GetDouble(4)), reader.GetString(5));
                                    bidData.Add(bid);
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
            return bidData;
        }

        public BidData ToObject(int bidId, int auctionId, int userId, DateTime date, double amount, string userName)
        {
            BidData bidData = new BidData()
            {
                Bid_Id = bidId,
                Auction_Id = auctionId,
                User_Id = userId,
                Amount = amount,
                Date = date,
                UserName = userName
            };
            return bidData;
        }

        public double GetMaxBidOnAuction(int auctionId)
        {
            string getMaxBid = "SELECT MAX(B.Amount) " +
                "FROM Bid AS B " +
                "WHERE B.Auction_Id = @auctionId";

            double maxBid = -1;

            using (var conn = new SqlConnection(_connectionString))
            {
                try
                {
                    //Open connection to database.
                    conn.Open();
                    using (var cmdGMaxBid = new SqlCommand(getMaxBid, conn))
                    {
                        cmdGMaxBid.Parameters.AddWithValue("auctionId", auctionId);
                        SqlDataReader reader = cmdGMaxBid.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                               maxBid = reader.GetDouble(0);
                            }
                        }
                        reader.Close();
                    }
                    conn.Close();
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
            return maxBid;
        }

        /// <summary>
        /// Inserts a bid in database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Create(BidData entity)
        {
            //Set isolation level
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.Serializable
            };

            // SQL query
            string insertBid =
                "INSERT INTO Bid (Auction_Id, User_Id, Date,Amount) " +
                "VALUES(@auctionId, @userId, @date, @amount)";
            string getUser = "SELECT Id FROM Person WHERE UserName = @userName";

            //Create transaction.
            using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    try
                    {
                        //Open connection to database.
                        conn.Open();



                        entity.User_Id = -1;
                        using (var cmdGUser = new SqlCommand(getUser, conn))
                        {
                            cmdGUser.Parameters.AddWithValue("userName", entity.UserName);
                            SqlDataReader reader = cmdGUser.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    entity.User_Id = reader.GetInt32(0);
                                }
                            }
                            reader.Close();
                        }
                        if (entity.User_Id == -1)
                        {
                            scope.Dispose();
                        }

                        using (var cmdIBid = new SqlCommand(insertBid, conn))
                        {
                            cmdIBid.Parameters.AddWithValue("auctionId", entity.Auction_Id);
                            cmdIBid.Parameters.AddWithValue("userId", entity.User_Id);
                            cmdIBid.Parameters.AddWithValue("date", entity.Date);
                            cmdIBid.Parameters.AddWithValue("amount", entity.Amount);
                            entity.Bid_Id = (int)Convert.ToInt32(cmdIBid.ExecuteScalar());
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
            return entity.Bid_Id;
        }

        public BidData Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}