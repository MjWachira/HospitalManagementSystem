
using HospitalManagementSystem.CRUD;
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hospital Management System");

        DoctorOperations doctorOperations = new DoctorOperations();
        RoomOperations roomOperations = new RoomOperations();
        PatientsOperations patientsOperations = new PatientsOperations();
        AppointmentOperations appointmentOperations = new AppointmentOperations();

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n Manage");
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Doctors");
            Console.WriteLine("2. Rooms");
            Console.WriteLine("3. Patients");
            Console.WriteLine("4. Appointments");
            Console.WriteLine("5. Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DoctorMenu(doctorOperations);
                    break;

                case "2":
                    RoomMenu(roomOperations);
                    break;

                case "3":
                    PatientMenu(patientsOperations);
                    break;

                case "4":
                    AppointmentMenu(appointmentOperations);
                    break;

                case "5":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }

        Console.WriteLine("Exiting Hospital Management System...bye!");
    }

    static void DoctorMenu(DoctorOperations doctorOperations)
    {
        bool isDoctorMenuRunning = true;

        while (isDoctorMenuRunning)
        {
            Console.WriteLine("\nDoctor Operations:");
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. View Doctors");
            Console.WriteLine("3. Update Doctor");
            Console.WriteLine("4. Delete Doctor");
            Console.WriteLine("5. Back to Main Menu");

            string doctorChoice = Console.ReadLine();

            switch (doctorChoice)
            {
                case "1":
                    doctorOperations.AddDoctor();
                    break;

                case "2":
                    doctorOperations.ViewDoctors();
                    break;

                case "3":
                    doctorOperations.UpdateDoctor();
                    break;

                case "4":
                    doctorOperations.DeleteDoctor();
                    break;

                case "5":
                    isDoctorMenuRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }
    }

    static void RoomMenu(RoomOperations roomOperations)
    {

        bool isRoomMenuRunning = true;

        while (isRoomMenuRunning)
        {
            Console.WriteLine("\nRoom Operations:");
            Console.WriteLine("1. Add Room");
            Console.WriteLine("2. View Rooms");
            Console.WriteLine("3. Update Room");
            Console.WriteLine("4. Delete Room");
            Console.WriteLine("5. Back to Main Menu");

            string roomChoice = Console.ReadLine();

            switch (roomChoice)
            {
                case "1":
                    roomOperations.AddRoom();
                    break;

                case "2":
                    roomOperations.ViewRooms();
                    break;

                case "3":
                    roomOperations.UpdateRoom();
                    break;

                case "4":
                    roomOperations.DeleteRoom();
                    break;

                case "5":
                    isRoomMenuRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }
    }

    static void PatientMenu(PatientsOperations patientsOperations)
    {
        bool isPatientMenuRunning = true;

        while (isPatientMenuRunning)
        {
            Console.WriteLine("\nPatients Operations:");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. View Patients");
            Console.WriteLine("3. Update Patient");
            Console.WriteLine("4. Delete Patient");
            Console.WriteLine("5. Back to Main Menu");

            string patientChoice = Console.ReadLine();

            switch (patientChoice)
            {
                case "1":
                    patientsOperations.AddPatient();
                    break;

                case "2":
                    patientsOperations.ViewPatients();
                    break;

                case "3":
                    patientsOperations.UpdatePatient();
                    break;

                case "4":
                    patientsOperations.DeletePatient();
                    break;

                case "5":
                    isPatientMenuRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }
    }

    static void AppointmentMenu(AppointmentOperations appointmentOperations)
    {
        bool isAppointmentMenuRunning = true;

        while (isAppointmentMenuRunning)
        {
            Console.WriteLine("\nAppointment Operations:");
            Console.WriteLine("1. Make Appointment");
            Console.WriteLine("2. View Appointments");
            Console.WriteLine("3. Update Appointment");
            Console.WriteLine("4. Delete Appointment");
            Console.WriteLine("5. Back to Main Menu");

            string appointmentChoice = Console.ReadLine();

            switch (appointmentChoice)
            {
                case "1":
                    appointmentOperations.MakeAppointment();
                    break;

                case "2":
                    appointmentOperations.ViewAppointments();
                    break;

                case "3":
                    appointmentOperations.UpdateAppointment();
                    break;

                case "4":
                    appointmentOperations.DeleteAppointment();
                    break;

                case "5":
                    isAppointmentMenuRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }
    }
}



/*using HospitalManagementSystem.CRUD;

Console.WriteLine("Hello, World!");
DoctorOperations doctorOperations = new DoctorOperations();
//doctorOperations.AddDoctor();
//doctorOperations.ViewDoctors();
//doctorOperations.UpdateDoctor();
//doctorOperations.DeleteDoctor();


RoomOperations roomOperations = new RoomOperations();
//roomOperations.AddRoom();
//roomOperations.ViewRooms();
//roomOperations.UpdateRoom();
//roomOperations.DeleteRoom();




PatientsOperations patientsOperations = new PatientsOperations();
patientsOperations.AddPatient();
patientsOperations.ViewPatients();
patientsOperations.UpdatePatient();
patientsOperations.DeletePatient();



AppointmentOperations appointmentOperations = new AppointmentOperations();
//appointmentOperations.MakeAppointment();
//appointmentOperations.ViewAppointments();
//appointmentOperations.UpdateAppointment();
//appointmentOperations.DeleteAppointment();

*/