using System.Collections.Generic;
using System.Linq;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;
using SearchableZoo.Models.Objects;

namespace SearchableZoo.Models.Search
{
    public class Animal
    {
        public Animal()
        {
            Keepers = new List<string>();
        }

        public Animal(Objects.Animal animal)
        {
            Id = string.Format("animals-search-{0}", animal.Id);
            AnimalId = animal.Id;
            Name = animal.Name;
            Species = animal.Species;
            Age = animal.Age;
            Keepers = animal.Keepers.Select(x => string.Format("{0} {1}", x.FirstName, x.LastName)).ToList();
        }

        public string Id { get; set; }
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public SexTypes Sex { get; set; }
        public IList<string> Keepers { get; set; }   
    }

    public class AnimalIndex : AbstractIndexCreationTask<Animal, AnimalIndex.Result>
    {
        public class Result : Animal 
        {
            public object[] Search { get; set; }
        }

        public AnimalIndex()
        {
            Map = animals => from a in animals
                select new
                {
                    a.Id,
                    a.AnimalId,
                    a.Name,
                    a.Species,
                    a.Age,
                    a.Sex,
                    Search = new object[] {a.Name, a.Species, a.Age, a.Sex, a.Keepers}
                };

              Index(a => a.Search, FieldIndexing.Analyzed);
        }
    }
}