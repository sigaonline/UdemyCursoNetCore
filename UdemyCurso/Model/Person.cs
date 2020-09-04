using UdemyCurso.Model.Base;

namespace UdemyCurso.Model
{
    public class Person : BaseEntity
    {
        public string FirstNAme { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
