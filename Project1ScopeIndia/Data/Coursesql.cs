using Microsoft.Data.SqlClient;
using Project1ScopeIndia.Models;

namespace Project1ScopeIndia.Data
{
    public class Coursesql:ICourse
    {
        private readonly string RegConnect;
        public Coursesql(IConfiguration configuration)
        {
            RegConnect = configuration.GetConnectionString("RegConnect");
        }

        public CourseModel GetById(int CourseId)
        {
            CourseModel regScope = new CourseModel();
            using (SqlConnection conn = new SqlConnection(RegConnect))
            {
                conn.Open();
                string SelectQuery = "SELECT * FROM CourseTable WHERE CourseId=@CourseId";
                using (SqlCommand command = new SqlCommand(SelectQuery, conn))
                {
                    command.Parameters.AddWithValue("@CourseId", CourseId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            regScope.CourseId = reader.GetInt32(0);
                            regScope.CourseName =  reader.GetString(1);
                            regScope.CourseDuration =  reader.GetString(2);
                            regScope.CourseAmount =  reader.GetInt32(3);
                            
                        };

                    }

                }
                conn.Close();
            }
            return regScope;
        }



        public List<CourseModel> GetAll()
        {
            List<CourseModel> regScope = new List<CourseModel>();
            using (SqlConnection conn = new SqlConnection(RegConnect))
            {
                conn.Open();
                string SelectQuery = "SELECT * FROM CourseTable";
                using (SqlCommand command = new SqlCommand(SelectQuery, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            regScope.Add(new CourseModel
                            {
                                CourseId = reader.GetInt32(0),
                                CourseName = reader.GetString(1),
                                CourseDuration = reader.GetString(2),
                                CourseAmount = reader.GetInt32(3),
                                
                            });
                        }
                    }
                }
                conn.Close();
            }
            return regScope;
        }
    }
}
