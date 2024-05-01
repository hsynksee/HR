using AutoMapper;
using HR.Data.Abstractions;
using HR.Data.DocumentFolder;
using HR.Data.Entities;
using HR.Data.Enums;
using HR.Service.Request.UserDemand;
using HR.Service.Response.UserDemand;
using HR.Service.ServiceInterfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Abstractions;
using SharedKernel.FileUploader.Models;

namespace HR.Service.ServiceInterfaces
{
    public class UserDemandService : BaseAppService, IUserDemandService
    {

        private IFileWriter _fileWriter;

        public UserDemandService(IFileWriter fileWriter, IMapper mapper, IRepositoryWrapper repository, IAppSettings appSettings) : base(mapper, repository, appSettings)
        {
            _fileWriter = fileWriter;
        }

        #region Leave
        public async Task<BaseResponse<int>> CreateLeave([FromBody] UserLeaveCreateRequest request)
        {
            DateTime overTime = CalculateOverTime(request.EndDate);
            int leaveTypeIdAsInt = (int)request.LeaveTypeId;
            var leave = new UserLeave().SetBaseInformation(
                request.UserId,
                request.LeaveTypeId,
                request.StartDate,
                request.EndDate,
                request.Description,
                overTime,
                request.TemporaryUserId,
                StatusTypeEnum.WaitingApproved,
                0);

            try
            {
                await _repository.UserLeaveRepository.Create(leave);
                await _repository.Save();
            }
            catch (Exception ex)
            {
                var a = ex;
            }


            return new BaseResponse<int>(leave.Id);
        }

        private DateTime CalculateOverTime(DateTime endDate)
        {
            DateTime overTime;
            var dt = endDate;

            if (dt.Hour >= 18)
            {
                dt = new DateTime(dt.Year, dt.Month, dt.Day, 08, 30, 00);
                if (dt.AddDays(1).DayOfWeek == DayOfWeek.Saturday)
                    overTime = dt.AddDays(3);
                else if (dt.AddDays(1).DayOfWeek == DayOfWeek.Sunday)
                    overTime = dt.AddDays(2);
                else
                    overTime = dt.AddDays(1);
            }
            else if (dt.Hour == 12 && dt.Minute == 30)
                overTime = dt.AddHours(1);
            else
                overTime = dt;

            return overTime;
        }

        public async Task<BaseResponse<List<UserLeaveListResponse>>> GetLeaveByUserId(int id)
        {
            var leaves = _mapper.Map<List<UserLeaveListResponse>>(await _repository.UserLeaveRepository.FindByUserId(id));
            return new BaseResponse<List<UserLeaveListResponse>>(leaves);
        }

        public async Task<BaseResponse<int>> UpdateUserLeave([FromBody] UserLeaveUpdateRequest request)
        {

            var leaveToUpdate = await _repository.UserLeaveRepository.FindById(request.Id);

            if (leaveToUpdate == null)
            {
                return new BaseResponse<int>(0, "Güncellenecek izin bulunamadı.");
            }

            leaveToUpdate.SetBaseInformation(request.UserId, request.LeaveTypeId, request.StartDate, request.EndDate, request.Description, request.OvertimeStart, request.TemporaryUserId, request.Status, request.LeavePeriod);
            _repository.UserLeaveRepository.Update(leaveToUpdate);
            var result = await _repository.Save() > 0;
            await _repository.Save();

            return new BaseResponse<int>(leaveToUpdate.Id);
        }

        public async Task<BaseResponse<bool>> DeleteUserLeave(int id)
        {

            var deleteUserLeave = await _repository.UserLeaveRepository.FindById(id);
            if (deleteUserLeave == null) return new BaseResponse<bool>(false, "İzin bulunamadı..");

            await _repository.UserLeaveRepository.Delete(deleteUserLeave.Id);
            var result = await _repository.Save() > 0;

            return new BaseResponse<bool>(result);
        }
        public async Task<BaseResponse<UserLeaveListResponse>> GetUserLeaveById(int id)
        {
            var leaves = _mapper.Map<UserLeaveListResponse>(await _repository.UserLeaveRepository.FindById(id));
            return new BaseResponse<UserLeaveListResponse>(leaves);
        }
        #endregion

        #region AdvancePayment
        public async Task<BaseResponse<int>> CreateAdvancePayment([FromBody] AdvancePaymentCreateRequest request)
        {
            var advancePayment = new AdvancePayment().SetBaseInformation(
                request.UserId,
                request.Price,
                request.Date,
                request.Installment,
                request.Description);

            await _repository.AdvancePaymentRepository.Create(advancePayment);
            await _repository.Save();

            return new BaseResponse<int>(advancePayment.Id);
        }

        public async Task<BaseResponse<List<AdvancePaymentListResponse>>> GetAdvancePaymentByUserId(int id)
        {
            var advancePayments = _mapper.Map<List<AdvancePaymentListResponse>>(await _repository.AdvancePaymentRepository.FindByUserId(id));
            return new BaseResponse<List<AdvancePaymentListResponse>>(advancePayments);
        }
        #endregion

        #region Expense
        public async Task<BaseResponse<int>> CreateExpense([FromForm] ExpenseCreateRequest request)
        {
            var fileInfoArray = request.ReceiptDocument.FileName.Split('.');
            var extension = fileInfoArray[request.ReceiptDocument.FileName.Split('.').Length - 1];
            var fileUrl = await _fileWriter.Upload(new UploadModel
            {
                File = request.ReceiptDocument,
                Folder = $"{DocumentFolder.ReceiptDocument}\\{request.UserId}",
                UploadPath = _appSettings.JwtSettings.UploadPath,
                ReturnDomain = _appSettings.JwtSettings.ReturnDomain
            });

            var expense = new Expense().SetBaseInformation(
                request.UserId,
                fileUrl.Data.Url,
                extension,
                request.CategoryId,
                request.Price,
                request.ReceiptDate,
                request.TaxRate,
                request.Description,
                request.Message);
                
            await _repository.ExpenseRepository.Create(expense);
            await _repository.Save();

            return new BaseResponse<int>(expense.Id);
        }

        public async Task<BaseResponse<List<ExpenseListResponse>>> GetExpenseByUserId(int id)
        {
            var expenses = _mapper.Map<List<ExpenseListResponse>>(await _repository.ExpenseRepository.FindByUserId(id));
            return new BaseResponse<List<ExpenseListResponse>>(expenses);
        }
        #endregion

        #region Overtime
        public async Task<BaseResponse<int>> CreateOvertime([FromBody] OvertimeCreateRequest request)
        {
            var overtime = new Overtime().SetBaseInformation(
                request.UserId,
                request.StartDate,
                request.DurationHour,
                request.DurationMinute,
                request.Description);
                
            await _repository.OvertimeRepository.Create(overtime);
            await _repository.Save();

            return new BaseResponse<int>(overtime.Id);
        }

        public async Task<BaseResponse<List<OvertimeListResponse>>> GetOvertimeByUserId(int id)
        {
            var overtimes = _mapper.Map<List<OvertimeListResponse>>(await _repository.OvertimeRepository.FindByUserId(id));
            return new BaseResponse<List<OvertimeListResponse>>(overtimes);
        }
        #endregion
    }
}
