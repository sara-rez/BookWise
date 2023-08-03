namespace BookWise.API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
