using HR.Api.Infrastructure.Abstractions;
using HR.Data.RepositoryInterfaces.Interfaces;
using HR.Service.ServiceInterfaces.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    [AllowAnonymous]
    public class LocationController : BaseController
    {
        private readonly ILocationService _locationService;

        public LocationController(ISystemAppService systemAppService, ILocationService locationService) : base(systemAppService)
        {
            _locationService = locationService;
        }

        [HttpGet("GetCountries")]
        public async Task<IActionResult> GetCountries() => Ok(await _locationService.GetCountries());

        [HttpGet("GetCitiesByCountryId")]
        public async Task<IActionResult> GetCitiesByCountryId(int countryId) => Ok(await _locationService.GetCitiesByCountryId(countryId));

        [HttpGet("GetDistrictiesByCityId")]
        public async Task<IActionResult> GetDistrictiesByCityId(int cityId) => Ok(await _locationService.GetDistrictiesByCityId(cityId));
    }
}
