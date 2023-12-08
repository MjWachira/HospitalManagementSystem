
using HospitalManagementSystem.CRUD;

Console.WriteLine("Hello, World!");
//DoctorOperations doctorOperations = new DoctorOperations();
//doctorOperations.AddDoctor();
//doctorOperations.ViewDoctors();
//doctorOperations.UpdateDoctor();
//doctorOperations.DeleteDoctor();

/*
RoomOperations roomOperations = new RoomOperations();
roomOperations.AddRoom();
roomOperations.ViewRooms();
roomOperations.UpdateRoom();
roomOperations.DeleteRoom();
*/


/*
PatientsOperations patientsOperations = new PatientsOperations();
patientsOperations.AddPatient();
patientsOperations.ViewPatient();
patientsOperations.UpdatePatient();
patientsOperations.DeletePatient();
*/


AppointmentOperations appointmentOperations = new AppointmentOperations();
appointmentOperations.MakeAppointment();
appointmentOperations.ViewAppointments();
appointmentOperations.UpdateAppointment();
appointmentOperations.DeleteAppointment();