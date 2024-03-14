using Microsoft.EntityFrameworkCore;
using SurveyForm.Data;
using SurveyForm.Models;

namespace SurveyForm.Repositories
{
    public class SurveysRepository : ISurveysRepository
    {
        private readonly SurveyFormDbContext _dbContext;

        public SurveysRepository(SurveyFormDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task <IEnumerable<Survey>> GetAllSurveys()
        {
             var surveys = await _dbContext.Surveys.ToListAsync();
             return surveys;
        }

        public async Task<Survey> GetSingleSurvey(int id)
        {
            return await _dbContext.Surveys.FirstOrDefaultAsync(s => s.Id == id);

        }
        public async Task CreateSurvey(Survey survey)
        {
            await _dbContext.Surveys.AddAsync(survey);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSuryey(int id)
        {
            var survey = await _dbContext.Surveys.FirstOrDefaultAsync(s => s.Id == id);
            if (survey != null)
            {
                _dbContext.Surveys.Remove(survey);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateSurvey(Survey survey)
        {
            _dbContext.Entry(survey).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

    }
}
