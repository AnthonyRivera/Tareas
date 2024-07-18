using Books.Application.Interfaces;
using Books.Domain.Models;
using Books.Persistence.Context;
using Books.Web.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infraestructure.Repositories
{
    public class PacienteEfRepository : Repository<Paciente>, IPacienteRepository
    {
        private readonly ApplicationContext _context;
        public PacienteEfRepository(ApplicationContext context) :base(context)
        {
            _context = context;
        }

    }
}
