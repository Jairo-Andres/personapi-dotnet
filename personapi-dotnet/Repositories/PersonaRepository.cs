using personapi_dotnet.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace personapi_dotnet.Repositories
{
    public class PersonaRepository
    {
        private readonly PersonaDbContext _context;

        public PersonaRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Persona> GetAll()
        {
            return _context.Personas.ToList();
        }

        public Persona GetById(long id)  // Cambia el tipo de int a long
        {
            return _context.Personas.Find(id) ?? new Persona();
        }



        public void Insert(Persona persona)
        {
            _context.Personas.Add(persona);
        }

        public void Update(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
        }

        public void Delete(Persona persona)
        {
            _context.Personas.Remove(persona);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
