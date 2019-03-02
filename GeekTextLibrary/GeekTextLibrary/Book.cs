using System.Collections.Generic;

namespace GeekTextLibrary
{
    public class Book
    {
        public string genre { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public PublishingInfo publishingInfo { get; set; }
        public Author bookAuthor { get; set; }
        public float bookRating { get; set; }
        public List<string> userComment { get; set; }
        public double price { get; set; }
        public string ISBN { get; set; }
        public byte[] bookCover { get; set; }
        public string bestSeller { get; set; }
    }

}