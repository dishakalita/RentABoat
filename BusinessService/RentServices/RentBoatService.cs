using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ViewModels;

namespace BusinessService.RentServices
{
    public class RentBoatService : IRentBoatService
    {
        private string conString;
        public RentBoatService(string connectionString)
        {
            conString = connectionString;
        }
        public List<BoatModel> GetBoats()
        {
            var rtnList = new List<BoatModel>();
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = conString;
                con.Open();
                using (SqlCommand cmd=new SqlCommand("GetAllBoats", con))
                {
                    SqlDataReader rd = cmd.ExecuteReader();
                    while(rd.Read())
                    {
                        rtnList.Add(new BoatModel
                        {
                            BoatId=Convert.ToInt32(rd["BoatId"]),
                            Name = rd["BoatName"].ToString(),
                            HourlyRate = Convert.ToDecimal(rd["HourlyRate"]),
                            IsAvailable=Convert.ToBoolean(rd["IsAvailable"])
                        }) ;
                    }

                }
            }
            return rtnList;
        }

        public void RentBoatToCustomer(int boatId, string customerName, long contactNo)
        {
            using (SqlConnection con = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand("AssignBoatToCustomer", con))
                {
                    try
                    {
                        con.ConnectionString = conString;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BoatId", SqlDbType.Int).Value = boatId;
                        cmd.Parameters.AddWithValue("@customerName", SqlDbType.VarChar).Value = customerName;
                        cmd.Parameters.AddWithValue("@contactNo", SqlDbType.BigInt).Value = contactNo; 
                        con.Open();
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error inserting into Boats table.");
                    }


                }
            }
        }
    }
}
