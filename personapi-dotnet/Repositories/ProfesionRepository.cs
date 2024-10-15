using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models;
using System.Collections.Generic;
using System.Linq;

namespace personapi_dotnet.Repositories
{
    public class ProfesionRepository
    {
        private readonly PersonaDbContext _context;

        public ProfesionRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Profesion> GetAll()
        {
            return _context.Profesions.ToList();
        }

        public Profesion GetById(int id)
        {
            return _context.Profesions.Find(id);
        }

        public void Insert(Profesion profesion)
        {
            _context.Profesions.Add(profesion);
        }

        public void Update(Profesion profesion)
        {
            _context.Profesions.Update(profesion);
        }

        public void Delete(Profesion profesion)
        {
            _context.Profesions.Remove(profesion);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
