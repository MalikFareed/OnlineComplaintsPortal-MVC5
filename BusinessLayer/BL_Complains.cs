using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class BL_Complains
    {
        public IEnumerable<Complain> complains
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

                List<Complain> complains = new List<Complain>();

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllComplains", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Complain complain = new Complain();

                        complain.ComplainantsCNIC = Convert.ToDouble(reader["ComplainantsCNIC"]);
                        complain.cName = reader["cName"].ToString();
                        complain.DateOfIncident = Convert.ToDateTime(reader["DateOfIncident"]);
                        complain.TimeOfIncident = DateTime.Parse(reader["TimeOfIncident"].ToString());
                        complain.PlaceOfIncident = reader["PlaceOfIncident"].ToString();
                        complain.DistrictName = reader["DistrictName"].ToString();
                        complain.StationName = reader["StationName"].ToString();
                        complain.ComplainantsCNIC = Convert.ToDouble(reader["ComplainantsCNIC"]);
                        complain.DetailOfIncident = reader["DetailOfIncident"].ToString();
                        complain.AlreadyVisitPoliceStation = Convert.ToBoolean(reader["AlreadyVisitPoliceStation"]);
                        complain.VisitDetail = reader["VisitDetail"].ToString();
                        complain.VisitDate = Convert.ToDateTime(reader["VisitDate"]);
                        complain.VisitTime = DateTime.Parse(reader["VisitTime"].ToString());

                        complains.Add(complain);

                    }
                }
                return complains;
            }
        }

        public void InsertComplain(Complain complain)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.spInsert_vwComplains", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ComplainantsCNIC", complain.ComplainantsCNIC);
                cmd.Parameters.AddWithValue("@cName", complain.cName);
                cmd.Parameters.AddWithValue("@DateOfIncident", complain.DateOfIncident);
                cmd.Parameters.AddWithValue("@TimeOfIncident", complain.TimeOfIncident);
                cmd.Parameters.AddWithValue("@PlaceOfIncident", complain.PlaceOfIncident);
                cmd.Parameters.AddWithValue("@DistrictName", complain.DistrictName);
                cmd.Parameters.AddWithValue("@StationName", complain.StationName);
                cmd.Parameters.AddWithValue("@DetailOfIncident", complain.DetailOfIncident);
                cmd.Parameters.AddWithValue("@AlreadyVisitPoliceStation", complain.AlreadyVisitPoliceStation);
                cmd.Parameters.AddWithValue("@VisitDetail", complain.VisitDetail);
                cmd.Parameters.AddWithValue("@VisitDate", complain.VisitDate);
                cmd.Parameters.AddWithValue("@VisitTime", complain.VisitTime);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Complain> ComplainsByStationName(string _StationName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

            List<Complain> complains = new List<Complain>();

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spComplainsByStationName", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StationName", _StationName);


                cnn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Complain complain = new Complain();

                    complain.ComplainantsCNIC = Convert.ToDouble(reader["ComplainantsCNIC"]);
                    complain.cName = reader["cName"].ToString();
                    complain.DateOfIncident = Convert.ToDateTime(reader["DateOfIncident"]);
                    complain.TimeOfIncident = DateTime.Parse(reader["TimeOfIncident"].ToString());
                    complain.PlaceOfIncident = reader["PlaceOfIncident"].ToString();
                    complain.DistrictName = reader["DistrictName"].ToString();
                    complain.StationName = reader["StationName"].ToString();
                    complain.ComplainantsCNIC = Convert.ToDouble(reader["ComplainantsCNIC"]);
                    complain.DetailOfIncident = reader["DetailOfIncident"].ToString();
                    complain.AlreadyVisitPoliceStation = Convert.ToBoolean(reader["AlreadyVisitPoliceStation"]);
                    complain.VisitDetail = reader["VisitDetail"].ToString();
                    complain.VisitDate = Convert.ToDateTime(reader["VisitDate"]);
                    complain.VisitTime = DateTime.Parse(reader["VisitTime"].ToString());

                    complains.Add(complain);

                }
            }
            return complains;
        }

        public void DeleteComplain(double _ComplainantsCNIC)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.spDeleteComplain", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ComplainantsCNIC", _ComplainantsCNIC);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }


        }
    }
}