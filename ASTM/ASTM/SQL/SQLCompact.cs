namespace ASTM.SQL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlServerCe;
    using System.Text;

   // using ASTMConfig;
    using System.Reflection;

    public class SQLCompact : DataAccessHelper
    {
        #region Fields

        public static SqlCeConnection conn = null;
       // public static string filename = "";
        public static       DataAccessHelper helperSQL;
        ASTMContainer container = null;
        string connectionString =null;

        #endregion Fields

        #region Constructors

        public  SQLCompact()
        {
        }
        public static DataAccessHelper New()
        {
            if (helperSQL == null)
                return new SQLCompact();
            return helperSQL;
        }
        #endregion Constructors

        #region Methods
        public void setConnectionString(string str)
        {
            connectionString = str; //  ASTMGlobal.getValue("connectionString");
        }

        /// <summary>
        /// function setsql ASTMContainer 
        /// </summary>
        public void setSQLContainer(ASTMContainer _container)
        {
            this.container = _container;
        }
        public static SqlCeConnection getSQLConnection(SqlCeConnection cnn)
        {
            if (conn == null)
            {
                conn = new SqlCeConnection();
                conn.Open();
            }
            return conn;
        }

        public int close()
        {
            conn.Close();
            return 1;
        }

        public int connect()
        {
            try
            {
                using (conn = new SqlCeConnection(connectionString))
                {
                    conn.Open();
                    return 1;
                }
            }
            catch (SqlCeException ex)
            {
                throw new ASTMExeption(ex.Message, ex);
               
            }
        }

        public int delete(object obj)
        {
            throw new NotImplementedException();
        }
        

        public int insert(object obj)
        {
            throw new NotImplementedException();
        }

        public object selectAll(string filename)
        {
            DataSet dataset = new DataSet();
            {
                SqlCeDataAdapter adapter = new SqlCeDataAdapter();
                adapter.SelectCommand = new SqlCeCommand(container.getFileName(filename), conn);
                conn.Open();
                adapter.Fill(dataset);
                conn.Close();
                DataTable firstTable = dataset.Tables[0];

                return firstTable;
            }
        }
        
        public object select(object obj)
        {
            List<object> lstobj = (List<object>)obj;
            conn.Open();
            string selstr = container.getFileName("selectorder");

            SqlCeCommand cmd = new SqlCeCommand(selstr, conn);
            SqlCeParameter name = cmd.Parameters.Add("@name", SqlDbType.NVarChar, 15);
            name.Value = lstobj[0].ToString();
            SqlCeDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                Console.WriteLine(rdr.GetString(0));
            }
            else
            {
                Console.WriteLine("not available yet");
            }

            return null;
        }

        public object selectALL()
        {
            return select("selectAllOrder".ToUpper());
        }

        public int update(object obj)
        {
            List<object> lst = obj as List<object>;
            using (SqlCeCommand command = conn.CreateCommand())
            {
                command.CommandText = "INSERT INTO Student (LastName, FirstName, Address, City) VALUES (@ln, @fn, @add, @cit)";

                command.Parameters.AddWithValue("@ln", lst[0]);
                command.Parameters.AddWithValue("@fn", lst[0]);
                command.Parameters.AddWithValue("@add", lst[0]);
                command.Parameters.AddWithValue("@cit", lst[0]);

                conn.Open();

                command.ExecuteNonQuery();

                conn.Close();

            }
            return 1;
        }

        /// <summary>
        /// not yet 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public object selectWithParameter(Object obj)
        {

            return null;

        }
        private void getParameterObject(Object obj)
        {
            Type myType = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(obj, null);

                // Do something with propValue
            }
        }
        #endregion Methods


        public void setContainer(ASTMContainer container)
        {
            setSQLContainer(container);
        }
    }
}