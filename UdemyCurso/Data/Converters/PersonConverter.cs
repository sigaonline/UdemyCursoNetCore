﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCurso.Data.Converter;
using UdemyCurso.Data.VO;
using UdemyCurso.Model;

namespace UdemyCurso.Data.Converters
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origin)
        {
            if (origin == null) return new Person();

            return new Person
            {
                Id = origin.Id,
                FirstNAme = origin.FirstNAme,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender

            };
        }

        public PersonVO Parse(Person origin)
        {
            if (origin == null) return new PersonVO();

            return new PersonVO
            {
                Id = origin.Id,
                FirstNAme = origin.FirstNAme,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender

            };
        }

        public List<Person> ParseList(List<PersonVO> origin)
        {
            if (origin == null) return new List<Person>();

            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> ParseList(List<Person> origin)
        {
            if (origin == null) return new List<PersonVO>();

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
