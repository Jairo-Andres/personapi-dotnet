using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace personapi_dotnet.Repositories
{
    public class TelefonoRepository
    {
        private readonly PersonaDbContext _context;

        public TelefonoRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Telefono> GetAll()
        {
            return _context.Telefonos
                .Include(t => t.DuenioNavigation)
                .ToList();
        }

        public Telefono GetById(string num)
        {
            return _context.Telefonos
                .Include(t => t.DuenioNavigation)
                .FirstOrDefault(t => t.Num == num);
        }

        public void Insert(Telefono telefono)
        {
            _context.Telefonos.Add(telefono);
        }

        public void Update(Telefono telefono)
        {
            _context.Telefonos.Update(telefono);
        }

        public void Delete(Telefono telefono)
        {
            _context.Telefonos.Remove(telefono);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
