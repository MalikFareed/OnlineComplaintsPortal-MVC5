using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class BL_ComplainantsDetail
    {
        public IEnumerable<ComplainantsDetail> ComplainantsDetails
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

                List<ComplainantsDetail> ComplainantsDetails = new List<ComplainantsDetail>();

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("dbo.spGetAllComplainantsDetail", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cnn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ComplainantsDetail ComplainantsDetail = new ComplainantsDetail();

                        ComplainantsDetail.cName = rdr["cName"].ToString();
                        ComplainantsDetail.FatherName = rdr["FatherName"].ToString();
                        ComplainantsDetail.CNIC = Convert.ToInt64(rdr["CNIC"]);
                        ComplainantsDetail.Mobile = Convert.ToInt64(rdr["Mobile"]);
                        ComplainantsDetail.Landline = Convert.ToInt64(rdr["Landline"]);
                        ComplainantsDetail.Email = rdr["Email"].ToString();
                        ComplainantsDetail.UserPassword = rdr["UserPassword"].ToString();
                        ComplainantsDetail.PresentAddress = rdr["PresentAddress"].ToString();
                        ComplainantsDetail.HomeDistrict = rdr["HomeDistrict"].ToString();
                        ComplainantsDetail.HomeStation = rdr["HomeStation"].ToString();
                        ComplainantsDetail.AccountType = rdr["AccountType"].ToString();


                        ComplainantsDetails.Add(ComplainantsDetail);
                    }


                }
                return ComplainantsDetails;
            }

        }

        public void InsertComplainantsDetails(ComplainantsDetail complainantsDetail)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.spInsert_vwCompleteComplainantsDetail", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cName", complainantsDetail.cName);
                cmd.Parameters.AddWithValue("@FatherName", complainantsDetail.FatherName);
                cmd.Parameters.AddWithValue("@CNIC", complainantsDetail.CNIC);
                cmd.Parameters.AddWithValue("@Mobile", complainantsDetail.Mobile);
                cmd.Parameters.AddWithValue("@Landline", complainantsDetail.Landline);
                cmd.Parameters.AddWithValue("@Email", complainantsDetail.Email);
                cmd.Parameters.AddWithValue("@UserPassword", complainantsDetail.UserPassword);
                cmd.Parameters.AddWithValue("@PresentAddress", complainantsDetail.PresentAddress);
                cmd.Parameters.AddWithValue("@HomeDistrict", complainantsDetail.HomeDistrict);
                cmd.Parameters.AddWithValue("@HomeStation", complainantsDetail.HomeStation);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteComplainant(double _CNIC)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.spDELETE_vwCompleteComplainantsDetail", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CNIC", _CNIC);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }


        }

    }
}
