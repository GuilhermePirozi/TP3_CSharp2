using CityBreaks.Models;
using CityBreaks.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityBreaks.Pages {
    public class FilterPropertiesModel : PageModel {
        private readonly PropertyService _service;

        public FilterPropertiesModel(PropertyService service) {
            _service = service;
        }

        [BindProperty(SupportsGet = true)]
        public string PropertyName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CityName { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? MinPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? MaxPrice { get; set; }

        public List<Property> Properties { get; set; }

        public async Task OnGetAsync() {
            Properties = await _service.GetFilteredAsync(MinPrice, MaxPrice, CityName, PropertyName);
        }
    }
}
