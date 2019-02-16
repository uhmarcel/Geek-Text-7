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
        private List<string> genre { get; set; }
        private string title { get; set; }
        private string description { get; set; }
        private PublishingInfo publishingInfo { get; set; }
        private List<Author> bookAuthor { get; set; }
        private float bookRating { get; set; }
        private List<string> userComment { get; set; }
        private double price { get; set; }
        private int ISBN { get; set; }
    }

}