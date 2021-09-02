using BookListRazor.Data;
using BookListRazor.Service.Interface;
using BookListRazor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Service
{
    public class AuthorService : IValidation<Author>
    {
        private readonly ApplicationDbContext _db;

        public AuthorService(ApplicationDbContext db)
        {
            _db = db;
        }

        public  ResultInfo ValidateDeletion(Author entity)
        {
            var books = _db.Book.Where(x => x.AuthorId == entity.Id).ToList();

            if (books != null)
                return new ResultInfo(false, "This record used in a Book");

            return new ResultInfo(true, "");
        }
   
    }
}
