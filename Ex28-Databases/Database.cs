using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Ex28_Databases
{
    class Database
    {
        private static string connectionString = "Server=EALSQL1.eal.local; Database = B_DB02_2018; User Id = B_STUDENT02; Password = B_OPENDB02;";


        internal void InsertPet(string PetName, string PetType, string PetBreed, DateTime Birth, double PetWeight, int OwnerPK)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                    SqlCommand insertPet = new SqlCommand("INSERT INTO PET "
                        + "(PetName, PetType, PetBreed, PetDOB, PetWeight, OwnerPK) "
                        + "VALUES(@PetName, @PetType, @PetBreed, @PetDOB, @PetWeight, @OwnerPK)", con);

                    insertPet.Parameters.Add("@PetName", System.Data.SqlDbType.NVarChar);
                    insertPet.Parameters.Add("@PetType", System.Data.SqlDbType.NVarChar);
                    insertPet.Parameters.Add("@PetBreed", System.Data.SqlDbType.NVarChar);
                    insertPet.Parameters.Add("@PetDOB", System.Data.SqlDbType.DateTime2);
                    insertPet.Parameters.Add("@PetWeight", System.Data.SqlDbType.Float);
                    insertPet.Parameters.Add("@OwnerPK", System.Data.SqlDbType.Int);

                    insertPet.Parameters["@PetName"].Value = PetName;
                    insertPet.Parameters["@PetType"].Value = PetType;
                    insertPet.Parameters["@PetBreed"].Value = PetBreed;
                    insertPet.Parameters["@PetDOB"].Value = Birth;
                    insertPet.Parameters["@PetWeight"].Value = PetWeight;
                    insertPet.Parameters["@OwnerPK"].Value = OwnerPK;

                    con.Open();

                    insertPet.ExecuteNonQuery();
            }
        }

        internal List<List<string>> GetPets(int id)
        {
            List<List<string>> returnlist = new List<List<string>>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand OwnerId = new SqlCommand("spOwnerID", con);
                OwnerId.CommandType = CommandType.StoredProcedure;
                OwnerId.Parameters.AddWithValue("@OwnerId", id);

                SqlDataReader reader = OwnerId.ExecuteReader();
                while (reader.Read())
                {
                    List<string> listtoadd = new List<string>();
                    listtoadd.Add("Lastname: " + reader[0].ToString());
                    listtoadd.Add("FirstName: " + reader[1].ToString());
                    listtoadd.Add("Pet Name: " + reader[2].ToString());
                    listtoadd.Add("Pet Type: " + reader[3].ToString());
                    listtoadd.Add("Pet Breed: " + reader[4].ToString());
                    listtoadd.Add("AverageLifeExpectancy: " + reader[5].ToString());

                    returnlist.Add(listtoadd);
                }

            }
            return returnlist;
        }

        internal List<string> GetOwnerByEmail(string email)
        {
            List<string> returnlist = new List<string>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand FindEmail = new SqlCommand("spGetOwnerByEmail", con);
                FindEmail.CommandType = CommandType.StoredProcedure;
                FindEmail.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = FindEmail.ExecuteReader();
                while (reader.Read())
                {
                    returnlist.Add("Last Name: " + reader[0].ToString());
                    returnlist.Add("First Name: " + reader[1].ToString());
                    returnlist.Add("PhoneNumber: " + reader[2].ToString());
                    returnlist.Add("Email: " + reader[3].ToString());
                }

            }
            return returnlist;
        }

        internal List<string> GetOwnerByLastName(string lastname)
        {
            List<string> returnlist = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand FindLastName = new SqlCommand("spGetOwnerByLastName", con);
                FindLastName.CommandType = CommandType.StoredProcedure;
                FindLastName.Parameters.AddWithValue("@LastName", lastname);

                SqlDataReader reader = FindLastName.ExecuteReader();
                while (reader.Read())
                {
                    returnlist.Add("Last Name: " + reader[0].ToString());
                    returnlist.Add("First Name: " + reader[1].ToString());
                    returnlist.Add("PhoneNumber: " + reader[2].ToString());
                    returnlist.Add("Email: " + reader[3].ToString());
                }

            }
            return returnlist;

        }

        internal List<List<string>> GetPets()
        {
            List<List<string>> returnlist = new List<List<string>>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
           
                    con.Open();
                    SqlCommand selectBreed = new SqlCommand("SELECT * FROM PET", con);
                    using (SqlDataReader reader = selectBreed.ExecuteReader())
                    {
                        string date;
                        while (reader.Read())
                        {
                        List<string> listtoadd = new List<string>();
                            if (!reader.IsDBNull(4))
                            {
                                date = reader.GetDateTime(4).ToString();
                            }
                            else
                            {
                                date = "NULL";
                            }
                            listtoadd.Add(reader.GetInt32(0).ToString());
                            listtoadd.Add(reader.GetString(1));
                            listtoadd.Add(reader.GetString(2));
                            listtoadd.Add(reader.GetString(3));
                            listtoadd.Add(date);
                            listtoadd.Add(reader.GetDouble(5).ToString());
                            listtoadd.Add(reader.GetInt32(6).ToString());

                        returnlist.Add(listtoadd);
                        }
                    }
                

            }
            return returnlist;
        }
    }
}

