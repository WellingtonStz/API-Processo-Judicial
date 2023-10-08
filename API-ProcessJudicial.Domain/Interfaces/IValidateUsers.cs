using API_ProcessJudicial.Domain.DTO;
using API_ProcessJudicial.Domain.Entities;

namespace API_ProcessJudicial.Domain.Interfaces
{
    public interface IValidateUsers
    {
        public JudicialProcess CreateProcessJudicial(string ProcessNumber, long Part, long Responsible, string Documents, string Theme, double ValueCause);
        public JudicialProcess GetProcessId(long IdUser);
        public Users ValidadeUsers(string Name, string CPF, bool IsAdvogado, string Password, string Oab);
        public Users GetUserId(long IdUsers);
        public Users UpdateUsers(UpdateUserDTO Update);
        public SucessDTO Login(LoginDTO login);
        public bool DeleteUsers(long IdUsers);
        public List<Users> GetUsers();
        public List<Users> GetAdvogados();


    }
}
