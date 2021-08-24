using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Controllers
{
    [Route("api/Publisher")]
    [ApiController]
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }

        //[HttpGet]
        //public JsonResult GetAll()
        //{
        //    return Json(new { data =  _db.Publisher.ToList() });
        //}

        [HttpGet]
        public async Task<JsonResult> GetAllAsync()
        {
            return Json(new { data = await _db.Publisher.ToListAsync()});
        }
    }
}
