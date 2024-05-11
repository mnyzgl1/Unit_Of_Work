using Unit_Of_Work.DMO;

namespace Unit_Of_Work.Repository
{
    public class AutorizationRepository : IRepository<Autorization>
    {
        public AuthContext _context;

        public AutorizationRepository(AuthContext context)
        {
            _context = context;
        }
        public bool Add(Autorization model)
        {
           _context.Add(model);
            return true;
        }

        void IRepository<Autorization>.Add(Autorization autorization)
        {
            throw new NotImplementedException();
        }
    }
}
