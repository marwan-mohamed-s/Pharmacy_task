using ECommerce_task.Models;
using Ecommerce1.DataAccess;
using Ecommerce1.viewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_task.Controllers
{
    public class DoctorsController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IActionResult BookAppointment(filterVM filter, int page = 1)
        {
            var Doctors = _context.Doctors.Include(d => d.Specialization).AsQueryable();
            if (filter.Name is not null)
            {
                Doctors = Doctors.Where(p => p.DoctorName.Contains(filter.Name));
                ViewBag.Name = filter.Name;
            }
            if (filter.SpecializationId is not null)
            {
                Doctors = Doctors.Where(p => p.SpecializationId == filter.SpecializationId);
                ViewBag.SpecializationId = filter.SpecializationId;
            }

            // Pagination
            ViewBag.TotalPages = Math.Ceiling(Doctors.Count() / 3.0);
            ViewBag.curuntpage = page;

            ViewBag.Specializations = _context.Specializations.ToList();

            var PageDoctors = Doctors.Skip((page - 1) * 3).Take(3).ToList();

            return View(PageDoctors);
        }

        public IActionResult CreateAppointment(int doctorId)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == doctorId);
            if (doctor == null) return NotFound();

            ViewBag.DoctorName = doctor.DoctorName;
            ViewBag.DoctorId = doctor.Id;

            ViewBag.Doctor = doctor;
            return View();
        }

        [HttpPost]
        public IActionResult CreateAppointment(int doctorId, string patientName, DateTime appointmentDate, string appointmentTime)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == doctorId);
            if (doctor == null) return NotFound();

            // تحويل الوقت من string لـ TimeSpan مباشرة (لأن input type="time" بيرجع HH:mm)
            TimeSpan parsedTime;
            if (!TimeSpan.TryParse(appointmentTime, out parsedTime))
            {
                ViewBag.Alert = "error";
                ViewBag.AlertTitle = "Oops...";
                ViewBag.AlertText = "Invalid time format. Please pick a valid time.";
                ViewBag.DoctorName = doctor.DoctorName;
                ViewBag.DoctorId = doctor.Id;
                return View();
            }

            // الشرط: من 8 صباحًا لـ 5 مساءً
            if (parsedTime < new TimeSpan(8, 0, 0) || parsedTime >= new TimeSpan(17, 0, 0))
            {
                ViewBag.Alert = "error";
                ViewBag.AlertTitle = "Oops...";
                ViewBag.AlertText = "Appointments are only available from 08:00 AM to 05:00 PM.";
                ViewBag.DoctorName = doctor.DoctorName;
                ViewBag.DoctorId = doctor.Id;
                return View();
            }

            // لو كل حاجة تمام
            var appointment = new Appointment
            {
                DoctorId = doctorId,
                PatientName = patientName,
                AppointmentDate = appointmentDate,
                AppointmentTime = TimeOnly.FromTimeSpan(parsedTime)
            };

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            ViewBag.Alert = "success";
            ViewBag.AlertTitle = "Success!";
            ViewBag.AlertText = "Your appointment has been booked successfully!";
            ViewBag.DoctorName = doctor.DoctorName;
            ViewBag.DoctorId = doctor.Id;

            return View();
        }


    }
}
