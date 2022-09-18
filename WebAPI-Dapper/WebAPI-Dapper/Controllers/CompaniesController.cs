using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using WebAPI_Dapper.Contracts;
using WebAPI_Dapper.DTO;
using WebAPI_Dapper.Entities;

namespace WebAPI_Dapper.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        public CompaniesController(ICompanyRepository companyRepository) => _companyRepository = companyRepository;

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _companyRepository.GetCompanies();
            if(companies is null)
                return NotFound();

            return Ok(companies);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _companyRepository.GetCompany(id);
            if (company is null)
                return NotFound();

            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyForCreationOrUpdateDto company)
        {
            var createdCompany = await _companyRepository.CreateCompany(company);
            if (createdCompany is null)
                return NotFound();
            
            return CreatedAtAction(nameof(GetCompanyById), new { id = createdCompany.Id }, createdCompany);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCompany(int id, CompanyForCreationOrUpdateDto company)
        {
            var dbCompany = await _companyRepository.GetCompany(id);
            if (dbCompany is null)
                return NotFound();

            var UpdateCompany = await _companyRepository.UpdateCompany(id, company);
            return Ok(UpdateCompany);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var dbCompany = await _companyRepository.GetCompany(id);
            if (dbCompany is null)
                return NotFound();

            await _companyRepository.DeleteCompany(id);

            return Ok("Deleted company");
        }

        [HttpGet("ByEmployeeId/{id:int}")]
        public async Task<IActionResult> GetCompanyForEmployee(int id)
        {
            var company = await _companyRepository.GetCompanyByEmployeeId(id);
            if (company is null)
                return NotFound();

            return Ok(company);
        }

        [HttpGet("{id}/MultipleResult")]
        public async Task<IActionResult> GetMultipleResults(int id)
        {
            var company = await _companyRepository.GetMultipleResults(id);
            if (company is null)
                return NotFound();

            return Ok(company);
        }

        [HttpGet("MultipleMapping")]
        public async Task<IActionResult> GetMultipleMapping()
        {
            var companies = await _companyRepository.MultipleMapping();
            if (companies is null)
                return NotFound();

            return Ok(companies);
        }

    }
}
