namespace FinantialCalculator.Services.Repositories
{
    using Dapper;
    using FinantialCalculator.Domain.Common.Dtos.Entities;
    using FinantialCalculator.Services.Resources;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using System.Linq;

    internal class AmortizationScheduleRepository : BaseRepository
    {
        public async Task<AmortizationScheduleEntiti> GetAmortizationScheduleAsync(uint amortizationScheduleId)
        {
            return await ConnectionDb.QueryFirstOrDefaultAsync<AmortizationScheduleEntiti>(QueriesResources.GetAmortizationScheduleById, new { AmortizationScheduleId = (int)amortizationScheduleId }, commandType: CommandType.Text);         
        }

        public async Task<List<AmortizationScheduleEntiti>> GetAllAmortizationScheduleAsync()
        {
            var response = await ConnectionDb.QueryAsync<AmortizationScheduleEntiti>(sql: QueriesResources.GetAmortizationSchedule, commandType: CommandType.Text);

            return response.ToList();
        }
    }
}
