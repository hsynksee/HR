using HR.Api.Infrastructure.Abstractions;
using HR.Api.Infrastructure.Attributes;
using HR.Data.Constants;
using HR.Data.Entities;
using HR.Service.Request.PossessionCategory;
using HR.Service.Request.User;
using HR.Service.ServiceInterfaces;
using HR.Service.ServiceInterfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    public class PossessionCategoryController : BaseController
    {
        private IPossessionCategoryService _possessionCategoryService;
        public PossessionCategoryController(ISystemAppService systemAppService, IPossessionCategoryService possessionCategoryService) : base(systemAppService)
        {
            _possessionCategoryService = possessionCategoryService;
        }

        [HttpGet("GetPossessionCategories")]
        public async Task<IActionResult> GetPossessionCategories() => Ok(await _possessionCategoryService.GetPossessionCategories());

        [HttpGet("GetPossessionCategoryById")]
        public async Task<IActionResult> GetPossessionCategoryById(int id) => Ok(await _possessionCategoryService.GetPossessionCategoryById(id));

        [HttpPost("CreatePossessionCategory")]
        public async Task<IActionResult> CreatePossessionCategory([FromBody] PossessionCategoryRequest request) => Ok(await _possessionCategoryService.CreatePossessionCategory(request));

        [HttpPut("UpdatePossessionCategory")]
        public async Task<IActionResult> UpdatePossessionCategory([FromBody] PossessionCategoryRequest request) => Ok(await _possessionCategoryService.UpdatePossessionCategory(request));

        [HttpDelete("DeletePossessionCategory")]
        public async Task<IActionResult> DeletePossessionCategory(int id) => Ok(await _possessionCategoryService.DeletePossessionCategory(id));
    }
}
