using System;
using System.Collections.Generic;

namespace BlazorFirstApp.Server.Models
{
    public partial class NewTab
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
