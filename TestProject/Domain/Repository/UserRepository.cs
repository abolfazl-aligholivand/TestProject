using Microsoft.Data.SqlClient;
using System.Data;
using TestProject.Domain.Data;
using TestProject.Domain.Model;
using TestProject.Domain.Repository.IRepository;

namespace TestProject.Domain.Repository
{
    public class UserRepository : IUserRepository
    {
        string connectionString = ConnectionString.DbConnectionString;

        public async Task<User> AddUser(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("AddUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@first_name", user.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", user.LastName);
                    cmd.Parameters.AddWithValue("@age", user.Age);
                    cmd.Parameters.AddWithValue("@credit", user.Credit);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return user;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteUser(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeleteUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    con.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SelectAllUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    users.Add(new User
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        FirstName = rdr["FirstName"].ToString(),
                        LastName = rdr["LastName"].ToString(),
                        Age = Convert.ToInt32(rdr["Age"]),
                        Credit = Convert.ToInt64(rdr["Credit"])
                    });
                }
                con.Close();
            }
            return users;
        }

        public async Task<User> GetUser(int UserId)
        {
            User user = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetUserById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", UserId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    user = new User();
                    user.Id = Convert.ToInt32(rdr["Id"]);
                    user.FirstName = rdr["FirstName"].ToString();
                    user.LastName = rdr["LastName"].ToString();
                    user.Age = Convert.ToInt32(rdr["Age"]);
                    user.Credit = Convert.ToInt64(rdr["Credit"]);
                }
            }
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("AddUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@first_name", user.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", user.LastName);
                    cmd.Parameters.AddWithValue("@age", user.Age);
                    cmd.Parameters.AddWithValue("@credit", user.Credit);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return user;
            }
            catch
            {
                return null;
            }
        }
    }
}
