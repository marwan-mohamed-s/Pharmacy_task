namespace ECommerce_task.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorImg { get; set; }

        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
