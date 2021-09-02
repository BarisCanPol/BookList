using BookListRazor.Data;
using BookListRazor.Model.Common;
using BookListRazor.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly AuthorService _authorService;

        public AuthorController(ApplicationDbContext db,AuthorService authorService)
        {
            _db = db;
            _authorService = authorService;
        }
        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            return Json(new { data = await _db.Author.ToListAsync() });
        }

        [HttpGet]
        public JsonResult GetAuthorCombo()
        {
            var list = _db.Author.Select(x => new IdTextPair { id = x.Id, text = x.AuthorName }).ToList();

            return Json(list);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _db.Author.FindAsync(id);
            if (record is null)
                return Json(new { success = false, message = "Error while deleting" });

            var result = _authorService.ValidateDeletion(record);

            if(!result.Result)
                return Json(new { success = false, message = result.Message });

            _db.Author.Remove(record);

            await _db.SaveChangesAsync();

            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
