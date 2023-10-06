using API_ProcessJudicial.Domain.DTO;
using API_ProcessJudicial.Domain.Entities;

namespace API_ProcessJudicial.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Users CreateUsers(string Name, string CPF, bool IsAdvogado, string Password);
        public Users GetUsers(long IdUser);
        public Users UpdateUsers(UpdateUserDTO user);
        public bool DeleteUsers(long IdUser);

    }
}
