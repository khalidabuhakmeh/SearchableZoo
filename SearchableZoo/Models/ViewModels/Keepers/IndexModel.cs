using System.Linq;
using PagedList;
using SearchableZoo.Models.Objects;

namespace SearchableZoo.Models.ViewModels.Keepers
{
    public class IndexModel
    {
        public SearchModel Search { get; set; }

        public IndexModel(SearchModel search)
        {
            Search = search;
            Keepers = new PagedList<KeeperViewModel>(Enumerable.Empty<KeeperViewModel>(), 1, 10);
        }

        public IPagedList<KeeperViewModel> Keepers { get; set; }
    }

    public class KeeperViewModel
    {
        public int KeeperId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SexTypes Sex { get; set; }
    }
}