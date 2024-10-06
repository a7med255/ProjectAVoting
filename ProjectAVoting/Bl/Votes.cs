using ProjectAVoting.Models;

namespace ProjectAVoting.Bl
{
    public class Votes
    {
        public List<VoteOption> GetAll()
        {
            try
            {
                VoteContext context = new VoteContext();
                var vote = context.VoteOptions.ToList();
                return vote;
            }
            catch {

                return new List<VoteOption>();
            }
        }

        public VoteOption GetById(int id)
        {
            try
            {
                VoteContext context = new VoteContext();
                var vote = context.VoteOptions.FirstOrDefault(a => a.Id == id);
                return vote;
            }
            catch
            {   
                return new VoteOption();
                
            }

        }

        public bool Save(VoteOption vote) {
            try
            {
                VoteContext context = new VoteContext();
                if (vote.Id == 0)
                {
                    context.VoteOptions.Add(vote);
                }
                else
                {
                    context.Entry(vote).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                
                context.SaveChanges();
                return true;
            }
            catch {
                return false; 
            }
        }

        public bool Delete(int id)
        {
            try
            {
                VoteContext context = new VoteContext();
                var vote = GetById(id);
                context.Remove(vote);
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
