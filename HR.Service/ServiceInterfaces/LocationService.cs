using AutoMapper;
using HR.Data.Abstractions;
using HR.Service.Request.User;
using HR.Service.Response.Location;
using HR.Service.ServiceInterfaces.Interfaces;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.ServiceInterfaces
{
    public class LocationService : BaseAppService, ILocationService
    {
        public LocationService(IMapper mapper, IRepositoryWrapper repository, IAppSettings appSettings) : base(mapper, repository, appSettings)
        {
        }

        public async Task<BaseResponse<List<CountryResponse>>> GetCountries()
        {
            var countries = _mapper.Map<List<CountryResponse>>(await _repository.CountryRepository.GetAll());
            return new BaseResponse<List<CountryResponse>>(countries);
        }

        public async Task<BaseResponse<List<CityResponse>>> GetCitiesByCountryId(int countryId)
        {
            var cities = _mapper.Map<List<CityResponse>>(await _repository.CityRepository.GetCitiesByCountryId(countryId));
            return new BaseResponse<List<CityResponse>>(cities);
        }

        public async Task<BaseResponse<List<DistrictResponse>>> GetDistrictiesByCityId(int cityId)
        {
            var districts = _mapper.Map<List<DistrictResponse>>(await _repository.DistrictRepository.GetDistrictiesByCityId(cityId));
            return new BaseResponse<List<DistrictResponse>>(districts);
        }
    }
}
