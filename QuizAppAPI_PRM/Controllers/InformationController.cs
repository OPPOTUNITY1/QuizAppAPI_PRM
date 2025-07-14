using Microsoft.AspNetCore.Mvc;
using QuizAppAPI_PRM.Models.Domain;
using QuizAppAPI_PRM.Models.DTO;
using QuizAppAPI_PRM.Repository.Interface;

namespace QuizAppAPI_PRM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InformationController : ControllerBase
    {
        private readonly IInformationRepository repo;

        public InformationController(IInformationRepository repo)
        {
            this.repo = repo;
        }

        // GET: http://localhost:5000/api/Information
        [HttpGet]
        public async Task<IActionResult> GetAllInformations()
        {
            var informations = await repo.GetAllInformationsAsync();
            var response = new List<InformationDTO>();
            foreach (var information in informations)
            {
                response.Add(new InformationDTO
                {
                    InfoId = information.InfoId,
                    UserId = information.UserId,
                    FullName = information.FullName,
                    Email = information.Email,
                    Phone = information.Phone,
                    UrlImage = information.UrlImage,
                    DateOfBirth = information.DateOfBirth
                });
            }
            return Ok(response);
        }

        // GET: http://localhost:5000/api/Information/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetInformationById([FromRoute] Guid id)
        {
            var information = await repo.GetInformationByIdAsync(id);
            if (information is null)
            {
                return NotFound();
            }
            var response = new InformationDTO
            {
                InfoId = information.InfoId,
                UserId = information.UserId,
                FullName = information.FullName,
                Email = information.Email,
                Phone = information.Phone,
                UrlImage = information.UrlImage,
                DateOfBirth = information.DateOfBirth
            };
            return Ok(response);
        }

        // GET: http://localhost:5000/api/Information/User/{userId}
        [HttpGet]
        [Route("User/{userId:guid}")]
        public async Task<IActionResult> GetInformationByUserId([FromRoute] Guid userId)
        {
            var information = await repo.GetInformationByUserIdAsync(userId);
            if (information is null)
            {
                return NotFound();
            }
            var response = new InformationDTO
            {
                InfoId = information.InfoId,
                UserId = information.UserId,
                FullName = information.FullName,
                Email = information.Email,
                Phone = information.Phone,
                UrlImage = information.UrlImage,
                DateOfBirth = information.DateOfBirth
            };
            return Ok(response);
        }

        // POST: http://localhost:5000/api/Information
        [HttpPost]
        public async Task<IActionResult> AddInformation([FromBody] AddInformationRequestDTO addInformationRequestDTO)
        {
            var information = new Information
            {
                UserId = addInformationRequestDTO.UserId,
                FullName = addInformationRequestDTO.FullName,
                Email = addInformationRequestDTO.Email,
                Phone = addInformationRequestDTO.Phone,
                UrlImage = addInformationRequestDTO.UrlImage,
                DateOfBirth = addInformationRequestDTO.DateOfBirth
            };
            await repo.AddInformationAsync(information);
            var response = new InformationDTO
            {
                InfoId = information.InfoId,
                UserId = information.UserId,
                FullName = information.FullName,
                Email = information.Email,
                Phone = information.Phone,
                UrlImage = information.UrlImage,
                DateOfBirth = information.DateOfBirth
            };
            return Ok(response);
        }

        // PUT: http://localhost:5000/api/Information/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateInformation([FromRoute] Guid id, [FromBody] UpdateInformationRequestDTO request)
        {
            var existingInformation = await repo.GetInformationByIdAsync(id);
            if (existingInformation is null)
            {
                return NotFound();
            }

            existingInformation.UserId = request.UserId;
            existingInformation.FullName = request.FullName;
            existingInformation.Email = request.Email;
            existingInformation.Phone = request.Phone;
            existingInformation.UrlImage = request.UrlImage;
            existingInformation.DateOfBirth = request.DateOfBirth;

            var information = await repo.UpdateInformationAsync(existingInformation);
            var response = new InformationDTO
            {
                InfoId = information.InfoId,
                UserId = information.UserId,
                FullName = information.FullName,
                Email = information.Email,
                Phone = information.Phone,
                UrlImage = information.UrlImage,
                DateOfBirth = information.DateOfBirth
            };
            return Ok(response);
        }

        // DELETE: http://localhost:5000/api/Information/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteInformation([FromRoute] Guid id)
        {
            var information = await repo.DeleteInformationAsync(id);
            if (information is null)
            {
                return NotFound();
            }
            var response = new InformationDTO
            {
                InfoId = information.InfoId,
                UserId = information.UserId,
                FullName = information.FullName,
                Email = information.Email,
                Phone = information.Phone,
                UrlImage = information.UrlImage,
                DateOfBirth = information.DateOfBirth
            };
            return Ok(response);
        }
    }
}