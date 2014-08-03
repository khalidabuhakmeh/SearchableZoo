using System.Collections.Generic;
using System.Linq;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;
using SearchableZoo.Models.Objects;

namespace SearchableZoo.Models.Search
{
    public class Keeper
    {
        public Keeper()
        {
            Animals = new List<string>();
        }

        public Keeper(Objects.Keeper keeper)
        {
            Id = string.Format("keepers-search-{0}", keeper.Id);
            KeeperId = keeper.Id;
            FirstName = keeper.FirstName;
            LastName = keeper.LastName;
            YearsExperience = keeper.YearsExperience;
            Speciality = keeper.Speciality;
            Sex = keeper.Sex;
            Animals = keeper.Animals.Select(x => string.Format("{0} ({1})", x.Name, x.Species)).ToList();
        }

        public string Id { get; set; }
        public int KeeperId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearsExperience { get; set; }
        public string Speciality { get; set; }
        public SexTypes Sex { get; set; }
        public IList<string> Animals { get; set; }
    }

    public class KeeperIndex : AbstractIndexCreationTask<Search.Keeper,KeeperIndex.Result>
    {
        public class Result : Keeper
        {
            public object[] Search { get; set; }
        }

        public KeeperIndex()
        {
            Map = keepers => from k in keepers
                select new
                {
                    k.KeeperId,
                    k.FirstName,
                    k.LastName,
                    k.YearsExperience,
                    k.Speciality,
                    k.Sex,
                    k.Animals,
                    Search = new object[] {k.FirstName, k.LastName, k.Speciality, k.Sex, k.Animals}
                };

            Index(x => x.Search, FieldIndexing.Analyzed);
        }
    }
}