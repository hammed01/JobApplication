using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace jobApplication.Helpers
{
    public interface IDataReaderHelper
    {
        DateTime OrdinalDatetimeValue(SqlDataReader dr, string colName);
        string OrdinalStringValue(SqlDataReader dr, string SColName);
        decimal OrdinalDecimalValue(SqlDataReader dr, string colName);
        double OrdinalDoubleValue(SqlDataReader dr, string colName);
        Int32 OrdinalInt32Value(SqlDataReader dr, string colName);
        Int32 OrdinalNegativeInt32Value(SqlDataReader dr, string colName);
        bool OrdinalBooleanValue(SqlDataReader dr, string colName);

    }
    public class DataReaderHelper : IDataReaderHelper
    {

        public DateTime OrdinalDatetimeValue(SqlDataReader dr, string colName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(colName)))
            {
                return dr.GetDateTime(dr.GetOrdinal(colName));
            }
            else
            {
                return DateTime.Now.AddYears(-100);
            }

        }

        public string OrdinalStringValue(SqlDataReader dr, string SColName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(SColName)))
            {
                return (dr.GetString(dr.GetOrdinal(SColName)));
            }
            else
            {
                return "";
            }
        }

        public decimal OrdinalDecimalValue(SqlDataReader dr, string colName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(colName)))
            {
                return dr.GetDecimal(dr.GetOrdinal(colName));
            }
            else
            {
                return 0;
            }

        }
        public double OrdinalDoubleValue(SqlDataReader dr, string colName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(colName)))
            {
                return dr.GetDouble(dr.GetOrdinal(colName));
            }
            else
            {
                return 0.00;
            }

        }
        public Int32 OrdinalInt32Value(SqlDataReader dr, string colName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(colName)))
            {
                return dr.GetInt32(dr.GetOrdinal(colName));
            }
            else
            {
                return 0;
            }
        }
        public Int32 OrdinalNegativeInt32Value(SqlDataReader dr, string colName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(colName)))
            {
                return dr.GetInt32(dr.GetOrdinal(colName));
            }
            else
            {
                return -1;
            }
        }

        public bool OrdinalBooleanValue(SqlDataReader dr, string colName)
        {
            if (!dr.IsDBNull(dr.GetOrdinal(colName)))
            {
                return dr.GetBoolean(dr.GetOrdinal(colName));
            }
            else
            {
                return false;
            }
        }

    }
}