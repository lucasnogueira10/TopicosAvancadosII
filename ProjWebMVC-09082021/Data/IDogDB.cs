using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDogDB
    {
        bool Insert(Dog dog);
        List<Dog> Select();

        bool Update(Dog dog);

        Dog SelectById(int id);

        bool Delete(int id);

    }
}
