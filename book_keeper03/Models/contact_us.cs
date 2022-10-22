using System.Data.SqlClient;

namespace book_keeper03.Models
{
    public class contact_us
    {
        public string fname { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;DATABASE=user;User Id = sa;pwd=bhautik");
        public int insert(string _fname, string _email, string _subject, string _message)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[contact_us](full_name,email,subject,message) Values ('" + _fname + "','" + _email + "','" + _subject + "','" + _message + "')", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}
