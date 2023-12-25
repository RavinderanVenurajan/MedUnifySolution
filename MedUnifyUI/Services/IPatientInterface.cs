using MedUnifyUI.Models;

namespace MedUnifyUI.Services
{
    public interface IPatientInterface
    {
        public Task<IEnumerable<Patient>> getPatient();
    }
}
