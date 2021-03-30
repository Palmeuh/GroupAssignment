using System.Collections.Generic;

namespace GroupAssignment.Models
{
    public class Organizer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public List<Event> Events { get; set; }
    }
}