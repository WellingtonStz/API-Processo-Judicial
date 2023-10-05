using API_ProcessJudicial.Domain.Entities;

namespace API_ProcessJudicial.Domain.Interfaces
{
    public interface IValidateUsers
    {


        public Users ValidadeUsers(string Name, string CPF, bool IsAdvogado, string Password);
        public Users GetUserId(long Id);



    }
}
