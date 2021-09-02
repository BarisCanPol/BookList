using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.Questionnaire
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private static string cookie_key_survey = "survey";

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public string Result { get; set; }
        public List<Author> AuthorList { get; set; }
        public async Task OnGet()
        {
            AuthorList = await _db.Author.ToListAsync();
            Result = Request.Cookies[cookie_key_survey];

        }

        public IActionResult OnPost(string survey)
        {
            CookieOptions option = new CookieOptions();

            option.Expires = DateTime.Now.AddMinutes(5);

            Response.Cookies.Append(cookie_key_survey, survey, option);

            return RedirectToPage(nameof(Index));
        }



        public IActionResult OnPostDelete()
        {
            CookieOptions option = new CookieOptions();

            //Give -1 to remove cookie
            option.Expires = DateTime.Now.AddMinutes(-1);

            Response.Cookies.Append(cookie_key_survey, "", option);

            return RedirectToPage(nameof(Index));
        }
    }
}
