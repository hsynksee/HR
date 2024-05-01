using HR.Service.Response.Location;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.ServiceInterfaces.Interfaces
{
    public interface ILocationService
    {
        Task<BaseResponse<List<CountryResponse>>> GetCountries();
        Task<BaseResponse<List<CityResponse>>> GetCitiesByCountryId(int countryId);
        Task<BaseResponse<List<DistrictResponse>>> GetDistrictiesByCityId(int cityId);
    }
}
