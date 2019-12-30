using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class BL_Posts
    {
        public IEnumerable<Post> Posts
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

                List<Post> posts = new List<Post>();

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("dbo.spGetAllPosts", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cnn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Post post = new Post();

                        post.PostID = Convert.ToInt32(rdr["PostID"]);
                        post.PostTitle = rdr["PostTitle"].ToString();

                        posts.Add(post);
                    }


                }
                return posts;
            }
        }

        public void InsertPost(Post post)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spInsertPost", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PostID", post.PostID);
                cmd.Parameters.AddWithValue("@PostTitle", post.PostTitle);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void DeletePost(int _PostID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.spDeletePost", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PostID", _PostID);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }


        }
    }
}

