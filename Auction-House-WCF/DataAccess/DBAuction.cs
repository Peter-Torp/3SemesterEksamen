using Auction_House_WCF.DataAccess.Interfaces;
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

        /// <summary>
        /// Creates an auction in database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Create(AuctionData entity)
        {
            // Set return value
            entity.Id = -1;

            //Set isolation level
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted
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

        /// <summary>
        /// Inserts pictures into database and folders. 
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        public bool InsertPictures(List<ImageData> images)
        {
            bool successful = false;

            //Set isolation level
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            };

            string insertImage = "INSERT INTO Image (Auction_Id, Img_URL, DateAdded, Description, Name) " +
                "VALUES(@auctionId,@imgUrl,@dateAdded, @description, @name)";

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

        /// <summary>
        /// Gets an auction by Id
        /// </summary>
        /// <param name="auctionId"></param>
        /// <returns></returns>
        public AuctionData Get(int auctionId)
        {
            //Set isolation level
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            };

            // SQL query
            string getAuctions = "SELECT A.Id, P.UserName, A.StartPrice, A.BuyOutPrice, A.BidInterval, A.Description, A.StartDate, A.EndDate, C.Name, U.ZipCode, R.Region " +
                "FROM Auction AS A " +
                "INNER JOIN Category AS C ON A.Category_Id = C.Cat_Id " +
                "INNER JOIN Person AS P ON A.User_Id = P.Id " +
                "INNER JOIN Users AS U ON A.User_Id = U.User_Id " +
                "INNER JOIN Region AS R ON U.ZipCode = R.ZipCode " +
                "WHERE A.Id = @auctionId";

            //Create return Object
            AuctionData auctionData = new AuctionData();
            bool auctionFound = true;

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
                                       reader.GetDouble(4), reader.GetDouble(3), reader.GetString(9), reader.GetString(10));
                                }
                            } else
                            {
                                auctionFound = false;
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
            if (auctionFound)
            {
                return auctionData;
            } else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets categories.
        /// </summary>
        /// <returns></returns>
        public List<string> GetCategory()
        {
            //Set isolation level
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            };

            // SQL query
            string getCategories = "SELECT * FROM Category";

            //Create auctions list to return.
            List<string> categories = new List<string>();

            //Create transaction.
            using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    try
                    {
                        //Open connection to database.
                        conn.Open();
                        using (var cmdGAuctions = new SqlCommand(getCategories, conn))
                        {
                            SqlDataReader reader = cmdGAuctions.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    categories.Add(reader.GetString(1));
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
            return categories;
        }

        /// <summary>
        /// Get user auctions by user name.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<AuctionData> GetUserAuctions(string userName)
        {
            //Set isolation level
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            };

            // SQL query
            string getAuctions = "SELECT A.Id, P.UserName, A.StartPrice, A.BuyOutPrice, A.BidInterval, A.Description, A.StartDate, A.EndDate, C.Name, U.ZipCode, R.Region " +
                "FROM Auction AS A " +
                "INNER JOIN Category AS C ON A.Category_Id = C.Cat_Id " +
                "INNER JOIN Person AS P ON A.User_Id = P.Id " +
                "INNER JOIN Users AS U ON A.User_Id = U.User_Id " +
                "INNER JOIN Region AS R ON U.ZipCode = R.ZipCode " +
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
                                       reader.GetDouble(4), reader.GetDouble(3),reader.GetString(9), reader.GetString(10));
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

        /// <summary>
        /// Makes an object of AuctionData from parameters.
        /// </summary>
        /// <returns>AuctionData</returns>
        private AuctionData ToObject(int auctionId, string userName, string description, string category,
            DateTime startDate, DateTime endDate, double startPrice, double bidInterval, double buyOutPrice, 
            string zipCode, string region)
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
                BuyOutPrice = buyOutPrice,
                ZipCode = zipCode,
                Region = region
            };
            return auction;
        }

        /// <summary>
        /// Makes an object of ImageInfoData.
        /// </summary>
        /// <returns>ImageInfoData</returns>
        private ImageInfoData ToImageInfoObject(int auctionId, string imgUrl, DateTime dateAdded,
            string description, string fileName)
        {
            ImageInfoData imageInfoData = new ImageInfoData
            {
                AuctionId = auctionId,
                ImgUrl = imgUrl,
                DateAdded = dateAdded,
                Description = description,
                FileName = fileName
            };
            return imageInfoData;
        }

        /// <summary>
        /// Get images from database.
        /// </summary>
        /// <param name="auctionId"></param>
        /// <returns></returns>
        public List<ImageInfoData> GetImages(int auctionId)
        {
            //Set isolation level
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            };

            // SQL query
            string getAuctions = "SELECT * FROM Image WHERE Auction_Id = @auctionId";

            //Create auctions list to return.
            List<ImageInfoData> images = new List<ImageInfoData>();

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
                                    ImageInfoData imageInfoData = ToImageInfoObject(reader.GetInt32(1), reader.GetString(2), reader.GetDateTime(3),
                                        reader.GetString(4), reader.GetString(5));
                                    images.Add(imageInfoData);
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
            return images;
        }

        /// <summary>
        /// Gets the 10 latest auctions.
        /// </summary>
        /// <returns>List<AuctionData></returns>
        public List<AuctionData> GetLastestAuctions()
        {
            //Set isolation level
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            };

            // SQL query
            string getLatestAuctions = "SELECT TOP 10 " +
                "A.Id, P.UserName, A.StartPrice, A.BuyOutPrice, A.BidInterval, A.Description, A.StartDate, A.EndDate, C.Name, U.ZipCode, R.Region " +
                "FROM Auction AS A " +
                "INNER JOIN Category AS C ON A.Category_Id = C.Cat_Id " +
                "INNER JOIN Person AS P ON A.User_Id = P.Id " +
                "INNER JOIN Users AS U ON A.User_Id = U.User_Id " +
                "INNER JOIN Region AS R ON U.ZipCode = R.ZipCode " +
                "ORDER BY A.StartDate DESC";

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
                        using (var cmdGAuctions = new SqlCommand(getLatestAuctions, conn))
                        {
                            SqlDataReader reader = cmdGAuctions.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    AuctionData auctionData = ToObject(reader.GetInt32(0), reader.GetString(1), reader.GetString(5),
                                       reader.GetString(8), reader.GetDateTime(6), reader.GetDateTime(7), reader.GetDouble(2),
                                       reader.GetDouble(4), reader.GetDouble(3), reader.GetString(9), reader.GetString(10));
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

        /// <summary>
        /// Get auctions by description. Used for searching auctions.
        /// </summary>
        /// <param name="auctionDesc"></param>
        /// <returns></returns>
        public List<AuctionData> GetAuctionsByDescription(string auctionDesc)
        {
            //Set isolation level
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            };

            // SQL query
            string getLatestAuctions = "SELECT " +
                "A.Id, P.UserName, A.StartPrice, A.BuyOutPrice, A.BidInterval, A.Description, A.StartDate, A.EndDate, C.Name, U.ZipCode, R.Region " +
                "FROM Auction AS A " +
                "INNER JOIN Category AS C ON A.Category_Id = C.Cat_Id " +
                "INNER JOIN Person AS P ON A.User_Id = P.Id " +
                "INNER JOIN Users AS U ON A.User_Id = U.User_Id " +
                "INNER JOIN Region AS R ON U.ZipCode = R.ZipCode " +
                "WHERE A.Description LIKE @auctionDesc " +
                "ORDER BY A.StartDate DESC";

            //Create auctions list to return.
            List<AuctionData> auctions = new List<AuctionData>();

            string stringFormat = "%" + auctionDesc + "%";
            //Create transaction.
            using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    try
                    {
                        //Open connection to database.
                        conn.Open();
                        using (var cmdGAuctions = new SqlCommand(getLatestAuctions, conn))
                        {
                            cmdGAuctions.Parameters.AddWithValue("auctionDesc", stringFormat);
                            SqlDataReader reader = cmdGAuctions.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    AuctionData auctionData = ToObject(reader.GetInt32(0), reader.GetString(1), reader.GetString(5),
                                       reader.GetString(8), reader.GetDateTime(6), reader.GetDateTime(7), reader.GetDouble(2),
                                       reader.GetDouble(4), reader.GetDouble(3),reader.GetString(9), reader.GetString(10));
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

        //Delete an auction
        internal bool DeleteAuctionById(int id)
        {
            bool successful = false;
            var options = new TransactionOptions
            {
               IsolationLevel = IsolationLevel.RepeatableRead
            };

            ImageHandler imageHandler = new ImageHandler();

            bool deleted = false;
            //queries statements
            string deleteAuction = "DELETE FROM Auction WHERE id = @Id";
            string deleteImage = "DELETE FROM Image WHERE Auction_Id = @Id";
            string deleteBid = "DELETE FROM Bid WHERE Auction_Id = @Id";
            string getUser = "SELECT User_id FROM Auction WHERE id = @Id"; 

            using (var scope = new TransactionScope(TransactionScopeOption.Required, options)) {

                using (var conn = new SqlConnection(_connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (var scopeGetAndCalc = new TransactionScope(TransactionScopeOption.Required, options)) 
                        {
                            using (var DBAuction = new SqlCommand(getUser,conn))
                            {
                                int user_id = 0;
                                DBAuction.Parameters.AddWithValue("@Id", id);
                                SqlDataReader reader = DBAuction.ExecuteReader();

                                while (reader.Read())
                                {
                                    user_id = reader.GetInt32(0);
                                }
                                reader.Close();
                                imageHandler.DeleteAuctionFolder(id,user_id);   //delete auctionfolder with images
                            }

                            using (var DBAuction = new SqlCommand(deleteImage, conn))
                            {
                                DBAuction.Parameters.AddWithValue("@Id", id);
                                DBAuction.ExecuteNonQuery();
                            }

                            using (var DBAuction = new SqlCommand(deleteBid, conn))
                            {
                                DBAuction.Parameters.AddWithValue("@Id", id);
                                DBAuction.ExecuteNonQuery();
                            }
                            using (var DBAuctions = new SqlCommand(deleteAuction, conn))
                            {   //add the @Id and the id value from the parameters
                                DBAuctions.Parameters.AddWithValue("@Id", id);

                                DBAuctions.ExecuteNonQuery();
  
                            }

                            scopeGetAndCalc.Complete(); //close nested transaction
                            successful = true;
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                scope.Complete();//close whole transaction
            }

            return successful;
        }


        public List<AuctionData> GetAllAuctions()
        {
            List<AuctionData> auctionData = new List<AuctionData>();
            string getAllAuctionsDB = "SELECT * FROM Auction FULL OUTER JOIN Person ON Auction.User_Id = Person.Id " +
                                    "FULL OUTER JOIN Category ON Auction.Category_Id = Category.Cat_Id";

            

            using (var conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();

                    using (var DBAuctions = new SqlCommand(getAllAuctionsDB, conn))
                    {
                        DBAuctions.Parameters.AddWithValue("getAllAuctions", getAllAuctionsDB);

                        SqlDataReader reader = DBAuctions.ExecuteReader();

                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(1)) {
                                AuctionData auction = new AuctionData
                                {
                                    Id = reader.GetInt32(0),
                                    StartPrice = reader.GetDouble(1),
                                    BuyOutPrice = reader.GetDouble(2),
                                    BidInterval = reader.GetDouble(3),
                                    Description = reader.GetString(4),
                                    StartDate = reader.GetDateTime(5),
                                    EndDate = reader.GetDateTime(6),
                                    UserId = reader.GetInt32(8),
                                    UserName = reader.GetString(10),
                                    Category = reader.GetString(14),
                                };
                                auctionData.Add(auction);
                            } 
                            
                        }
                        conn.Close();
                    }
                }
                catch (Exception e)
                {
                    conn.Close();
                    throw e;
                }
            }

                return auctionData;
        }




    }
}
