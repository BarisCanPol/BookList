using BookListRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookListRazor.Pages.PublisherList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Publisher Publisher { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Publisher = new Publisher();

            //Create
            if (id == null)
                return Page();

            //Update
            Publisher = await _db.Publisher.FirstOrDefaultAsync(x => x.Id == id);
            if (Publisher == null)
                return NotFound();

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Publisher.Id == 0)
                    _db.Publisher.Add(Publisher);
                else
                    _db.Publisher.Update(Publisher);

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
