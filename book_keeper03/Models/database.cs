using System.Data;
using System.Data.SqlClient;

namespace book_keeper03.Models
{
    public class database
    {

        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;DATABASE=user;User Id = sa;pwd=bhautik");
        public DataSet login(string _email, string _password)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[user_db] where email='" + _email + "' and password='" + _password + "'", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);


            return ds;

        }
        public DataSet ad_login(string _email, string _password)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[admin_login] where email='" + _email + "' and password='" + _password + "'", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);


            return ds;

        }
        public DataSet forgot_pwd(string _email)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[user_db] where email='" + _email + "'", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);
            return ds;
        }
        public DataSet select_email(string _email)
        {
            SqlCommand cmd = new SqlCommand("select email from [dbo].[user_db] where email='" + _email + "'", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int insert(string _fname, string _lname, string _email, string _password)
        {
                SqlCommand cmd = new SqlCommand("insert into [dbo].[user_db](fname,lname,email,password) Values ('" + _fname + "','" + _lname + "','" + _email + "','" + _password + "')", con);
                con.Open();
                return cmd.ExecuteNonQuery();
        }
        
    }

    
}
