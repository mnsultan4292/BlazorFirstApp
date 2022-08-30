using System;
using System.Collections.Generic;

namespace BlazorFirstApp.Shared.Models
{
    public class MasterBook
    {
        public int BookId { get; set; }
        public string BookName { get; set; } = null!;
        public string BookAuthor { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public DateTime PurchaseDate { get; set; }
    }
}
