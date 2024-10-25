namespace BookStore.WebApp.Models
{
    public class BookViewModel
    {
        public string Name { get; set; }
        public string BookType { get; set; }
        public string AuthorNameSurname { get; set; }
        public short PublisedDate { get; set; }
        public string Publisher { get; set; }
        public short PageNumber { get; set; }
        public bool isActive { get; set; }
    }
}
