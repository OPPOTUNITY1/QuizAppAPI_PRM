using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuizAppAPI_PRM.Models.Domain;
using QuizAppAPI_PRM.Models.DTO;
using QuizAppAPI_PRM.Repository.Interface;

namespace QuizAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository repo;

        public SubjectController(ISubjectRepository repo)
        {
            this.repo = repo;
        }

        // GET: https://localhost:7184/api/Subject
        [HttpGet]
        public async Task<IActionResult> GetAllSubject()
        {
            var subjects = await repo.GetAllSubjectAsync();
            var response = new List<SubjectDTO>();
            foreach (var subject in subjects)
            {
                response.Add(new SubjectDTO
                {
                    SubjectId = subject.SubjectId,
                    SubjectName = subject.SubjectName,
                    SubjectDetail = subject.SubjectDetail,
                    UrlImage = subject.UrlImage,
                    VideoUrl = subject.VideoUrl,
                    UserId = subject.UserId
                });
            }
            return Ok(response);
        }

        // GET: https://localhost:7184/api/Subject/{name}
        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetSubjectByName(string name)
        {
            var subject = await repo.GetSubjectByNameAsync(name);
            if (subject == null)
            {
                return NotFound();
            }
            var response = new SubjectDTO
            {
                SubjectId = subject.SubjectId,
                SubjectName = subject.SubjectName,
                SubjectDetail = subject.SubjectDetail,
                UrlImage = subject.UrlImage,
                VideoUrl = subject.VideoUrl,
                UserId = subject.UserId
            };
            return Ok(response);
        }

        // GET: https://localhost:7184/api/Subject/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetSubjectById(Guid id)
        {
            var subject = await repo.GetSubjectByIdAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            var response = new SubjectDTO
            {
                SubjectId = subject.SubjectId,
                SubjectName = subject.SubjectName,
                SubjectDetail = subject.SubjectDetail,
                UrlImage = subject.UrlImage,
                VideoUrl = subject.VideoUrl,
                UserId = subject.UserId
            };
            return Ok(response);
        }
        // GET: https://localhost:7184/api/Subject/teacher/{teacherId}
        [HttpGet]
        [Route("teacher/{teacherId:guid}")]
        public async Task<IActionResult> GetAllSubjectByTeacher(Guid teacherId)
            {
                var subjects = await repo.GetAllSubjectByTeacherAsync(teacherId);
                var response = new List<SubjectDTO>();
                foreach (var subject in subjects)
            {
        response.Add(new SubjectDTO
        {
            SubjectId = subject.SubjectId,
            SubjectName = subject.SubjectName,
            SubjectDetail = subject.SubjectDetail,
            UrlImage = subject.UrlImage,
            VideoUrl = subject.VideoUrl,
            UserId = subject.UserId
        });
    }
    return Ok(response);
}
        // POST: https://localhost:7184/api/Subject
        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody] AddSubjectRequestDTO request)
        {
            if (request.SubjectName.IsNullOrEmpty() || request.SubjectDetail.IsNullOrEmpty() || request.UrlImage.IsNullOrEmpty() || request.VideoUrl.IsNullOrEmpty())
            {
                return BadRequest("Subject name, detail, image URL, and video URL cannot be empty.");
            }
            var subject = new Subject
            {
                SubjectName = request.SubjectName,
                SubjectDetail = request.SubjectDetail,
                UrlImage = request.UrlImage,
                VideoUrl = request.VideoUrl,
                UserId = request.UserId
            };
            await repo.AddSubjectAsync(subject);
            var response = new SubjectDTO
            {
                SubjectId = subject.SubjectId,
                SubjectName = subject.SubjectName,
                SubjectDetail = subject.SubjectDetail,
                UrlImage = subject.UrlImage,
                VideoUrl = subject.VideoUrl,
                UserId = subject.UserId
            };
            return Ok(response);
        }

        // PUT: https://localhost:7184/api/Subject/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateSubject(Guid id, [FromBody] UpdateSubjectRequestDTO request)
        {
            var subject = await repo.GetSubjectByIdAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            subject.SubjectName = request.SubjectName;
            subject.SubjectDetail = request.SubjectDetail;
            subject.UrlImage = request.UrlImage;
            subject.VideoUrl = request.VideoUrl;
            subject.UserId = request.UserId;
            subject = await repo.UpdateSubjectAsync(subject);
            var response = new SubjectDTO
            {
                SubjectId = subject.SubjectId,
                SubjectName = subject.SubjectName,
                SubjectDetail = subject.SubjectDetail,
                UrlImage = subject.UrlImage,
                VideoUrl = subject.VideoUrl,
                UserId = subject.UserId
            };
            return Ok(response);
        }

        // DELETE: https://localhost:7184/api/Subject/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            var subject = await repo.DeleteSubjectAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            var response = new SubjectDTO
            {
                SubjectId = subject.SubjectId,
                SubjectName = subject.SubjectName,
                SubjectDetail = subject.SubjectDetail,
                UrlImage = subject.UrlImage,
                VideoUrl = subject.VideoUrl,
                UserId = subject.UserId
            };
            return Ok(response);
        }
    }
}
