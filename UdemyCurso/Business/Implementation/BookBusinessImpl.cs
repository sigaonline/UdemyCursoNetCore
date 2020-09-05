using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCurso.Data.Converters;
using UdemyCurso.Data.VO;
using UdemyCurso.Model;
using UdemyCurso.Model.Context;
using UdemyCurso.Repository;
using UdemyCurso.Repository.Generic;

namespace UdemyCurso.Business.Implementation
{

    public class BookBusinessImpl : IBookBusiness
    {
        private IRepository<Book> _repository;
        private readonly BookConverter _converter;
        public BookBusinessImpl(IRepository<Book> context)
        {
            _repository = context;
            _converter = new BookConverter();
        }
        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
                _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public BookVO FindBy(long id)
        {
            return _converter.Parse(_repository.FindBy(id));

        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }
    }
}
