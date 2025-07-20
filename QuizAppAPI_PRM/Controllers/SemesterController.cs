using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuizAppAPI_PRM.Models.Domain;
using QuizAppAPI_PRM.Models.DTO;
using QuizAppAPI_PRM.Repository.Interface;

namespace QuizAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SemesterController : ControllerBase
    {
        private readonly ISemesterRepository repo;

        public SemesterController(ISemesterRepository repo)
        {
            this.repo = repo;
        }

        // GET: https://localhost:7184/api/Semester
        [HttpGet]
        public async Task<IActionResult> GetAllSemesters()
        {
            var semesters = await repo.GetAllSemestersAsync();
            var response = new List<SemesterDTO>();
            foreach (var semester in semesters)
            {
                response.Add(new SemesterDTO
                {
                    SemesterId = semester.SemesterId,
                    SubjectId = semester.SubjectId,
                    SemesterName = semester.SemesterName
                });
            }
            return Ok(response);
        }

        // GET: https://localhost:7184/api/Semester/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetSemesterById(Guid id)
        {
            var semester = await repo.GetSemesterByIdAsync(id);
            if (semester == null)
            {
                return NotFound();
            }
            var response = new SemesterDTO
            {
                SemesterId = semester.SemesterId,
                SubjectId = semester.SubjectId,
                SemesterName = semester.SemesterName
            };
            return Ok(response);
        }

        // GET: https://localhost:7184/api/Semester/subject/{id}
        [HttpGet]
        [Route("subject/{id:guid}")]
        public async Task<IActionResult> GetSemestersBySubject(Guid id)
        {
            var semesters = await repo.GetSemesterBySubjectAsync(id);
            var response = new List<SemesterDTO>();
            foreach (var semester in semesters)
            {
                response.Add(new SemesterDTO
                {
                    SemesterId = semester.SemesterId,
                    SubjectId = semester.SubjectId,
                    SemesterName = semester.SemesterName
                });
            }
            return Ok(response);
        }

        // POST: https://localhost:7184/api/Semester
        [HttpPost]
        public async Task<IActionResult> AddSemester([FromBody] AddSemesterRequestDTO request)
        {
            if (request.SemesterName.IsNullOrEmpty())
            {
                return BadRequest("Semester name cannot be empty.");
            }
            var semester = new Semester
            {
                SubjectId = request.SubjectId,
                SemesterName = request.SemesterName
            };
            await repo.AddSemesterAsync(semester);
            var response = new SemesterDTO
            {
                SemesterId = semester.SemesterId,
                SubjectId = semester.SubjectId,
                SemesterName = semester.SemesterName
            };
            return Ok(response);
        }

        // PUT: https://localhost:7184/api/Semester/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateSemester(Guid id, [FromBody] UpdateSemesterRequestDTO request)
        {
            var semester = await repo.GetSemesterByIdAsync(id);
            if (semester == null)
            {
                return NotFound();
            }
            semester.SubjectId = request.SubjectId;
            semester.SemesterName = request.SemesterName;
            semester = await repo.UpdateSemesterAsync(semester);
            var response = new SemesterDTO
            {
                SemesterId = semester.SemesterId,
                SubjectId = semester.SubjectId,
                SemesterName = semester.SemesterName
            };
            return Ok(response);
        }

        // DELETE: https://localhost:7184/api/Semester/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteSemester(Guid id)
        {
            var semester = await repo.DeleteSemesterAsync(id);
            if (semester == null)
            {
                return NotFound();
            }
            var response = new SemesterDTO
            {
                SemesterId = semester.SemesterId,
                SubjectId = semester.SubjectId,
                SemesterName = semester.SemesterName
            };
            return Ok(response);
        }
    }
}
