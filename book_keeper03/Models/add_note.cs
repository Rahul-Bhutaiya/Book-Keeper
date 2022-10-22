using System.Data;
using System.Data.SqlClient;

namespace book_keeper03.Models
{
    public class add_note
    {
        public string title { get; set; }
        public string category { get; set; }
        public string author { get; set; }
        public string date { get; set; }
        public IFormFile display_image { get; set; }
        public IFormFile note { get; set; }
        public string type { get; set; }
        public int num_page { get; set; }
        public string description { get; set; }

        public string role{get;set;}

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;DATABASE=user;User Id = sa;pwd=bhautik");
        public int insert(string _title, 
                        string _category,
                        string _author,
                        string _date,
                        string _display_image,
                        string _note,
                        string _type,
                        int _num_page,
                        string _description,
                        string _role)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[book_data](title,category,author,date,first_image,book_name,book_type,number_pages,description,sell_for) Values ('" + _title + "','" + _category + "','" + _author + "','" + _date + "','" + _display_image + "','" + _note + "','" + _type + "','" + _num_page + "','" + _description + "','" + _role + "')", con);
            con.Open();
            return cmd.ExecuteNonQuery();

        }
        
    }
}
