using WebAPI_Dapper.Enums;

namespace WebAPI_Dapper.DTO
{
    public class CompanyForCreationOrUpdateDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public Level Level { get; set; } = Level.Low;
    }
}
