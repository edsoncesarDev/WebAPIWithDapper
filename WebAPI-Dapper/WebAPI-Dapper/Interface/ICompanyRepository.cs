using WebAPI_Dapper.DTO;
using WebAPI_Dapper.Entities;

namespace WebAPI_Dapper.Contracts
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
        public Task<Company> GetCompany(int id);
        public Task<Company> GetCompanyByEmployeeId(int id);
        public Task<Company> CreateCompany(CompanyForCreationOrUpdateDto company);
        public Task<Company> UpdateCompany(int id, CompanyForCreationOrUpdateDto company);
        public Task DeleteCompany(int id);
        public Task<Company> GetMultipleResults(int id);
        public Task<List<Company>> MultipleMapping();
        public Task CreateMultipleCompanies(List<CompanyForCreationOrUpdateDto> companies)
    }
}
