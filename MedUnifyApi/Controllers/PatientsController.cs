using MedUnifyApi.Data;
using MedUnifyApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MedUnifyApi.Controllers
{
    // Controllers/PatientController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly MedUnifyContext _context;

        public PatientController(MedUnifyContext context)
        {
            _context = context;
        }

        // GET: api/Patient
        [HttpGet]
        public IActionResult GetPatients()
        {

            var patients = _context.Patients.ToList();
            return Ok(patients);
        }

        // GET: api/Patient/5
        [HttpGet("{id}")]
        public IActionResult GetPatient(int id)
        {
            var patient = _context.Patients.Find(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        // POST: api/Patient
        [HttpPost]
        public IActionResult CreatePatient([FromBody] Patient patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }

            _context.Patients.Add(patient);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPatient), new { id = patient.PatientId }, patient);
        }

        // PUT: api/Patient/5
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] Patient updatedPatient)
        {
            var patient = _context.Patients.Find(id);

            if (patient == null)
            {
                return NotFound();
            }

            patient.FirstName = updatedPatient.FirstName;
            patient.LastName = updatedPatient.LastName;
            patient.Address = updatedPatient.Address;
            patient.State = updatedPatient.State;
            patient.City = updatedPatient.City;
            patient.OrganizationId = updatedPatient.OrganizationId;
            patient.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Patient/5
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = _context.Patients.Find(id);

            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            _context.SaveChanges();

            return NoContent();
        }
    }

}
