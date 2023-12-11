using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entities
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public int? RoomID { get; set; }
        public Room Room { get; set; } // Navigation property
        public List<Appointment> Appointments { get; set; } = new List<Appointment>(); // Navigation property
    }

}
