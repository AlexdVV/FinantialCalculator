namespace FinantialCalculator.Services.Repositories
{
    using FinantialCalculator.Services.Services.Factory;
    using System;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    internal class BaseRepository
    {
        public SqlConnection ConnectionDb { get; set; }

        public async Task<TResponse> RunReposituryAsync<TResponse>(Func<Task<TResponse>> predicate) where TResponse : class
        {
            try
            {
                var response = (TResponse)Activator.CreateInstance(typeof(TResponse));

                using (var connectionDb = ProviderFactory.GetConnection())
                {
                    ConnectionDb = connectionDb;

                    response = await predicate();

                    ProviderFactory.CloseConnection(connectionDb);
                }

                return response;
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
        }
    }
}
