namespace SearchableZoo.Models.ViewModels.Keepers
{
    public class SearchModel
    {
        public SearchModel()
        {
            Page = 1;
            Size = 10;
        }

        public int Size { get; set; }
        public int Page { get; set; }
        public string Query { get; set; }

        public bool HasQuery
        {
            get { return !string.IsNullOrWhiteSpace(Query); }
        }
    }
}