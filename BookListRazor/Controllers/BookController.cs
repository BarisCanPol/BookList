using BookListRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _db.Book.AsNoTracking()
                .Select(b => new Model.Book.BookGrid
                {
                    Id = b.Id,
                    AuthorName = b.Author.AuthorName,
                    ISBN = b.ISBN,
                    Name = b.Name,
                    PublisherId = b.PublisherId,
                    PublisherName = b.Publisher.Name
                })
                .ToList();

            return Json(new { data = list });

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _db.Book.FindAsync(id);
            if (record is null)
                return Json(new { success = false, message = "Error while deleting" });

            _db.Book.Remove(record);

            await _db.SaveChangesAsync();

            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
