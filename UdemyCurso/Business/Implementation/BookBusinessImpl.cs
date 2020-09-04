using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCurso.Model;
using UdemyCurso.Model.Context;
using UdemyCurso.Repository;
using UdemyCurso.Repository.Generic;

namespace UdemyCurso.Business.Implementation
{

    public class BookBusinessImpl : IBookBusiness
    {
        private IRepository<Book> _repository;
        public BookBusinessImpl(IRepository<Book> context)
        {
            _repository = context;
        }
        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
                _repository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindBy(long id)
        {
            return _repository.FindBy(id);

        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
