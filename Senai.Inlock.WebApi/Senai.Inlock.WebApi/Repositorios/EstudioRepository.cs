using Senai.Inlock.WebApi.Contexts;
using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Repositorios
{
    public class EstudioRepository : IEstudioRepository
    {
        public InLockContext _context { get; set; }
        public EstudioRepository()
        {

        }

        public EstudioRepository(InLockContext context)
        {
            _context = context;
        }

        public Estudio GetById(int id)
        {
            return _context.Estudios.FirstOrDefault(x => x.Id == id);
        }
        public List<Estudio> GetAll()
        {
            return _context.Estudios.ToList();
            
        }
    }
}
