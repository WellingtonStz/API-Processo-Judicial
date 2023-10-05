using API_ProcessJudicial.Domain.DTO;
using API_ProcessJudicial.Domain.Entities;
using API_ProcessJudicial.Domain.Interfaces;
using Crud_API.Models;

namespace API_ProcessJudicial.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly _DbContext _context;

        public UserRepository(_DbContext context)
        {
            _context = context;
        }

        public Users CreateUsers(string Name, string CPF, bool IsAdvogado, string Password)
        {
            try
            {

                var createUsers = new Users()
                {
                    CPF = CPF,
                    Password = Password,
                    Name = Name,
                    IsAdvogado = IsAdvogado,
                };

                // Adiciona o novo objeto "Usuarios" ao contexto "_context"
                _context.Add(createUsers);

                // Salva as alterações no banco de dados.
                _context.SaveChanges();

                // Retorna o objeto "Usuarios" recém-criado após a operação de criação no banco de dados.
                return createUsers;

            }
            catch
            {
                // Em caso de exceção durante o processamento, a exceção é propagada para ser tratada em um nível superior.
                throw;
            }

        }

        public bool DeleteUsers(long IdUser)
        {
            throw new NotImplementedException();
        }

        public Users GetUsers(long IdUser)
        {
            try
            {
                // Busca o usuário correspondente pelo seu "id" no contexto "_context" usando "_context.users.Find(IdUser)".
                var GetUserFromId = _context.users.Find(IdUser);

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

        public bool UpdateUsers(UsersDTO user, long IdUser)
        {
            throw new NotImplementedException();
        }
    }
}
