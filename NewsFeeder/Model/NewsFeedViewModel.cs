namespace NewsFeederHelper.Model
{
    public class NewsFeedViewModel
    {
        public List<string> NewsCategories { get; set; }
        public List<string> Countries { get; set; }
        public NewsResponseModel NewsFeed {  get; set; }
        public string NewsCategory { get; set; }
        public string Country { get; set; }

    }
}
