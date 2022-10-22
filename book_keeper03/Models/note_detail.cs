using System.Data;
using System.Data.SqlClient;

namespace book_keeper03.Models
{
    public class note_detail
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;DATABASE=user;User Id = sa;pwd=bhautik");
        public DataSet about_notes()
        {
            SqlCommand cmd = new SqlCommand("select id, title, category,author,date, book_type, number_pages, sell_for from[dbo].[book_data]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
        public DataSet notes()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[book_data] where sell_for='free'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
        public DataSet paid_notes()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[book_data] where sell_for='paid'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
        public DataSet verify(string _email)
        {
            SqlCommand cmd = new SqlCommand("select email from [dbo].[subscribers] where email='"+_email+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
    }
}
