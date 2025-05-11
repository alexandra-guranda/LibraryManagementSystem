using System;

namespace LibraryManagementSystem.Models
{
    public class WaitlistEntry
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}
