namespace DbOpeartionWithCore.Data
{
    public class Currancy
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<BookPrice> BookPrice { get; set; }

    }
}
