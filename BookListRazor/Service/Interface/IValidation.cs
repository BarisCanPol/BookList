using BookListRazor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Service.Interface
{
    public interface IValidation<T> where T:new()
    {
        ResultInfo ValidateDeletion(T entity);
    }
}
