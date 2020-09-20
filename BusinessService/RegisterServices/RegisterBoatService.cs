using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ViewModels;

namespace BusinessService.RegisterServices
{
    public class RegisterBoatService : IRegisterBoatService
    {
        private string conString;
        public RegisterBoatService(string connectionString)
        {
            conString = connectionString;
        }
        public int RegisterBoat(string boatName, decimal hourlyRate)
        {
            var rtnValue = -1;
            var dataTable = new DataTable();
            using (SqlConnection con = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand("InsertNewBoat", con))
                {
                    try
                    {
                        con.ConnectionString = conString;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = boatName;
                        cmd.Parameters.AddWithValue("@HourlyRate", SqlDbType.Decimal).Value = hourlyRate;
                        SqlParameter outputPara = new SqlParameter();
                        outputPara.ParameterName = "@BoatId";
                        outputPara.Direction = System.Data.ParameterDirection.Output;
                        outputPara.SqlDbType = System.Data.SqlDbType.Int;
                        cmd.Parameters.Add(outputPara);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        rtnValue = Convert.ToInt32(outputPara.Value);

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error inserting into Boats table.");
                    }
                   
              
                }
            }
            return rtnValue;
        }
    }
}
