namespace ECommerce_task.Models
{
    public class Specialization
    {
        public int Id { get; set; }

        public string SpecializationName { get; set; }

       
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
