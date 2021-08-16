
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Dog : Pet
    {
        public const String INSERT = "INSERT INTO TB_DOG (name) VALUES ('{0}')";
        public const String UPDATE = "UPDATE TB_DOG SET name = '{0}' WHERE id = {1}";
        public const String DELETE = "DELETE FROM TB_DOG WHERE id = {0}";
        public const String SELECT = "SELECT id, name FROM TB_DOG";
        public const String SELECTBYID = "SELECT id, name FROM TB_DOG WHERE id = {0}";
    }
}
