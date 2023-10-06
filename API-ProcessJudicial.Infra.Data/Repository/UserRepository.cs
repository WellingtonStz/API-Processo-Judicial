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

                _context.Add(createUsers);

                // Salva as alterações no banco de dados.
                _context.SaveChanges();

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
            try
            {
                var getUsers = _context.users.Find(IdUser);

                if (getUsers != null)

                {
                    _context.Remove(getUsers);

                    _context.SaveChanges();

                    return true;
                }

                return false;
            }
            catch
            {
                throw;
            }
        }

        public Users GetUsers(long IdUser)
        {
            try
            {
                var GetUserFromId = _context.users.Find(IdUser);

                if (GetUserFromId == null) throw new Exception("Não foi possível encontrar usuário");

                return GetUserFromId;

            }
            catch
            {
                throw;
            }
        }

        public Users UpdateUsers(UpdateUserDTO user)
        {
            try
            {
                var GetUsers = _context.users.Find(user.IdUsers);

                if (GetUsers != null)
                {
                    GetUsers.Name = user.Name;
                    GetUsers.CPF = user.CPF;
                    GetUsers.Password = user.Password;
                    GetUsers.IsAdvogado = user.IsAdvogado;

                    _context.SaveChanges();

                }

                return GetUsers;
            }

            catch
            {
                throw;
            }
        }
    }
}
