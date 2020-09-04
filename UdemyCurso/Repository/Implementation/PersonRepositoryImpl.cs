using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCurso.Model;
using UdemyCurso.Model.Context;

namespace UdemyCurso.Repository.Implementation
{
    public class PersonRepositoryImpl : IPersonRepository
    {

        private MySQLContext _context;
        public PersonRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return person;
        }

        public void Delete(long id)
        {
            try
            {

                var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
                if (result != null)
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindBy(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

        }

        public Person Update(Person person)
        {
            try
            {
                if (!Exists(person.Id)) return null;

                var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return person;
        }

        public bool Exists(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
            
        }
    }
}
