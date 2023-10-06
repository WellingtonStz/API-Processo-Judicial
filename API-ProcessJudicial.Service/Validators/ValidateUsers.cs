using API_ProcessJudicial.Domain.DTO;
using API_ProcessJudicial.Domain.Entities;
using API_ProcessJudicial.Domain.Interfaces;
using API_ProcessJudicial.Infra.CrossCutting;

namespace API_ProcessJudicial.Service.Validators
{
    public class ValidateUsers : IValidateUsers
    {
        private readonly IUserRepository _userRepository;
        public ValidateUsers(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        
        }

        public bool DeleteUsers(long IdUsers)
        {
            try
            {
                var DeleteUsers = _userRepository.DeleteUsers(IdUsers);
                if (DeleteUsers)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public Users GetUserId(long IdUsers)
        {
            try
            {               
                var GetUserFromId = _userRepository.GetUsers(IdUsers);

                if (GetUserFromId == null) throw new Exception("Não foi possível encontrar usuário");

                return GetUserFromId;             
            }
            catch
            {
                throw;
            }
        }

        public Users UpdateUsers(UpdateUserDTO Update)
        {
            if (string.IsNullOrEmpty(Update.Name) || string.IsNullOrWhiteSpace(Update.Name) || Update.Name.Length <= 2)
            {
                throw new ArgumentException("Nome inválido!");
            }

            if (string.IsNullOrEmpty(Update.CPF) || string.IsNullOrWhiteSpace(Update.CPF))
            {
                throw new ArgumentException("CPF inválido!");
            }


            if (string.IsNullOrEmpty(Update.Password) || string.IsNullOrWhiteSpace(Update.Password) || Update.Password.Length <= 6)
            {
                throw new ArgumentException("Senha inválida!");
            }

            Update.Password = CreateHash.CreateHashMd5(Update.Password);
            var UpdateUser = _userRepository.UpdateUsers(Update);
            return UpdateUser;
        }

        public Users ValidadeUsers(string Name, string CPF, bool IsAdvogado, string Password)
        {
            try
            {
               
                // Validação do nome do usuário.
                if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name) || Name.Length <= 2)
                {
                    throw new ArgumentException("Nome inválido!");
                }



                // Validação do formato do CPF usando uma expressão regular.
                if (string.IsNullOrEmpty(CPF) || string.IsNullOrWhiteSpace(CPF))
                {
                    throw new ArgumentException("CPF inválido!");
                }

                // 

                if (string.IsNullOrEmpty(Password) || string.IsNullOrWhiteSpace(Password) || Password.Length <= 6)
                {
                    throw new ArgumentException("Senha inválida!");
                }

                // Criar hash da senha 
                var password = CreateHash.CreateHashMd5(Password);

                var createUser = _userRepository.CreateUsers(Name, CPF, IsAdvogado, password);

                return(createUser);

            }
            catch 
            {
                throw;
            
            }
        }
    }
}
