
using AutoMapper;
using EvaluationBackend.DATA;
using EvaluationBackend.Interface;
using EvaluationBackend.Respository;

namespace EvaluationBackend.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        private IUserRepository _user;
        private ISectionRepository _section;
        private ISetsRepository _sets;



        
        public ISectionRepository Section
        {
            get
            {
                if (_section == null)
                {
                    _section = new SectionsRepository(_context, _mapper);
                }
                return _section;
            }
        }
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context, _mapper);
                }
                return _user;
            }
        }
        public ISetsRepository Sets
        {
            get
            {
                if (_sets == null)
                {
                    _sets = new SetsRepository(_context, _mapper);
                }
                return _sets;
            }
        }


        public RepositoryWrapper(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
    }
}