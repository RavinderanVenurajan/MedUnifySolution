using MedUnifyApi.Data;
using MedUnifyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MedUnifyApi.Service
{
    public class PatientsService
    {
        private readonly MedUnifyContext _context;

        public PatientsService(MedUnifyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int patientId)
        {
            return await _context.Patients.FindAsync(patientId);
        }

        public async Task<int> AddPatientAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient.PatientId;
        }

        public async Task<bool> UpdatePatientAsync(int patientId, Patient updatedPatient)
        {
            var existingPatient = await _context.Patients.FindAsync(patientId);

            if (existingPatient == null)
            {
                return false;
            }

            existingPatient.FirstName = updatedPatient.FirstName;
            existingPatient.LastName = updatedPatient.LastName;
            existingPatient.Address = updatedPatient.Address;
            existingPatient.State = updatedPatient.State;
            existingPatient.City = updatedPatient.City;
            existingPatient.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePatientAsync(int patientId)
        {
            var patient = await _context.Patients.FindAsync(patientId);

            if (patient == null)
            {
                return false;
            }

            patient.IsDeleted = true;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
