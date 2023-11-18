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
    public class PersonDetailsRepository
    {
        string conString = ConfigurationManager.ConnectionStrings["DbSept2023ConnectionString"].ConnectionString;


        // For using this method we will add PersonDetails based on person data
        public bool AddPersonDetails(PersonDetailsModel personDetailsModel)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Insert into PersonDetails(Name,DateOfBirth,GenderId,MobileNumber,Email,IsActive,Address) Values(@Name,@DateOfBirth,@GenderId,@MobileNumber,@Email,@IsActive,@Address)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Name", personDetailsModel.Name);
                cmd.Parameters.AddWithValue("DateOfBirth", personDetailsModel.DateOfBirth);
                cmd.Parameters.AddWithValue("GenderId", personDetailsModel.GenderId);
                cmd.Parameters.AddWithValue("MobileNumber", personDetailsModel.MobileNumber);
                cmd.Parameters.AddWithValue("Email", personDetailsModel.Email);
                cmd.Parameters.AddWithValue("IsActive", personDetailsModel.IsActive);
                cmd.Parameters.AddWithValue("Address", personDetailsModel.Address);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<PersonDetailsModel> GetPersonDetails()
        {

            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from PersonDetails";
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<PersonDetailsModel> personDetailsList = new List<PersonDetailsModel>();

            while (dr.Read())
            {
                PersonDetailsModel personDetailsModel = new PersonDetailsModel();
                personDetailsModel.Id = Convert.ToInt32( dr["Id"]);
                personDetailsModel.Name = dr["Name"].ToString();
                personDetailsModel.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);
                personDetailsModel.Email = dr["Email"].ToString();
                personDetailsModel.IsActive = Convert.ToBoolean(dr["IsActive"]);
                personDetailsModel.MobileNumber = Convert.ToInt64(dr["MobileNumber"]);
                personDetailsModel.Address = dr["Address"].ToString();
                personDetailsModel.GenderId = Convert.ToInt32(dr["GenderId"]);

                personDetailsList.Add(personDetailsModel);
            }

            dr.Close();
            con.Close();
            return personDetailsList;
        }



        public PersonDetailsModel GetPersonDetailsById(int? id)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"Select * from PersonDetails where Id={id}";
                //cmd.CommandText = "Select * from PersonDetails where Id="+id;
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                PersonDetailsModel personDetailsModel = new PersonDetailsModel();
                while (dr.Read())
                {
                    personDetailsModel.Id = Convert.ToInt32(dr["Id"]);
                    personDetailsModel.Name = dr["Name"].ToString();
                    personDetailsModel.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);
                    personDetailsModel.Email = dr["Email"].ToString();
                    personDetailsModel.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    personDetailsModel.MobileNumber = Convert.ToInt64(dr["MobileNumber"]);
                    personDetailsModel.Address = dr["Address"].ToString();
                    personDetailsModel.GenderId = Convert.ToInt32(dr["GenderId"]);
                }

                dr.Close();
                con.Close();
                return personDetailsModel;

            }
            catch (Exception ex)
            {

                return new PersonDetailsModel();
            }
        }

        // For using this method we will update PersonDetails based on person data
        public bool UpdatePersonDetails(PersonDetailsModel personDetailsModel)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Update PersonDetails set Name=@Name,DateOfBirth=@DateOfBirth,GenderId=@GenderId,MobileNumber=@MobileNumber,Email=@Email,IsActive=@IsActive,Address=@Address where Id=@Id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Id", personDetailsModel.Id);
                cmd.Parameters.AddWithValue("Name", personDetailsModel.Name);
                cmd.Parameters.AddWithValue("DateOfBirth", personDetailsModel.DateOfBirth);
                cmd.Parameters.AddWithValue("GenderId", personDetailsModel.GenderId);
                cmd.Parameters.AddWithValue("MobileNumber", personDetailsModel.MobileNumber);
                cmd.Parameters.AddWithValue("Email", personDetailsModel.Email);
                cmd.Parameters.AddWithValue("IsActive", personDetailsModel.IsActive);
                cmd.Parameters.AddWithValue("Address", personDetailsModel.Address);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        SqlConnection sqlConnection;
        public bool DeletePersonDetails(int id)
        {
            try
            {
                sqlConnection = new SqlConnection(conString);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = $"delete PersonDetails where id={id}";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                int executeResult = sqlCommand.ExecuteNonQuery();
                if (executeResult == 1)
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}