using AutoMapper;
using HR.Data.Abstractions;
using HR.Data.Entities;
using HR.Data.RepositoryInterfaces;
using HR.Service.Request.Possession;
using HR.Service.Request.User;
using HR.Service.Response.Possession;
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
    public class UserPossessionService : BaseAppService, IUserPossessionService
    {
        public UserPossessionService(IMapper mapper, IRepositoryWrapper repository, IAppSettings appSettings) : base(mapper, repository, appSettings)
        {
        }

        public async Task<BaseResponse<int>> CreatePossession([FromBody] UserPossessionRequest request)
        {
            var possesionCategories = new UserPossession().SetBaseInformation(request.PossessionCategoryId,request.UserId,request.SerialNumber,request.IssueDate,request.ReturnDate,request.Descriptions);

            await _repository.PossessionRepository.Create(possesionCategories);
            var result = await _repository.Save() > 0;

            if (!result) return new BaseResponse<int>(0, "Bir hata gerçekleşti");

            return new BaseResponse<int>(possesionCategories.Id);
        }

        public async Task<BaseResponse<bool>> DeletePossession(int id)
        {
            var possesionCategories = await _repository.PossessionRepository.FindById(id);
            if (possesionCategories == null) return new BaseResponse<bool>(false, "bulunamadı..");


            await _repository.PossessionRepository.Delete(possesionCategories.Id);
            var result = await _repository.Save() > 0;

            return new BaseResponse<bool>(result);
        }

        public async Task<BaseResponse<List<UserPossessionResponse>>> GetPossessions()
        {
            var possesionCategories = _mapper.Map<List<UserPossessionResponse>>(await _repository.PossessionRepository.GetAll());
            return new BaseResponse<List<UserPossessionResponse>>(possesionCategories);
        }

        public async Task<BaseResponse<UserPossessionResponse>> GetPossessionById(int id)
        {
            var possesionCategories = _mapper.Map<UserPossessionResponse>(await _repository.PossessionRepository.FindById(id));
            return new BaseResponse<UserPossessionResponse>(possesionCategories);
        }

        public async Task<BaseResponse<int>> UpdatePossession([FromBody] UserPossessionRequest request)
        {
            var possesionCategories = await _repository.PossessionRepository.FindById(request.Id);
            if (possesionCategories == null) return new BaseResponse<int>(0, " bulunamadı..");

            possesionCategories.SetBaseInformation(request.PossessionCategoryId,request.UserId, request.SerialNumber, request.IssueDate, request.ReturnDate, request.Descriptions);
            _repository.PossessionRepository.Update(possesionCategories);
            var result = await _repository.Save() > 0;

            if (!result) return new BaseResponse<int>(0, "Bir hata gerçekleşti");

            return new BaseResponse<int>(possesionCategories.Id);
        }
    }
}
