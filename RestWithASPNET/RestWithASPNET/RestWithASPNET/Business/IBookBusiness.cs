using RestWithASPNET.Model;
using System.Collections.Generic;

namespace RestWithASPNET.Business
{
    public interface IBookBusiness
    {
        Book Create(Book person);
        Book Update(Book person);
        void Delete(long id);
        List<Book> FindAll();
        Book FindByID(long id);
        
    }
}
