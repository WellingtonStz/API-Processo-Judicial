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

        public Users CreateUsers(string Name, string CPF, bool IsAdvogado, string Password, string Oab)
        {
            try
            {

                var createUsers = new Users()
                {
                    CPF = CPF,
                    Password = Password,
                    Name = Name,
                    IsAdvogado = IsAdvogado,
                    Oab = Oab
                };

                _context.Add(createUsers);

                // Salva as alterações no banco de dados.
                _context.SaveChanges();

                return createUsers;

            }
            catch
            {
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

        public List<Users> GetAdvogados()
        {
            var Getadvogados = _context.users.Where(a => a.IsAdvogado == true).ToList();
            return Getadvogados;
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

        public List<Users> GetUsers()
        {
            var Getusers = _context.users.Where(a => a.IsAdvogado == false).ToList();
            return Getusers;
        }

        public SucessDTO Login(string CPF, string Password)
        {
            var Autentication = _context.users.FirstOrDefault(a => a.CPF == CPF && a.Password == Password);
            if (Autentication is null)
            {
                throw new Exception("CPF ou Senha inválidos!");
            }
            SucessDTO Sucess = new SucessDTO()
            {
                IdUsers = Autentication.IdUsers,
                IsAdvogado = Autentication.IsAdvogado,
                Name = Autentication.Name,
            };
            return Sucess;
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
                    GetUsers.Oab = user.Oab;

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
