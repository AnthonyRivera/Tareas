using Books.Application.Interfaces;
using Books.Domain.Models;
using Books.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }
        public async Task AddPaciente(Paciente p)
        {
            await _pacienteRepository.Add(p);
        }

        public async Task DeletePaciente(int id)
        {
            await _pacienteRepository.Delete(id);
        }

        public async Task<List<Paciente>> GetAllPacientes()
        {
            return await _pacienteRepository.GetAll();
        }

        public async Task<Paciente> GetPacienteById(int id)
        {
            return await _pacienteRepository.GetById(id);
        }

        public async Task UpdatePaciente(Paciente p)
        {
            await _pacienteRepository.Update(p);
        }
    }
}
