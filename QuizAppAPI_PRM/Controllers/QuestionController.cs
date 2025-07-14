using Microsoft.AspNetCore.Mvc;
using QuizAppAPI_PRM.Models.DTO;
using QuizAppAPI_PRM.Repository.Interface;

namespace QuizAppAPI_PRM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository repo;

        public QuestionController(IQuestionRepository repo)
        {
            this.repo = repo;
        }

        // GET: https://localhost:7184/api/Question/semester/{semesterId}
        [HttpGet]
        [Route("semester/{semesterId:guid}")]
        public async Task<IActionResult> GetAllQuestions([FromRoute] Guid semesterId)
        {
            var questions = await repo.GetAllQuestionsAsync(semesterId);
            if (questions == null)
            {
                return NotFound("No questions found for the specified semester.");
            }
            var response = new List<QuestionDTO>();
            foreach (var question in questions)
            {
                response.Add(new QuestionDTO
                {
                    QuestionId = question.QuestionId,
                    SemesterId = question.SemesterId,
                    Content = question.Content,
                });
            }
            return Ok(response);
        }

        // GET: https://localhost:7184/api/Question/{questionId}
        [HttpGet]
        [Route("{questionId:guid}")]
        public async Task<IActionResult> GetQuestionById([FromRoute] Guid questionId)
        {
            var question = await repo.GetQuestionByIdAsync(questionId);
            if (question == null)
            {
                return NotFound("Question not found.");
            }
            var response = new QuestionDTO
            {
                QuestionId = question.QuestionId,
                SemesterId = question.SemesterId,
                Content = question.Content,
            };
            return Ok(response);
        }

        // POST: https://localhost:7184/api/Question
        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] AddQuestionRequestDTO request)
        {
            var question = new Models.Domain.Question
            {
                SemesterId = request.SemesterId,
                Content = request.Content
            };
            await repo.CreateQuestionAsync(question);
            var response = new QuestionDTO
            {
                QuestionId = question.QuestionId,
                SemesterId = question.SemesterId,
                Content = question.Content
            };
            return Ok(response);
        }

        // PUT: https://localhost:7184/api/Question/{questionId}
        [HttpPut]
        [Route("{questionId:guid}")]
        public async Task<IActionResult> UpdateQuestion([FromRoute] Guid questionId, [FromBody] UpdateQuestionRequestDTO request)
        {
            var existingQuestion = await repo.GetQuestionByIdAsync(questionId);
            if (existingQuestion == null)
            {
                return NotFound("Question not found.");
            }
            existingQuestion.Content = request.Content;
            var question = await repo.UpdateQuestionAsync(existingQuestion);
            var response = new QuestionDTO
            {
                QuestionId = question.QuestionId,
                SemesterId = question.SemesterId,
                Content = question.Content
            };
            return Ok(response);
        }

        // DELETE: https://localhost:7184/api/Question/{questionId}
        [HttpDelete]
        [Route("{questionId:guid}")]
        public async Task<IActionResult> DeleteQuestion([FromRoute] Guid questionId)
        {
            var question = await repo.DeleteQuestionAsync(questionId);
            if (question == null)
            {
                return NotFound("Question not found.");
            }
            var response = new QuestionDTO
            {
                QuestionId = question.QuestionId,
                SemesterId = question.SemesterId,
                Content = question.Content
            };
            return Ok(response);
        }
    }
}