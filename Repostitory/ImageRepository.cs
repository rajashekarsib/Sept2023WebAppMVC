using Sept2023WebAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sept2023WebAppMVC.Repostitory
{
    public class ImageRepository
    {
        string conString = ConfigurationManager.ConnectionStrings["DbSept2023ConnectionString"].ConnectionString;


        // For using this method we will add Image based on image data
        public int AddImage(ImageModel imageModel)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Insert into tblImages(ImageData,ImageName,UserName) Values(@ImageData,@ImageName,@UserName); select SCOPE_IDENTITY();";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ImageData", imageModel.ImageData);
                cmd.Parameters.AddWithValue("ImageName", imageModel.ImageName);
                cmd.Parameters.AddWithValue("UserName", imageModel.Username);
                con.Open();
                int id=  Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();                
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public ImageModel GetImageById(int? id)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"Select * from tblImages where ImageId={id}";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                ImageModel imageModel = new ImageModel();
                while (dr.Read())
                {
                    imageModel.Id = Convert.ToInt32(dr["ImageId"]);
                    imageModel.ImageName = dr["ImageName"].ToString();
                    imageModel.ImageData = dr["ImageData"] as byte[]; // similar (byte[])dr["ImageData"] 
                    imageModel.Username = dr["Username"].ToString();
                }
                dr.Close();
                con.Close();
                return imageModel;

            }
            catch (Exception ex)
            {
                return new ImageModel();
            }

        }
    }
}