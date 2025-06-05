using CityBreaks.Models;
using CityBreaks.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CityBreaks.Pages {
    public class CityDetailsModel : PageModel {
        private readonly ICityService _cityService;
        private readonly PropertyService _propertyService;

        public CityDetailsModel(ICityService cityService, PropertyService propertyService) {
            _cityService = cityService;
            _propertyService = propertyService;
        }

        public City City { get; set; }

        public async Task<IActionResult> OnGetAsync(string name) {
            if (string.IsNullOrEmpty(name))
                return NotFound();

            City = await _cityService.GetByNameAsync(name);

            if (City == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id, string name) {
            await _propertyService.DeleteAsync(id);
            return RedirectToPage(new { name }); 
        }
    }
}
