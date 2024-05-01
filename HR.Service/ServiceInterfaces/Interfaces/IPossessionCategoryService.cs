using HR.Data.Entities;
using HR.Service.Request.PossessionCategory;
using HR.Service.Request.User;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.ServiceInterfaces.Interfaces
{
    public interface IPossessionCategoryService
    {
        Task<BaseResponse<List<PossessionCategoryResponse>>> GetPossessionCategories();
        Task<BaseResponse<PossessionCategoryResponse>> GetPossessionCategoryById(int id);
        Task<BaseResponse<int>> CreatePossessionCategory([FromBody] PossessionCategoryRequest request);
        Task<BaseResponse<int>> UpdatePossessionCategory([FromBody] PossessionCategoryRequest request);
        Task<BaseResponse<bool>> DeletePossessionCategory(int id);
    }
}
