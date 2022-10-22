using System.Data;
using System.Data.SqlClient;

namespace book_keeper03.Models
{
    public class subscription
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;DATABASE=user;User Id = sa;pwd=bhautik");
        public int insert(string _fname, string _lname, string _email)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[subscribers](first_name,last_name,email) Values ('" + _fname + "','" + _lname + "','" + _email + "')", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public DataSet select_email(string _email)
        {
            SqlCommand cmd = new SqlCommand("select email from [dbo].[subscribers] where email='" + _email + "'", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        
    }
}
