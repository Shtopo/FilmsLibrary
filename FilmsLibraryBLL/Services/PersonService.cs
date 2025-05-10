using FilmsLibraryBLL.Abstractions.Services;
using FilmsLibraryData.DBContext;
using FilmsLibraryData.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmsLibraryBLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly FilmsContext _context;
        public PersonService(FilmsContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePersonAsync(string personName)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(p => p.Name == personName);

            if (person == null)
            {
                person = new Person() { Name = personName };
                _context.Persons.Add(person);
                await _context.SaveChangesAsync();
            }
            return person.Id;
        }
        public async Task<Person> ReadPersonAsync(int personID)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(c => c.Id == personID);
            if (person == null)
            {
                throw new Exception("Person not found");
            }

            return person;
        }
        public async Task<Person> RenamePersonAsync(int personID, string personName)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(c => c.Id == personID);
            if (person == null)
            {
                throw new Exception("Person is not found!");
            }

            person.Name = personName;
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<Person> DeletePersonAsync(int personId)
        {

            var person = await _context.Persons.FirstOrDefaultAsync(c => c.Id == personId);
            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }
            return person;
        }
    }
}
