using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using jobApplication.Models;
using System.Data.SqlClient;
using System.Data;
using EfueliteSolutionsFileLogger;
using EfueliteDataReaderHelper;
using jobApplication.Helpers;

namespace jobApplication.DataAccess
{
    public interface IAdminDataServices
    {
        bool AdminReg(Person admin);
        List<Person> ListOfAdmin();
        Person SelectSingleRec(string ID);
        bool Update(Person admin);

    }

    public class AdminDataServices : IAdminDataServices
    {
        private readonly IDataReaderHelper _dataReaderHelper;

        public AdminDataServices(IDataReaderHelper dataReaderHelper)
        {
            _dataReaderHelper = dataReaderHelper;

        }

        private static string Conn = WebConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        public bool AdminReg(Person admin)

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
                        oComm.CommandText = "JOBAPP_ADMIN_INSERT";

                        oComm.Parameters.Add(new SqlParameter("@AdminId", SqlDbType.NVarChar));
                        oComm.Parameters["@AdminId"].Value = admin.Id;

                        oComm.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar));
                        oComm.Parameters["@FirstName"].Value = admin.FirstName;

                        oComm.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar));
                        oComm.Parameters["@LastName"].Value = admin.LastName;

                        oComm.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.DateTime));
                        oComm.Parameters["@DateOfBirth"].Value = admin.DateOfBirth;

                        oComm.Parameters.Add(new SqlParameter("@Sex", SqlDbType.NVarChar));
                        oComm.Parameters["@Sex"].Value = admin.Sex;

                        oComm.Parameters.Add(new SqlParameter("@StateOfOrigin", SqlDbType.NVarChar));
                        oComm.Parameters["@StateofOrigin"].Value = admin.StateOfOrigin;

                        oComm.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar));
                        oComm.Parameters["@Address"].Value = admin.Address;


                        oComm.Parameters.Add(new SqlParameter("@Qualification", SqlDbType.NVarChar));
                        oComm.Parameters["@Qualification"].Value = admin.Qualification;

                        oComm.Parameters.Add(new SqlParameter("@EmailAddress", SqlDbType.NVarChar));
                        oComm.Parameters["@EmailAddress"].Value = admin.EmailAddress;



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
        public List<Person> ListOfAdmin()

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
                        oComm.CommandText = "JobApp_Admin_SelectALL";


                        SqlDataReader rdr = oComm.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Person qList = new Person();
                                qList.Id = DataHelper.String(rdr, "AdminId");
                                qList.FirstName = DataHelper.String(rdr, "FirstName");
                                qList.LastName = DataHelper.String(rdr, "LastName");
                                qList.DateOfBirth = DataHelper.Datetime(rdr, "DateOfBirth");
                                qList.Sex = DataHelper.String(rdr, "Sex");
                                qList.StateOfOrigin = DataHelper.String(rdr, "StateOfOrigin");
                                qList.Address = DataHelper.String(rdr, "Address");
                                qList.Qualification = DataHelper.String(rdr, "Qualification");
                                qList.EmailAddress = DataHelper.String(rdr, "EmailAddress");


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
                        oComm.CommandText = "JobApp_Admin_SINGLE";

                        oComm.Parameters.Add(new SqlParameter("@AdminId", SqlDbType.NVarChar));
                        oComm.Parameters["@AdminId"].Value = ID;

                        SqlDataReader rdr = oComm.ExecuteReader();
                        if (rdr.HasRows && rdr.Read())
                        {
                            model.FirstName = DataHelper.String(rdr, "FirstName");
                            model.LastName = DataHelper.String(rdr, "LastName");
                            model.DateOfBirth = DataHelper.Datetime(rdr,"DateOfBirth");
                            model.Address = DataHelper.String(rdr, "Address");


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
        public bool Update(Person admin)

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
                        oComm.CommandText = "JobApp_Admin_update";

                        oComm.Parameters.Add(new SqlParameter("@AdminId", SqlDbType.NVarChar));
                        oComm.Parameters["@AdminId"].Value = admin.Id;

                        oComm.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar));
                        oComm.Parameters["@FirstName"].Value = admin.FirstName;

                        oComm.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar));
                        oComm.Parameters["@LastName"].Value = admin.LastName;

                        oComm.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.DateTime));
                        oComm.Parameters["@DateOfBirth"].Value = admin.DateOfBirth;

                        oComm.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar));
                        oComm.Parameters["@Address"].Value = admin.Address;


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

    }
}




