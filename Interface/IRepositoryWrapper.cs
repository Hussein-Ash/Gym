using EvaluationBackend.Interface;

namespace EvaluationBackend.Repository
{
    public interface IRepositoryWrapper
    {

        IUserRepository User { get; }
        ISectionRepository Section { get; }
        ISetsRepository Sets { get; }



    }
}