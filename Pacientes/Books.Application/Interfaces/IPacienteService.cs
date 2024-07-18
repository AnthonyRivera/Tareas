using Books.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Interfaces
{
    public interface IPacienteService
    {
        Task<List<Paciente>> GetAllPacientes();
        Task<Paciente> GetPacienteById(int id);
        Task AddPaciente(Paciente p);
        Task UpdatePaciente(Paciente p);
        Task DeletePaciente(int id);
   
    }
}
