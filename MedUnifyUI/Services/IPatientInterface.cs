﻿using DataModel.Models;
using DataModel.Models;

namespace MedUnifyUI.Services
{
    public interface IPatientInterface
    {
        public Task<List<Patient>> getPatient();
        public  Task<Patient> AddPatient(Patient newPatient);
        public Task DeletePatient(int patientId);
        public Task UpdatePatient(int patientId, Patient updatedPatient);
        public Task<Patient> GetPatientById(int patientId);
    }
}
