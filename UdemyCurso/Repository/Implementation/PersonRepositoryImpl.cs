using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCurso.Model;
using UdemyCurso.Model.Context;
using UdemyCurso.Repository.Generic;

namespace UdemyCurso.Repository.Implementation
{
    public class PersonRepositoryImpl : GenericRepository<Person>, IPersonRepository
    {

        //private MySQLContext _context;
        public PersonRepositoryImpl(MySQLContext context) : base(context)
        {
            
        }

        public List<Person> FindByName(string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(u => u.FirstNAme.Contains(firstName) && u.LastName.Contains(lastName)).ToList();
            } 
            else if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(u =>  u.LastName.Contains(lastName)).ToList();
            }
            else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(u => u.FirstNAme.Contains(firstName)).ToList();
            }
             else
            {
                return _context.Persons.ToList();
            }
        }

    }
}
