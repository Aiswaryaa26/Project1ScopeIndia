using Microsoft.Data.SqlClient;
using Project1ScopeIndia.Models;
using Project1ScopeIndia.Data;
using System.Data;
using static System.Formats.Asn1.AsnWriter;
using System.Xml;

namespace Project1ScopeIndia.Data
{
    public class RegScopesql:IRegScope
    {
        private readonly string RegConnect;
        public RegScopesql(IConfiguration configuration)
        {
            RegConnect = configuration.GetConnectionString("RegConnect");
        }

        public void Insert(RegistrationModel regScope)
        {
            using (SqlConnection conn = new SqlConnection(RegConnect))
            {
                conn.Open();
                string InsertQuery = "INSERT INTO RegistrationTable(RegFirstName,RegLastName,RegGender,RegDateOfBirth,RegEmailAddress,RegPhoneNumber,RegCountry,RegState,RegCity,RegHobbies,RegAvatar) VALUES(@RegFirstName,@RegLastName,@RegGender,@RegDateOfBirth,@RegEmailAddress,@RegPhoneNumber,@RegCountry,@RegState,@RegCity,@RegHobbies,@RegAvatar)";
                using (SqlCommand command = new SqlCommand(InsertQuery, conn))
                {
                    command.Parameters.AddWithValue("@RegFirstName", regScope.RegFirstName);
                    command.Parameters.AddWithValue("@RegLastName", regScope.RegLastName);
                    command.Parameters.AddWithValue("@RegGender", regScope.RegGender);
                    command.Parameters.AddWithValue("@RegDateOfBirth", regScope.RegDateOfBirth);
                    command.Parameters.AddWithValue("@RegEmailAddress", regScope.RegEmailAddress);
                    command.Parameters.AddWithValue("@RegPhoneNumber", regScope.RegPhoneNumber);
                    command.Parameters.AddWithValue("@RegCountry", regScope.RegCountry);
                    command.Parameters.AddWithValue("@RegState", regScope.RegState);
                    command.Parameters.AddWithValue("@RegCity", regScope.RegCity);
                    command.Parameters.AddWithValue("@RegHobbies", regScope.RegHobbies);
                    command.Parameters.AddWithValue("@RegAvatar", regScope.RegAvatarPath);

                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void Update(RegistrationModel regScope)
        {
            
                using (SqlConnection conn = new SqlConnection(RegConnect))
                {
                    conn.Open();
                    string updateQuery = @"UPDATE RegistrationTable SET RegFirstName=@RegFirstName,RegLastName=@RegLastName,RegGender=@RegGender,RegDateOfBirth=@RegDateOfBirth,RegEmailAddress=@RegEmailAddress,RegPhoneNumber=@RegPhoneNumber,RegCountry=@RegCountry,RegState=@RegState,RegCity=@RegCity,RegHobbies=@RegHobbies WHERE Id = @Id";
                                      
                                      
                    using (SqlCommand command = new SqlCommand(updateQuery, conn))
                    {
                        command.Parameters.AddWithValue("@Id", regScope.Id);
                        command.Parameters.AddWithValue("@RegFirstName", regScope.RegFirstName);
                        command.Parameters.AddWithValue("@RegLastName", regScope.RegLastName);
                        command.Parameters.AddWithValue("@RegGender", regScope.RegGender);
                        command.Parameters.AddWithValue("@RegDateOfBirth", regScope.RegDateOfBirth);
                        command.Parameters.AddWithValue("@RegEmailAddress", regScope.RegEmailAddress);
                        command.Parameters.AddWithValue("@RegPhoneNumber", regScope.RegPhoneNumber);
                        command.Parameters.AddWithValue("@RegCountry", regScope.RegCountry);
                        command.Parameters.AddWithValue("@RegState", regScope.RegState);
                        command.Parameters.AddWithValue("@RegCity", regScope.RegCity);
                        command.Parameters.AddWithValue("@RegHobbies", regScope.RegHobbies);
                        command.Parameters.AddWithValue("@RegAvatar", regScope.RegAvatarPath);

                    }
                }
            
        }

        public RegistrationModel GetById(int Id)
        {
            RegistrationModel regScope = new RegistrationModel();
            using (SqlConnection conn = new SqlConnection(RegConnect))
            {
                conn.Open();
                string SelectQuery = "SELECT * FROM RegistrationTable WHERE Id=@Id";
                using (SqlCommand command = new SqlCommand(SelectQuery, conn))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        { 
                            
                                regScope.Id = reader.GetInt32(0);
                                regScope.RegFirstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                regScope.RegLastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                regScope.RegGender = reader.IsDBNull(3) ? null : reader.GetString(3);
                                regScope.RegDateOfBirth = reader.IsDBNull(4) ? null : reader.GetDateTime(4);
                                regScope.RegEmailAddress = reader.IsDBNull(5) ? null : reader.GetString(5);
                                regScope.RegPhoneNumber = reader.IsDBNull(6) ? null : reader.GetString(6);
                                regScope.RegCountry = reader.IsDBNull(7) ? null : reader.GetString(7);
                                regScope.RegState = reader.IsDBNull(8) ? null : reader.GetString(8);
                                regScope.RegCity = reader.IsDBNull(9) ? null : reader.GetString(9);
                                regScope.RegHobbies = reader.IsDBNull(10) ? null : reader.GetString(10);
                                regScope.RegAvatarPath = reader.IsDBNull(11) ? null : reader.GetString(11);   
                        };

                    }

                }
                conn.Close();
            }
            return regScope;
        }


        public RegistrationModel GetByEmail(String RegEmailAddress)
        {
            RegistrationModel regScope = new RegistrationModel();
            using (SqlConnection conn = new SqlConnection(RegConnect))
            {
                conn.Open();
                string SelectQuery = "SELECT * FROM RegistrationTable WHERE RegEmailAddress=@RegEmailAddress";
                using (SqlCommand command = new SqlCommand(SelectQuery, conn))
                {
                    command.Parameters.AddWithValue("@RegEmailAddress", RegEmailAddress);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            regScope.Id = reader.GetInt32(0);
                            regScope.RegFirstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                            regScope.RegLastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                            regScope.RegGender = reader.IsDBNull(3) ? null : reader.GetString(3);
                            regScope.RegDateOfBirth = reader.IsDBNull(4) ? null : reader.GetDateTime(4);
                            regScope.RegEmailAddress = reader.IsDBNull(5) ? null : reader.GetString(5);
                            regScope.RegPhoneNumber = reader.IsDBNull(6) ? null : reader.GetString(6);
                            regScope.RegCountry = reader.IsDBNull(7) ? null : reader.GetString(7);
                            regScope.RegState = reader.IsDBNull(8) ? null : reader.GetString(8);
                            regScope.RegCity = reader.IsDBNull(9) ? null : reader.GetString(9);
                            regScope.RegHobbies = reader.IsDBNull(10) ? null : reader.GetString(10);
                            regScope.RegAvatarPath = reader.IsDBNull(11) ? null : reader.GetString(11);
                        };

                    }

                }
                conn.Close();
            }
            return regScope;
        }



        public List<RegistrationModel> GetAll()
        {
            List<RegistrationModel> regScope = new List<RegistrationModel>();
            using (SqlConnection conn = new SqlConnection(RegConnect))
            {
                conn.Open();
                string SelectQuery = "SELECT * FROM RegistrationTable";
                using (SqlCommand command = new SqlCommand(SelectQuery, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            regScope.Add(new RegistrationModel
                            {
                                Id = reader.GetInt32(0),
                                RegFirstName = reader.GetString(1),
                                RegLastName = reader.GetString(2),
                                RegGender = reader.GetString(3),
                                RegDateOfBirth = reader.GetDateTime(4),
                                RegEmailAddress = reader.GetString(5),
                                RegPhoneNumber = reader.GetString(6),
                                RegCountry = reader.GetString(7),
                                RegState = reader.GetString(8),
                                RegCity = reader.GetString(9),
                                RegHobbies = reader.GetString(10),
                                RegAvatarPath = reader.GetString(11)
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
