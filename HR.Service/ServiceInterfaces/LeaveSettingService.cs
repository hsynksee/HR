using AutoMapper;
using HR.Data.Abstractions;
using HR.Data.Entities;
using HR.Data.Enums;
using HR.Service.Request.LeaveSetting;
using HR.Service.Request.User;
using HR.Service.Response.LeaveSetting;
using HR.Service.Response.User;
using HR.Service.Response.UserDemand;
using HR.Service.ServiceInterfaces.Interfaces;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HR.Service.ServiceInterfaces
{
    public class LeaveSettingService : BaseAppService, ILeaveSettingService
    {
        public LeaveSettingService(IMapper mapper, IRepositoryWrapper repository, IAppSettings appSettings) : base(mapper, repository, appSettings)
        {
        }

        public async Task<BaseResponse<int>> CreateLeaveSetting(LeaveSettingResponse request)
        {
            var newLeaveSetting = new LeaveSetting().SetBaseInformation(
                 request.LeaveTypeId,
                 request.MaxExperienceYear, 
                 request.MinExperienceYear,
                 request.NumberOfMeritDays);

            _repository.LeaveSettingRepository.Create(newLeaveSetting);
            var result = await _repository.Save() > 0;

            if (result)
            {
                return new BaseResponse<int>(newLeaveSetting.Id);
            }
            else
            {
                return new BaseResponse<int>(0, "İzin ayarı oluşturulurken bir hata oluştu.");
            }

        }

        public async Task<BaseResponse<bool>> DeleteLeaveSetting(int id)
        {
            var deleteLeaveSettings = await _repository.LeaveSettingRepository.FindById(id);
            if (deleteLeaveSettings == null) return new BaseResponse<bool>(false, "İzin bulunamadı..");

            await _repository.LeaveSettingRepository.Delete(deleteLeaveSettings.Id);
            var result = await _repository.Save() > 0;

            return new BaseResponse<bool>(result);
        }

        public async Task<BaseResponse<LeaveSettingResponse>> GetLeaveSettingById(int id)
        {
            var getLeaveSetting = _mapper.Map<LeaveSettingResponse>(await _repository.LeaveSettingRepository.FindById(id));
            return new BaseResponse<LeaveSettingResponse>(getLeaveSetting);
        }

        public async Task<BaseResponse<List<LeaveSettingResponse>>> GetLeaveSettingByLeaveType(int leaveTypeID)
        {
            var leaveSettings = await _repository.LeaveSettingRepository.GetLeaveSettingsByLeaveTypeId(leaveTypeID);
            var leaveSettingResponses = _mapper.Map<List<LeaveSettingResponse>>(leaveSettings);

            return new BaseResponse<List<LeaveSettingResponse>>(leaveSettingResponses);

        }

        public async Task<BaseResponse<List<LeaveSettingResponse>>> GetLeaveSetting()
        {
            var leaveSettings = _mapper.Map<List<LeaveSettingResponse>>(await _repository.LeaveSettingRepository.GetAll());
            return new BaseResponse<List<LeaveSettingResponse>>(leaveSettings);
        }

        public async Task<BaseResponse<int>> UpdateLeaveSetting(LeaveSettingUpdateRequest request)
        {
            
            var updateLeaveSetting = await _repository.LeaveSettingRepository.FindById(request.Id);
            if (updateLeaveSetting == null)
            {
                return new BaseResponse<int>(0, "İzin bulunamadı.");
            }

            updateLeaveSetting.SetBaseInformation(request.LeaveTypeId,request.MaxExperienceYear,request.MinExperienceYear,request.NumberOfMeritDays);
            _repository.LeaveSettingRepository.Update(updateLeaveSetting);
            var result = await _repository.Save() > 0;

            if (result)
            {
                return new BaseResponse<int>(updateLeaveSetting.Id);
            }
            else
            {
                return new BaseResponse<int>(0, "İzin ayarı güncellenirken bir hata oluştu.");
            }
        }

    }
}
