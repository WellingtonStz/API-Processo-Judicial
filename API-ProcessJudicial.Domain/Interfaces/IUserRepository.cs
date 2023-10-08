using API_ProcessJudicial.Domain.DTO;
using API_ProcessJudicial.Domain.Entities;

namespace API_ProcessJudicial.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Users CreateUsers(string Name, string CPF, bool IsAdvogado, string Password, string Oab);
        public Users GetUsers(long IdUser);
        public Users UpdateUsers(UpdateUserDTO user);
        public SucessDTO Login(string CPF, string Password);
        public bool DeleteUsers(long IdUser);
        public List<Users> GetUsers();
        public List<Users> GetAdvogados();


    }
}
