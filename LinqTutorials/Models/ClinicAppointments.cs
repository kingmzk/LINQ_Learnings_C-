using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTutorials.Models
{
    public class ClinicAppointments
    {
        public int ClinicId { get; set; }

        public int PetId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public ClinicAppointments(int clinicId, int petId, DateTime appointmentDate)
        {
            ClinicId = clinicId;
            PetId = petId;
            AppointmentDate = appointmentDate;
        }

        public override string ToString()
        {
            return $"ClinicId: {ClinicId}, PetId: {PetId}, AppointmentDate: {AppointmentDate}";
        }
    }
}
