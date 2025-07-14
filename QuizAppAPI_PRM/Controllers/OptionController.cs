using Microsoft.AspNetCore.Mvc;
using QuizAppAPI_PRM.Models.Domain;
using QuizAppAPI_PRM.Models.DTO;
using QuizAppAPI_PRM.Repository.Interface;

namespace QuizAppAPI_PRM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OptionController : ControllerBase  // Thay đổi từ Controller thành ControllerBase
    {
        private readonly IOptionRepository repo;

        public OptionController(IOptionRepository repo)
        {
            this.repo = repo;
        }

        // GET: https://localhost:7184/api/Option/question/{questionId}
        [HttpGet("question/{questionId}")]
        public async Task<IActionResult> GetAllOptionsByQuestionId([FromRoute] Guid questionId)
        {
            var options = await repo.GetAllOptionByQuestionIAsync(questionId);
            if (options == null || !options.Any())
            {
                return NotFound("No options found for the specified question.");
            }
            var response = new List<OptionDTO>();
            foreach (var option in options)
            {
                response.Add(new OptionDTO
                {
                    OptionId = option.OptionId,
                    QuestionId = option.QuestionId,
                    Content = option.Content,
                    IsCorrect = option.IsCorrect
                });
            }
            return Ok(response); // Sửa: return response thay vì options
        }

        // GET: https://localhost:7184/api/Option/{optionId}
        [HttpGet("{optionId}")]
        public async Task<IActionResult> GetOptionById([FromRoute] Guid optionId)
        {
            var option = await repo.GetOptionByIdAsync(optionId);
            if (option == null)
            {
                return NotFound("Option not found.");
            }
            var response = new OptionDTO
            {
                OptionId = option.OptionId,
                QuestionId = option.QuestionId,
                Content = option.Content,
                IsCorrect = option.IsCorrect
            };
            return Ok(response);
        }

        // POST: https://localhost:7184/api/Option
        [HttpPost]
        public async Task<IActionResult> CreateOption([FromBody] AddOptionRequestDTO request)
        {
            var option = new Option
            {
                QuestionId = request.QuestionId,
                Content = request.Content,
                IsCorrect = request.IsCorrect
            };
            await repo.CreateOptionAsync(option);
            var response = new OptionDTO
            {
                OptionId = option.OptionId,
                QuestionId = option.QuestionId,
                Content = option.Content,
                IsCorrect = option.IsCorrect
            };
            return Ok(response);
        }

        // DELETE: https://localhost:7184/api/Option/{optionId}
        [HttpDelete("{optionId}")]
        public async Task<IActionResult> DeleteOption([FromRoute] Guid optionId)
        {
            var deletedOption = await repo.DeleteOptionAsync(optionId);
            if (deletedOption == null)
            {
                return NotFound("Option not found.");
            }
            var response = new OptionDTO
            {
                OptionId = deletedOption.OptionId,
                QuestionId = deletedOption.QuestionId,
                Content = deletedOption.Content,
                IsCorrect = deletedOption.IsCorrect
            };
            return Ok(response);
        }

        // PUT: https://localhost:7184/api/Option/{optionId}
        [HttpPut("{optionId}")]
        public async Task<IActionResult> UpdateOption([FromRoute] Guid optionId, [FromBody] UpdateOptionRequestDTO request)
        {
            var option = await repo.GetOptionByIdAsync(optionId);
            if (option == null)
            {
                return NotFound("Option not found.");
            }
            option.Content = request.Content;
            option.IsCorrect = request.IsCorrect;
            option = await repo.UpdateOptionAsync(option);
            var response = new OptionDTO
            {
                OptionId = option.OptionId,
                QuestionId = option.QuestionId,
                Content = option.Content,
                IsCorrect = option.IsCorrect
            };
            return Ok(response);
        }
    }
}