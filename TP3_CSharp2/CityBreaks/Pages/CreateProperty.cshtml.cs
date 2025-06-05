using CityBreaks.Data;
using CityBreaks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CityBreaks.Pages {
    public class CreatePropertyModel : PageModel {
        private readonly CityBreaksContext _context;

        public CreatePropertyModel(CityBreaksContext context) {
            _context = context;
        }

        [BindProperty]
        public Property Property { get; set; }

        public SelectList Cities { get; set; } 

        public async Task OnGetAsync() {
            await CarregarCidadesAsync();
        }

        private async Task CarregarCidadesAsync() {
            var cityList = await _context.Cities.ToListAsync();
            Cities = new SelectList(cityList, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                await _context.Properties.AddAsync(Property);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Index");
        }
    }
}
