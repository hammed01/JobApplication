using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using jobApplication.Models;
using System.Data;
using System.Data.SqlClient;
using jobApplication.Helpers;
using EfueliteSolutionsFileLogger;
using EfueliteDataReaderHelper;


namespace jobApplication.DataAccess
{
    public interface IApplicantDataServices
    {
         bool Register(Person applicant);
        List<Person> ListOfApplicant();
        Person SelectSingleRec(string ID);
        bool Update(Person applicant);
    }

    public class ApplicantDataServices : IApplicantDataServices
    {
        private readonly IDataReaderHelper _dataReaderHelper;

       public ApplicantDataServices(IDataReaderHelper dataReaderHelper)
        {
          _dataReaderHelper = dataReaderHelper;

        }


        private static string Conn = WebConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        public bool Register(Person applicant)
        
        {
            bool result = false;

            try
            {
                using (SqlConnection con = new SqlConnection(Conn))
                {
                    con.Open();
                    SqlCommand oComm = new SqlCommand();
                    using (oComm)
                    {
                        oComm.Connection = con;
                        oComm.CommandType = CommandType.StoredProcedure;
                        oComm.CommandText = "JobApplication_ApplicantBiodata_insert_4";

                        oComm.Parameters.Add(new SqlParameter("@ApplicantId", SqlDbType.NVarChar));
                        oComm.Parameters["@ApplicantId"].Value = applicant.Id;

                        oComm.Parameters.Add(new SqlParameter("@ApplicantFirstName", SqlDbType.NVarChar));
                        oComm.Parameters["@ApplicantFirstName"].Value = applicant.FirstName;

                        oComm.Parameters.Add(new SqlParameter("@ApplicantLastName", SqlDbType.NVarChar));
                        oComm.Parameters["@ApplicantLastName"].Value = applicant.LastName;

                        oComm.Parameters.Add(new SqlParameter("@ApplicantSex", SqlDbType.NVarChar));
                        oComm.Parameters["@ApplicantSex"].Value = applicant.Sex;

                        oComm.Parameters.Add(new SqlParameter("@ApplicantAdddressNumber", SqlDbType.NVarChar));
                        oComm.Parameters["@ApplicantAdddressNumber"].Value = applicant.Address;
                        
                        oComm.Parameters.Add(new SqlParameter("@ApplicantHighSchool", SqlDbType.NVarChar));
                        oComm.Parameters["@ApplicantHighSchool"].Value = applicant.HighSchool;

                        oComm.Parameters.Add(new SqlParameter("@ApplicantDateOfBirth", SqlDbType.DateTime));
                        oComm.Parameters["@ApplicantDateOfBirth"].Value = applicant.DateOfBirth;

                        oComm.Parameters.Add(new SqlParameter("@ApplicantNationality", SqlDbType.NVarChar));
                        oComm.Parameters["@ApplicantNationality"].Value = applicant.Nationality;


                        oComm.Parameters.Add(new SqlParameter("@Success", SqlDbType.NVarChar, 9000));
                        oComm.Parameters["@Success"].Direction = ParameterDirection.Output;

                        oComm.ExecuteNonQuery();

                        string functionReturnValue = Convert.ToString(oComm.Parameters["@Success"].Value);
                        if (string.IsNullOrEmpty(functionReturnValue))
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    con.Close();
                }

            }
            catch (SqlException ex)
            {
                FileLog.Write(ex.ToString());
            }
            return result;
        }
      

        public List<Person> ListOfApplicant()
        {
            List<Person> sList = new List<Person>();
            try
            {
                using (SqlConnection con = new SqlConnection(Conn))
                {
                    con.Open();
                    SqlCommand oComm = new SqlCommand();
                    using (oComm)
                    {
                        oComm.Connection = con;
                        oComm.CommandType = CommandType.StoredProcedure;
                        oComm.CommandText = "JobApplication_SELECT_SelectALL";


                        SqlDataReader rdr = oComm.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Person qList = new Person();
                                qList.Id = DataHelper.String(rdr, "ApplicantId");
                                qList.FirstName = DataHelper.String(rdr, "ApplicantFirstName");
                                qList.LastName = DataHelper.String(rdr, "ApplicantLastName");
                                qList.Address = DataHelper.String(rdr, "ApplicantAdddressNumber");
                                qList.Sex = DataHelper.String(rdr, "ApplicantSex");
                                qList.HighSchool = DataHelper.String(rdr, "ApplicantHighSchool");
                                qList.Nationality = DataHelper.String(rdr, "ApplicantNationality");
                                qList.DateOfBirth = DataHelper.Datetime(rdr, "ApplicantDateOfBirth");



                                sList.Add(qList);
                            }
                        }
                        con.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                string err = ex.ToString();
                FileLog.Write(ex.ToString());
            }
            return sList;
        }
        public bool Update(Person applicant)

        {
            bool result = false;

            try
            {
                using (SqlConnection con = new SqlConnection(Conn))
                {
                    con.Open();
                    SqlCommand oComm = new SqlCommand();
                    using (oComm)
                    {
                        oComm.Connection = con;
                        oComm.CommandType = CommandType.StoredProcedure;
                        oComm.CommandText = "JobApplication_update";

                        oComm.Parameters.Add(new SqlParameter("@ApplicantId", SqlDbType.NVarChar));
                        oComm.Parameters["@ApplicantId"].Value = applicant.Id;

                        oComm.Parameters.Add(new SqlParameter("@ApplicantFirstName", SqlDbType.NVarChar));
                        oComm.Parameters["@ApplicantFirstName"].Value = applicant.FirstName;

                        oComm.Parameters.Add(new SqlParameter("@ApplicantLastName", SqlDbType.NVarChar));
                        oComm.Parameters["@ApplicantLastName"].Value = applicant.LastName;


                        oComm.Parameters.Add(new SqlParameter("@ApplicantDateOfBirth", SqlDbType.DateTime));
                        oComm.Parameters["@ApplicantDateOfBirth"].Value = applicant.DateOfBirth;

                        oComm.Parameters.Add(new SqlParameter("@ApplicantAdddressNumber", SqlDbType.NVarChar));
                        oComm.Parameters["@ApplicantAdddressNumber"].Value = applicant.Address;

                        oComm.Parameters.Add(new SqlParameter("@Success", SqlDbType.NVarChar, 9000));
                        oComm.Parameters["@Success"].Direction = ParameterDirection.Output;

                        oComm.ExecuteNonQuery();

                        string functionReturnValue = Convert.ToString(oComm.Parameters["@Success"].Value);
                        if (string.IsNullOrEmpty(functionReturnValue))
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    con.Close();
                }

            }
            catch (SqlException ex)
            {
                FileLog.Write(ex.ToString());
            }
            return result;
        }
        public Person SelectSingleRec(string ID)
        {
            Person model = new Person();

            try
            {
                using (SqlConnection con = new SqlConnection(Conn))
                {
                    con.Open();
                    SqlCommand oComm = new SqlCommand();
                    using (oComm)
                    {
                        oComm.Connection = con;
                        oComm.CommandType = CommandType.StoredProcedure;
                        oComm.CommandText = "JobApplication_SELECT_SINGLE";

                        oComm.Parameters.Add(new SqlParameter("@ApplicantId", SqlDbType.NVarChar));
                        oComm.Parameters["@ApplicantId"].Value = ID;

                        SqlDataReader rdr = oComm.ExecuteReader();
                        if (rdr.HasRows && rdr.Read())
                        {
                            model.FirstName = DataHelper.String(rdr, "ApplicantFirstName");
                            model.LastName = DataHelper.String(rdr, "ApplicantLastName");
                            model.DateOfBirth = DataHelper.Datetime(rdr, "ApplicantDateOfBirth");
                            model.Address = DataHelper.String(rdr, "ApplicantAdddressNumber");


                        }


                    }
                    con.Close();
                }

            }
            catch (SqlException ex)
            {
                string err = ex.ToString();
                FileLog.Write(ex.ToString());
            }
            return model;
        }

    }
}