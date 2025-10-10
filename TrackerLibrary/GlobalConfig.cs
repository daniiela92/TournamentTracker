using System.Configuration;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {

        public static IDataConnection Connection { get; private set; } 

        public static void InitializeConnections(DataBaseType db)
        {

            if (db == DataBaseType.Sql)
            {
                // TODO - Set up the SQL Connector properly

                SqlConnector sql = new SqlConnector();

                Connection = sql;
            }

            else if (db == DataBaseType.TextFile)
            {

                // TODO - Create the Text Connection

                TextConnector text = new TextConnector();

                Connection = text;
            }
        }

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }








    }
}
