using API_ProcessJudicial.Domain.DTO;
using API_ProcessJudicial.Domain.Entities;
using API_ProcessJudicial.Domain.Interfaces;
using API_ProcessJudicial.Infra.CrossCutting;
using System.Text.RegularExpressions;

namespace API_ProcessJudicial.Service.Validators
{
    public class ValidateUsers : IValidateUsers
    {
        private readonly IUserRepository _userRepository;
        public ValidateUsers(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        
        }

        public Users GetUserId(long Id)
        {
            try
            {
                // Busca o usuário correspondente pelo seu "id" no contexto "_context" usando "_context.usuarios.Find(id)".
                var GetUserFromId = _userRepository.GetUsers(Id);

                // Se o usuário for encontrado, retorna o objeto "Usuarios" com as informações do usuário.
                if (GetUserFromId == null) throw new Exception("Não foi possível encontrar usuário");

                return GetUserFromId;
                // Caso o usuário não seja encontrado, lança uma exceção com a mensagem "Não foi possível encontrar usuário".
            }
            catch
            {
                // Em caso de exceção durante o processamento, retorna um novo objeto "Usuarios" vazio.
                throw;
            }
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
