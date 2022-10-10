using Microsoft.Data.SqlClient;

namespace MyLogin.Data
{
    public class LoginClass
    {
        private string username;
        private string password;
        public LoginClass(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public void SQL()
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=UNILOGIN;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();

            SqlCommand command = new SqlCommand(
                "Select * from [Users] WHERE Navn=@userlogin and Pass=@passlogin", conn);
            //    "Select LoginUser from [Table] where LoginUser=@userlogin", conn);
            command.Parameters.AddWithValue("@userlogin", username);
            command.Parameters.AddWithValue("@passlogin", password);
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format($"{reader["Navn"]},{reader["Pass"]}" ));

                }
            }

            conn.Close();
        }

    }
}
