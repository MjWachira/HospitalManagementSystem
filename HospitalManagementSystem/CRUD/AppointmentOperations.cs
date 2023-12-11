using HospitalManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.CRUD
{
    public class AppointmentOperations
    {
        public void MakeAppointment()
        {
            try {
                DoctorOperations doctorOperations = new DoctorOperations();
                doctorOperations.ViewDoctors();
                PatientsOperations patientsOperations = new PatientsOperations();
                patientsOperations.ViewPatients();
                Console.WriteLine("To Make Appointment::");

                Console.WriteLine("Enter Doctor ID");
                int docID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Patient ID");
                int patID = int.Parse(Console.ReadLine());
                using (var context = new HospitalDBContext())
                {

                    var selectedDoctor = context.Doctors.FirstOrDefault(d => d.DoctorID == docID);
                    var selectedPatient = context.Patients.FirstOrDefault(p => p.PatientID == patID);

                    if (selectedDoctor != null && selectedPatient != null)
                    {
                        var newAppointment = new Appointment
                        {
                            AppointmentDate = new DateOnly(2023, 12, 15),
                            AppointmentTime = new TimeOnly(11, 30),
                            PatientID = patID,
                            DoctorID = docID
                        };

                        context.Appointments.Add(newAppointment);


                        context.SaveChanges();

                        Console.WriteLine("Appointment Added Successfully...");
                    }
                    else
                    {
                        Console.WriteLine("not completed becouse the IDs do not exsist...");
                    }
                }
            } catch (Exception ex) { Console.WriteLine($"Error occored due to {ex.Message}"); }
      
        }
        public void ViewAppointments()
        {
            try {
                using (var context = new HospitalDBContext())
                {
                    var allAppointments = (from appointment in context.Appointments
                                           join patient in context.Patients on appointment.PatientID equals patient.PatientID
                                           join doctor in context.Doctors on appointment.DoctorID equals doctor.DoctorID
                                           select new
                                           {
                                               Appointment = appointment,
                                               Patient = patient,
                                               Doctor = doctor
                                           })
                                          .ToList();

                    if (allAppointments.Count > 0)
                    {
                        Console.WriteLine("All Appointments:");

                        foreach (var appointmentInfo in allAppointments)
                        {
                            var appointmentDetails = appointmentInfo.Appointment;
                            var patientDetails = appointmentInfo.Patient;
                            var doctorDetails = appointmentInfo.Doctor;

                            Console.WriteLine($"Appointment ID: {appointmentDetails.AppointmentID}");
                            Console.WriteLine($"Date: {appointmentDetails.AppointmentDate}, Time: {appointmentDetails.AppointmentTime}");
                            Console.WriteLine($"Patient: {patientDetails.FirstName} {patientDetails.LastName}");
                            Console.WriteLine($"Doctor: {doctorDetails.DoctorName}");

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No appointments found in the database.");
                    }
                }

            } catch (Exception ex) { Console.WriteLine($"Error occored due to{ex.Message}"); }
            
        }

        public void UpdateAppointment()
        {
            try {
                using (var context = new HospitalDBContext())
                {
                    ViewAppointments();
                    DoctorOperations doctorOperations = new DoctorOperations();
                    doctorOperations.ViewDoctors();
                    PatientsOperations patientsOperations = new PatientsOperations();
                    patientsOperations.ViewPatients();
                    Console.WriteLine("Enter Appointment ID to Update");
                    int appID = int.Parse(Console.ReadLine());

                    var appointmentToUpdate = context.Appointments.Find(appID);

                    Console.WriteLine("Enter Doctor ID");
                    int docID = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Patient ID");
                    int patID = int.Parse(Console.ReadLine());

                    if (appointmentToUpdate != null)
                    {

                        appointmentToUpdate.AppointmentDate = new DateOnly(2023, 12, 20);
                        appointmentToUpdate.AppointmentTime = new TimeOnly(14, 45);
                        appointmentToUpdate.PatientID = patID;
                        appointmentToUpdate.DoctorID = docID;


                        context.SaveChanges();
                        Console.WriteLine("Appointment  wass Updated ....");
                    }
                    else
                    {
                        Console.WriteLine("ID not found");
                    }
                }
            } catch (Exception ex) { Console.WriteLine($"Error occored due to{ex.Message}"); }
            


        }
        public void DeleteAppointment()
        {
            try {
                using (var context = new HospitalDBContext())
                {
                    Console.WriteLine("Enter Appointment ID to delete");
                    int appID = int.Parse(Console.ReadLine());
                    var appointmentToDelete = context.Appointments.Find(appID);

                    if (appointmentToDelete != null)
                    {

                        context.Appointments.Remove(appointmentToDelete);

                        context.SaveChanges();
                        Console.WriteLine("Appointment was deleted...");
                    }
                    else
                    {
                        Console.WriteLine("ID not found");
                    }
                }
            } catch (Exception ex) { Console.WriteLine($"Error occored due to{ex.Message}"); }
            

        }
    }
}
