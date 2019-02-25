using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GeekTextLibrary.PublishingInfo;
using static GeekTextLibrary.Author;

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