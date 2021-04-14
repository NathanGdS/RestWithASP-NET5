using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using System.Collections.Generic;

namespace RestWithASPNET.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        void Delete(long id);
        List<PersonVO> FindAll();
        PersonVO FindByID(long id);
        
    }
}
