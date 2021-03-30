using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupAssignment.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public int SpotsAvailable { get; set; }
        [InverseProperty("JoinedEvents")]
        public List<MyUser> Attendees { get; set; }
        [InverseProperty("HostedEvents")]
        public MyUser Organizer { get; set; }
    }
}
