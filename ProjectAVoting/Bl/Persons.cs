using ProjectAVoting.Models;

namespace ProjectAVoting.Bl
{
    public class Persons
    {
        public List<Person> GetAll()
        {
            try
            {
                VoteContext context = new VoteContext();
                var person = context.persons.ToList();
                return person;
            }
            catch
            {

                return new List<Person>();
            }
        }

        public Person GetById(int id)
        {
            try
            {
                VoteContext context = new VoteContext();
                var person = context.persons.FirstOrDefault(a => a.Id == id);
                return person;
            }
            catch
            {
                return new Person();
            }
        }
        public bool Save(Person person)
        {
            try
            {
                VoteContext context = new VoteContext();
                if (person.Id == 0)
                {
                    context.persons.Add(person);
                }
                else
                {
                    context.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                VoteContext context = new VoteContext();
                var person = GetById(id);
                context.Remove(person);
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
