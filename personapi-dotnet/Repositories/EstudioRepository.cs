// EstudioRepository.cs
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace personapi_dotnet.Repositories
{
    public class EstudioRepository
    {
        private readonly PersonaDbContext _context;

        public EstudioRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Estudio> GetAll()
        {
            return _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .ToList();
        }

        public Estudio GetById(int idProf, long ccPer)
        {
            return _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefault(e => e.IdProf == idProf && e.CcPer == ccPer);
        }

        public bool Exists(int idProf, long ccPer)
        {
            return _context.Estudios.Any(e => e.IdProf == idProf && e.CcPer == ccPer);
        }

        public void Insert(Estudio estudio)
        {
            _context.Estudios.Add(estudio);
        }

        public void Update(Estudio estudio)
        {
            _context.Entry(estudio).State = EntityState.Modified;
        }

        public void Delete(Estudio estudio)
        {
            _context.Estudios.Remove(estudio);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}