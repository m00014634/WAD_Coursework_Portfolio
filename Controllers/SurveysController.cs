using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyForm.Data;
using SurveyForm.Models;
using SurveyForm.Repositories;

namespace SurveyForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly SurveyFormDbContext _context;
        private readonly ISurveysRepository _surveysRepository;

        public SurveysController(ISurveysRepository surveysRepository)
        {
            _surveysRepository = surveysRepository;
        }

        // GET: api/Surveys
        [HttpGet]
        public async Task<IEnumerable<Survey>> GetSurveys()
        {
            
            return await _surveysRepository.GetAllSurveys();
        }

        // GET: api/Surveys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Survey>> GetSurvey(int id)
        {
            var survey = await _surveysRepository.GetSingleSurvey(id);

            if (survey == null)
            {
                return NotFound();
            }

            return Ok(survey);
        }

        // PUT: api/Surveys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurvey(int id, Survey survey)
        {
            if (id != survey.Id)
            {
                return BadRequest();
            }

            await _surveysRepository.UpdateSurvey(survey);
            return NoContent();
        }

        // POST: api/Surveys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Survey>> PostSurvey(Survey survey)
        {
         
            _surveysRepository.CreateSurvey(survey);
            return CreatedAtAction("GetSurvey", new { id = survey.Id }, survey);
        }

        // DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            _surveysRepository.DeleteSuryey(id);

            return NoContent();
        }

     
    }
}
