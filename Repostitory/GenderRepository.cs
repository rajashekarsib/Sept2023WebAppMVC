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
    public class GenderRepository
    {
        string conString = ConfigurationManager.ConnectionStrings["DbSept2023ConnectionString"].ConnectionString;


        public List<GenderModel> GetGenders()
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Gender";
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            //string[] strs = { "", "" };
            //List<string> strList = new List<string> { "", "" };

            List<GenderModel> genderModelList = new List<GenderModel>();          

            while (dr.Read())
            {
                GenderModel genderModel = new GenderModel();
                genderModel.ID = Convert.ToInt32(dr["ID"]);
                genderModel.Name = dr["Name"].ToString();
                genderModel.Code = dr["Code"].ToString();
                genderModelList.Add(genderModel);
            }

            dr.Close();
            con.Close();
            return genderModelList;
        }

    }
}