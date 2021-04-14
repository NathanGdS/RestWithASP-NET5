using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using System.Collections.Generic;

namespace RestWithASPNET.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO person);
        BookVO Update(BookVO person);
        void Delete(long id);
        List<BookVO> FindAll();
        BookVO FindByID(long id);
        
    }
}
