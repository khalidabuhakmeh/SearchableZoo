using System.Collections.Generic;
using System.Linq;

namespace SearchableZoo.Models.Objects
{
    public class Animal
    {
        public Animal()
        {
            Sex = SexTypes.Unspecified;
            Keepers = Enumerable.Empty<Keeper>().ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public SexTypes Sex { get; set; }
        public virtual IList<Keeper> Keepers { get; set; }
    }
}