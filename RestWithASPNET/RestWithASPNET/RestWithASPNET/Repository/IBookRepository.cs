using RestWithASPNET.Model;
using System.Collections.Generic;

namespace RestWithASPNET.Repository
{
    public interface IBookRepository
    {

        Book Create(Book book);

        Book Update(Book book);

        void Delete(long id);
        List<Book> FindAll();
        Book FindByID(long id);

        bool Exists(long id);

    }
}
