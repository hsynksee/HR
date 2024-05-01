using AutoMapper;
using HR.Data.Abstractions;
using SharedKernel.Abstractions;
using SharedKernel.Models;

namespace HR.Service.ServiceInterfaces
{
    public abstract class BaseAppService
    {
        protected readonly IMapper _mapper;
        protected readonly IRepositoryWrapper _repository;
        protected readonly IAppSettings _appSettings;

        protected CurrentUser currentUser;
        public BaseAppService(IMapper mapper,
                              IRepositoryWrapper repository,
                              IAppSettings appSettings)
        {
            _mapper = mapper;
            _repository = repository;
            _appSettings = appSettings;

            //var user = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(w => w.Type == "user")?.Value;
            //if (user != null)
            //{
            //    var res = JsonConvert.DeserializeObject<CurrentUser>(user);
            //    currentUser = _mapper.Map<CurrentUser>(_repository.UserRepository.FindById(res.Id).Result);
            //}
        }
    }
}
