using Microsoft.Data.SqlClient;
using System;
using System.Collections;

namespace DAL
{
    public class BaseDal
    {
        public void write(String queryString, List<SqlParameter> list)
        {
            String sqlString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arsla\Desktop\University_Work\Seventh_Semester\EAD\Assignment_01\Pos_Terminal\Pos_Terminal\Data\green.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(sqlString))
            {
                SqlCommand command =
                new SqlCommand(queryString, connection);
                for(int idx = 0; idx < list.Count; idx++)
                {
                    command.Parameters.Add(list[idx]);
                }
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Object[]> read(String queryString, List<SqlParameter> list)
        {
            List<Object[]> idkWhat;
            String sqlString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arsla\Desktop\University_Work\Seventh_Semester\EAD\Assignment_01\Pos_Terminal\Pos_Terminal\Data\green.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(sqlString))
            {
                SqlCommand command =
                new SqlCommand(queryString, connection);
                for (int idx = 0; idx < list.Count; idx++)
                {
                    command.Parameters.Add(list[idx]);
                }
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                idkWhat = new List<Object[]>();
                while (dataReader.Read())
                {
                    Object[] arr = new Object[dataReader.FieldCount];
                    dataReader.GetValues(arr);
                    idkWhat.Add(arr);
                }
                dataReader.Close();
            }
            return idkWhat;
        }
    }
}