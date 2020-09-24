using BaseLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Repository
{
    public class PassportRepository
    {
        public int CheckPassport(string passportNumber)
        {
            int result = 0;
            using (var con = new SqlConnection(Helper.GetConnectionString()))
            {
                con.Open();
                using (var cmd = new SqlCommand("SP_CheckPassport", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("passportNumber", System.Data.SqlDbType.VarChar).Value = passportNumber;

                    var outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "passportCheckResult";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);
                     
                     cmd.ExecuteScalar();

                    result = (int)outputParameter.Value;
                }
            }
            return result;
        }

        public PassportModel GetPassportData(string passportNumber)
        {
            var passportModel = new PassportModel();
            using (var con = new SqlConnection(Helper.GetConnectionString()))
            {
                con.Open();
                var query = "SELECT * FROM PassportData WHERE PassportNumber = @passportNumber";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@passportNumber", System.Data.SqlDbType.VarChar).Value = passportNumber;

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        passportModel.Id = (long)reader[nameof(PassportModel.Id)];
                        passportModel.FirstName = reader[nameof(PassportModel.FirstName)].ToString();
                        passportModel.LastName = reader[nameof(PassportModel.LastName)].ToString();
                        passportModel.DateOfBirth = (DateTime)reader[nameof(PassportModel.DateOfBirth)];
                        passportModel.PassportNumber = reader[nameof(PassportModel.PassportNumber)].ToString();
                        passportModel.Sex = (bool)reader[nameof(PassportModel.Sex)];                        
                    }

                }
            }
            return passportModel;
        }
    }
}
