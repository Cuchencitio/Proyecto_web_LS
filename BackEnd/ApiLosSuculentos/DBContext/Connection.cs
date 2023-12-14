using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

// string connectionString = "User Id=admin;Password=cABALLERO0906$;Data Source=oc5lm3yad4sta7a3_high;" + "Connection Timeout=30;";
// OracleConfiguration.TnsAdmin = "C:\\Users\\cesar\\Documents\\ApiLosSuculentos\\AppconsolaSuculenta\\Wallet";
// OracleConfiguration.WalletLocation = OracleConfiguration.TnsAdmin;

// OracleConnection connection = new OracleConnection(connectionString);
// OracleCommand command = connection.CreateCommand();
// connection.Open();
// Console.WriteLine("Se conecto ctm");
// connection.Close();

namespace DBContext;
	public class Connection
	{
        string connectionString = "User Id=admin;Password=cABALLERO0906$;Data Source=oc5lm3yad4sta7a3_high;" + "Connection Timeout=30;";

        public Connection()
        {
            OracleConfiguration.TnsAdmin = @"Wallet";
            OracleConfiguration.WalletLocation = OracleConfiguration.TnsAdmin;
        }

        public Connection(string conn)
        {
            this.connectionString = conn;
        }

        public DataTable Execute(string SQL)
        {
            using (OracleConnection con = new OracleConnection(this.connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        Console.WriteLine("Successfully connected to Oracle Autonomous Database");
                        Console.WriteLine();

                        cmd.CommandText = SQL;
                        OracleDataReader reader = cmd.ExecuteReader();
                        var dt = new DataTable();
                        dt.Load(reader);
                        con.Close();
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    con.Close();
                    return new DataTable();
                }
            }
        }


	}
