using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBHRepro.Data
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public string TaxIdentifier { get; set; }
        public int? ContactId { get; set; }
        public Contact Contact { get; set; }
    }

    public class Person : Entity
    {
    }

    public class Business : Entity
    {
    }

    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Person Person { get; set; }
        public ICollection<Entity> Entities { get; set; }
    }
}
