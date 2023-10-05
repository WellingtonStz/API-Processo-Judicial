using API_ProcessJudicial.Domain.DTO;
using API_ProcessJudicial.Domain.Entities;

namespace API_ProcessJudicial.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Users CreateUsers(string Name, string CPF, bool IsAdvogado, string Password);
        public Users GetUsers(long IdUser);
        public bool UpdateUsers(UsersDTO user, long IdUser);
        public bool DeleteUsers(long IdUser);

    }
}
