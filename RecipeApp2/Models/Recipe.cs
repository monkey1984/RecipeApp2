using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace RecipeApp2.Models
{
    public class Recipe
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
       
        public List<RecipeAccessLayer> Getdata()
        {
            List<RecipeAccessLayer> li = new List<RecipeAccessLayer>();
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                
                SqlCommand cmd = new SqlCommand("sp_getRecipes", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    RecipeAccessLayer rec = new RecipeAccessLayer();
                    rec.RecipeID = Convert.ToInt32(rdr.GetValue(0).ToString());
                    rec.RecipeName = rdr.GetValue(1).ToString();
                    rec.Rating = Convert.ToInt32(rdr.GetValue(2).ToString());
                    rec.Hours = Convert.ToInt32(rdr.GetValue(3).ToString());
                    rec.Minutes = Convert.ToInt32(rdr.GetValue(4).ToString());
                    rec.Instructions = rdr.GetValue(5).ToString();
                    li.Add(rec);
                }
                
            }
            catch (Exception) 
            {
                throw;
            }

            return li;
        }
         
        public string SaveData(RecipeAccessLayer recipe)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_saveRecipes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlDataReader rdr = cmd.ExecuteReader();
                cmd.Parameters.AddWithValue("@RecipeName", recipe.RecipeName);
                cmd.Parameters.AddWithValue("@Rating", recipe.Rating);
                cmd.Parameters.AddWithValue("@Minutes",recipe.Minutes);
                cmd.Parameters.AddWithValue("@Hours",recipe.Hours);
                cmd.Parameters.AddWithValue("@Instructions",recipe.Instructions);
                Console.WriteLine("I am in SaveData");
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("OK");

            }
            catch (Exception ex)
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                return(ex.Message.ToString());
            }
        }
    }
}