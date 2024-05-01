using HR.Api.Infrastructure.Abstractions;
using HR.Api.Infrastructure.Attributes;
using HR.Data.Constants;
using HR.Data.Entities;
using HR.Service.Request.Possession;
using HR.Service.Request.User;
using HR.Service.ServiceInterfaces;
using HR.Service.ServiceInterfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    public class UserPossessionController : BaseController
    {
        private IUserPossessionService _possessionService;
        public UserPossessionController(ISystemAppService systemAppService, IUserPossessionService possessionService) : base(systemAppService)
        {
            _possessionService = possessionService;
        }

        [HttpGet("GetPossessions")]
        public async Task<IActionResult> GetPossessionCategories() => Ok(await _possessionService.GetPossessions());

        [HttpGet("GetPossessionById")]
        public async Task<IActionResult> GetPossessionById(int id) => Ok(await _possessionService.GetPossessionById(id));

        [HttpPost("CreatePossession")]
        public async Task<IActionResult> CreatePossession([FromBody] UserPossessionRequest request) => Ok(await _possessionService.CreatePossession(request));

        [HttpPut("UpdatePossession")]
        public async Task<IActionResult> UpdatePossession([FromBody] UserPossessionRequest request) => Ok(await _possessionService.UpdatePossession(request));

        [HttpDelete("DeletePossession")]
        public async Task<IActionResult> DeletePossession(int id) => Ok(await _possessionService.DeletePossession(id));
    }
}
