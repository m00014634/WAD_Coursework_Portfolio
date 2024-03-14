using Microsoft.EntityFrameworkCore;
using SurveyForm.Models;

namespace SurveyForm.Data
{
    public class SurveyFormDbContext : DbContext
    {
        public SurveyFormDbContext(DbContextOptions<SurveyFormDbContext> options ) : base(options) { }
        public DbSet<Survey> Surveys { get; set; }
    }
}
