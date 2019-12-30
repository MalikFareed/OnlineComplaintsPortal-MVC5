using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class BL_Districts
    {
        public IEnumerable<District> Districts
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

                List<District> districts = new List<District>();

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("dbo.spGetAllDistricts", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cnn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        District district = new District();

                        district.DistrictID = Convert.ToInt32(rdr["DistrictID"]);
                        district.DistrictName = rdr["DistrictName"].ToString();

                        districts.Add(district);
                    }


                }
                return districts;

            }
        }

        public void InsertDistrict(District district)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spInsertDistrict", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DistrictID", district.DistrictID);
                cmd.Parameters.AddWithValue("@DistrictName", district.DistrictName);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteDistrict(int _DistrictID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.spDeleteDistrict", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DistrictID", _DistrictID);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }


        }
    }
}
