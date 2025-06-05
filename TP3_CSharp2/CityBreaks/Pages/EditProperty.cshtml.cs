using CityBreaks.Data;
using CityBreaks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CityBreaks.Pages
{
    public class EditPropertyModel : PageModel
    {
        private readonly CityBreaksContext _context;

        public EditPropertyModel(CityBreaksContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Property Property { get; set; }
        public SelectList Cities { get; set; }

        public async Task OnGetAsync(int id)
        {
            var cityList = await _context.Cities.ToListAsync();
            Cities = new SelectList(cityList, "Id", "Name");
            Property = _context.Properties.Find(id);
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid) {
                Property.Id = id;
                _context.Properties.Update(Property);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/Index");

        }
    }
}
