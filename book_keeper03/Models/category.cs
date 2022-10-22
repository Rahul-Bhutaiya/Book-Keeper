using System.Data;
using System.Data.SqlClient;

namespace book_keeper03.Models
{
    public class category
    {
        public string category_name { get; set; }
        public string description { get; set; }

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;DATABASE=user;User Id = sa;pwd=bhautik");
        public int insert(string _category_name, string _description)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[book_categories](category_name,category_description) Values ('" + _category_name + "','" + _description + "')", con);
            con.Open();
            return cmd.ExecuteNonQuery();

        }
        public DataSet get_category()
        {
            SqlCommand cmd = new SqlCommand("select category_name from[dbo].[book_categories]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
        public DataSet get_regi_data()
        {
            SqlCommand cmd = new SqlCommand("select * from[dbo].[user_db]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
        public DataSet us_contact()
        {
            SqlCommand cmd = new SqlCommand("select * from[dbo].[contact_us]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
        public DataSet sub()
        {
            SqlCommand cmd = new SqlCommand("select * from[dbo].[subscribers]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
        public int del(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[book_data] where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}
