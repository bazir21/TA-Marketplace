using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Marketplace.Models
{
    public class User
    {

    [Required(ErrorMessage = "Please enter your User ID.")]
    [Display(Name = "Username : ")]
    public string UserId { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Please enter your Password.")]
    [Display(Name = "Password : ")]
    public string Password { get; set; }

    public string UserName { get; set; }
    

    //This method validates the Login credentials
    public String LoginProcess(String strUsername, String strPassword)
    {
        String message = "";
    /*  my connection string
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand("Select * from Usertbl where UserId=@Username", con);
        cmd.Parameters.AddWithValue("@Username", strUsername);
    
    try
    {
    con.Open();
    SqlDataReader reader = cmd.ExecuteReader();
    if (reader.Read())
    {
    Boolean login = (strPassword.Equals(reader["Password"].ToString(), StringComparison.InvariantCulture)) ? true : false;
    if (login)
    {
    message = "1";
    UserName = reader["UserName"].ToString();

    }
    else
    message = "Invalid Credentials";
    }
    else
    message = "Invalid Credentials";

    reader.Close();
    reader.Dispose();
    cmd.Dispose();
    con.Close();
    }
    catch (Exception ex)
    {
        message = ex.Message.ToString() + "Error.";

        }*/
        return message;
        }

    }
}