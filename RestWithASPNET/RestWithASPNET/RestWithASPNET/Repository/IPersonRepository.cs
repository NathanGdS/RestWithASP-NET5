using RestWithASPNET.Model;
using System.Collections.Generic;

namespace RestWithASPNET.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
        List<Person> FindAll(); 
        Person FindByID(long id);

        bool Exists(long id);

        bool Error();
    }
}
