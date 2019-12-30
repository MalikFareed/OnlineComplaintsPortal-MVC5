using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class BL_Stations
    {
        public IEnumerable<Station> Stations
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

                List<Station> stations = new List<Station>();

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("dbo.spGetAllStations", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cnn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Station station = new Station();

                        station.StationID = Convert.ToInt32(rdr["StationID"]);
                        station.StationName = rdr["StationName"].ToString();
                        station.DistrictID = Convert.ToInt32(rdr["DistrictID"]);

                        stations.Add(station);

                    }


                }
                return stations;

            }
        }

        public void InsertStation(Station station)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spInsertStation", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StationID", station.StationID);
                cmd.Parameters.AddWithValue("@StationName", station.StationName);
                cmd.Parameters.AddWithValue("@DistrictID", station.DistrictID);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Station> StationsByDistrict(int _DistrictID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;
            List<Station> stations = new List<Station>();

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.StaionsByDistrict", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DistrictID", _DistrictID);

                cnn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Station station = new Station();

                    station.StationID = Convert.ToInt32(rdr["StationID"]);
                    station.StationName = rdr["StationName"].ToString();
                    station.DistrictID = Convert.ToInt32(rdr["DistrictID"]);

                    stations.Add(station);

                }


                return stations;

            }
        }

        public void DeleteStation(int _StationID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.spDeleteStation", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StationID", _StationID);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }


        }
    }
}
