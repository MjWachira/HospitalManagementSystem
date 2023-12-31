﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entities
{
    public class Doctor
    {

        [Key]
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string DocSpecialty { get; set; }
        public List<Appointment> Appointments { get; set; } = new List<Appointment>(); // Navigation property
    
    }
}
