namespace ECommerce_task.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }

        // Foreign Key to Doctor
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}