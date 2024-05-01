using AutoMapper;
using HR.Data.Abstractions;
using HR.Data.Entities;
using HR.Data.RepositoryInterfaces;
using HR.Service.Request.PossessionCategory;
using HR.Service.Request.User;
using HR.Service.ServiceInterfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.ServiceInterfaces
{
    public class PossessionCategoryService : BaseAppService, IPossessionCategoryService
    {
        public PossessionCategoryService(IMapper mapper, IRepositoryWrapper repository, IAppSettings appSettings) : base(mapper, repository, appSettings)
        {
        }

        public async Task<BaseResponse<int>> CreatePossessionCategory([FromBody] PossessionCategoryRequest request)
        {
            var possesionCategories = new PossessionCategory().SetBaseInformation(request.Name);

            await _repository.PossessionCategoryRepository.Create(possesionCategories);
            var result = await _repository.Save() > 0;

            if (!result) return new BaseResponse<int>(0, "Bir hata gerçekleşti");

            return new BaseResponse<int>(possesionCategories.Id);
        }

        public async Task<BaseResponse<bool>> DeletePossessionCategory(int id)
        {
            var possesionCategories = await _repository.PossessionCategoryRepository.FindById(id);
            if (possesionCategories == null) return new BaseResponse<bool>(false, "bulunamadı..");


            await _repository.PossessionCategoryRepository.Delete(possesionCategories.Id);
            var result = await _repository.Save() > 0;

            return new BaseResponse<bool>(result);
        }

        public async Task<BaseResponse<List<PossessionCategoryResponse>>> GetPossessionCategories()
        {
            var possesionCategories = _mapper.Map<List<PossessionCategoryResponse>>(await _repository.PossessionCategoryRepository.GetAll());
            return new BaseResponse<List<PossessionCategoryResponse>>(possesionCategories);
        }

        public async Task<BaseResponse<PossessionCategoryResponse>> GetPossessionCategoryById(int id)
        {
            var possesionCategories = _mapper.Map<PossessionCategoryResponse>(await _repository.PossessionCategoryRepository.FindById(id));
            return new BaseResponse<PossessionCategoryResponse>(possesionCategories);
        }

        public async Task<BaseResponse<int>> UpdatePossessionCategory([FromBody] PossessionCategoryRequest request)
        {
            var possesionCategories = await _repository.PossessionCategoryRepository.FindById(request.Id);
            if (possesionCategories == null) return new BaseResponse<int>(0, " bulunamadı..");

            possesionCategories.SetBaseInformation(request.Name);
            _repository.PossessionCategoryRepository.Update(possesionCategories);
            var result = await _repository.Save() > 0;

            if (!result) return new BaseResponse<int>(0, "Bir hata gerçekleşti");

            return new BaseResponse<int>(possesionCategories.Id);
        }
    }
}
