namespace FinantialCalculator.Services.Services.Factory
{
    using System;
    using System.Data.SqlClient;

    internal class ProviderFactory: IDisposable
    {
        public static SqlConnection GetConnection()
        {
            var connectionString = @"Data Source=LAPTOP-03TUFT0R\SQLEXPRESS;Initial Catalog=FinantialCalculatorDB;Integrated Security=True"; //Environment.GetEnvironmentVariable(string.Empty) ?? string.Empty;

            var connection = new SqlConnection(connectionString);

            return connection;
        }

        public static void CloseConnection(SqlConnection connection)
        {
            connection.Dispose();
            connection.Close();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
