using Dapper;
using Employeesboard.Shared.Candidates.Models;
using Employeesboard.Shared.Database;

namespace Employeesboard.Shared.Candidates
{
    public interface ICandidatesFinder
    {
        Task<IEnumerable<CandidateDTO>> GetAll();
    }

    public class CandidatesFinder : ICandidatesFinder
    {
        private readonly IConnectionFactory _connectionFactory;
        public CandidatesFinder(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<CandidateDTO>> GetAll()
        {
            var dbConnection = _connectionFactory.CreateConnection();

            return await dbConnection.QueryAsync<CandidateDTO>("SELECT Id,FirstName,LastName,Email,Phone FROM tProfiles");
        }
    }
}
