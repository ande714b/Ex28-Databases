using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28_Databases
{
    public class Controller
    {
        Database _database = new Database();

        internal void InsertPet(string petName, string petType, string petBreed, DateTime birth, double petWeight, int ownerPK)
        {
            _database.InsertPet(petName, petType, petBreed, birth, petWeight, ownerPK);
        }

        internal List<List<string>> ShowPets()
        {
           return _database.GetPets();
        }

        internal List<string> ShowOwnerByLastName(string lastname)
        {
           return _database.GetOwnerByLastName(lastname);
        }

        internal List<string> ShowOwnerByEmail(string email)
        {
           return _database.GetOwnerByEmail(email);
        }

        internal List<List<string>> ShowPets(int id)
        {
           return _database.GetPets(id);
        }
    }
}
