using System;
using System.Runtime.Serialization;

namespace UdemyCurso.Data.VO
{
    //[DataContract]
    public class BookVO
    {
        //[DataMember(Order = 1, Name ="Codigo")]
        public long? Id { get; set; }

        //[DataMember(Order = 2, Name = "Autor")]
        public string Author { get; set; }

        //[DataMember(Order = 3, Name = "Data")]
        public DateTime LaunchDate { get; set; }

        //[DataMember(Order = 5, Name = "Valor")]
        public Decimal Price { get; set; }

        //[DataMember(Order = 4, Name = "Titulo")]
        public string Title { get; set; }
    }
}
