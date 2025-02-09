namespace DbOpeartionWithCore.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NoOfPages { get; set; }
        public bool IsActive { get; set; }
        public DateTime createdOn { get; set; }
        public int LanguageId { get; set; }
        public Lanuage Language { get; set; }

    }
}
