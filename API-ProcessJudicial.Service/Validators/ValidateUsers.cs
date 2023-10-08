﻿using API_ProcessJudicial.Domain.DTO;
using API_ProcessJudicial.Domain.Entities;
using API_ProcessJudicial.Domain.Interfaces;
using API_ProcessJudicial.Infra.CrossCutting;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace API_ProcessJudicial.Service.Validators
{
    public class ValidateUsers : IValidateUsers
    {
        private readonly IUserRepository _userRepository;
        private readonly IProcessJudicialRepository _processRepository;
        public ValidateUsers(IUserRepository userRepository, IProcessJudicialRepository processRepository)
        {
            _userRepository = userRepository;
            _processRepository = processRepository;
        }

        public JudicialProcess CreateProcessJudicial(string ProcessNumber, long Part, long Responsible, string Documents, string Theme, double ValueCause)
        {
            if (string.IsNullOrEmpty(ProcessNumber) || string.IsNullOrWhiteSpace(ProcessNumber) || ProcessNumber.Length < 20 && ProcessNumber.Length > 20)
            {
                throw new ArgumentException("Número do processo inválido!");
            }

            if (string.IsNullOrEmpty(Documents) || string.IsNullOrWhiteSpace(Documents))
            {
                throw new ArgumentException("Documento inválido!");
            }


            if (string.IsNullOrEmpty(Theme) || string.IsNullOrWhiteSpace(Theme))
            {
                throw new ArgumentException("Tema inválida!");
            }

            var Createprocess = _processRepository.CreateProcessJudicial(ProcessNumber, Part, Responsible, Documents, Theme, ValueCause);
            return Createprocess;
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

        public List<Users> GetAdvogados()
        {
            var list = _userRepository.GetAdvogados();
            return list;
        }

        public JudicialProcess GetProcessId(long IdUser)
        {
            try
            {
                var GetProcessId = _processRepository.GetProcessId(IdUser);

                if (GetProcessId == null) throw new Exception("Não foi possível encontrar usuário");

                return GetProcessId;
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

        public List<Users> GetUsers()
        {
            var list = _userRepository.GetUsers();
            return list;
        }

        public SucessDTO Login(LoginDTO login)
        {
            try
            {
                if (string.IsNullOrEmpty(login.CPF) || string.IsNullOrWhiteSpace(login.CPF))
                {
                    throw new ArgumentException("CPF inválido!");
                }

                if (string.IsNullOrEmpty(login.Password) || string.IsNullOrWhiteSpace(login.Password) || login.Password.Length <= 6)
                {
                    throw new ArgumentException("Senha inválida!");
                }

                string Password = CreateHash.CreateHashMd5(login.Password);

                var Autentication = _userRepository.Login(login.CPF, Password);

                return Autentication;
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

            if (string.IsNullOrEmpty(Update.CPF) || string.IsNullOrWhiteSpace(Update.CPF) || Update.CPF.Length < 11 && Update.CPF.Length > 15)
            {
                throw new ArgumentException("CPF inválido!");
            }


            if (string.IsNullOrEmpty(Update.Password) || string.IsNullOrWhiteSpace(Update.Password) || Update.Password.Length <= 6)
            {
                throw new ArgumentException("Senha inválida!");
            }

            if (string.IsNullOrEmpty(Update.Oab) || string.IsNullOrWhiteSpace(Update.Oab) || Update.Oab.Length < 8 && Update.Oab.Length > 8)
            {
                throw new ArgumentException("Número da Oab inválida!");
            }

            Update.Password = CreateHash.CreateHashMd5(Update.Password);
            var UpdateUser = _userRepository.UpdateUsers(Update);
            return UpdateUser;
        }

        public Users ValidadeUsers(string Name, string CPF, bool IsAdvogado, string Password, string Oab)
        {
            try
            {
               
                // Validação do nome do usuário.
                if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name) || Name.Length <= 2)
                {
                    throw new ArgumentException("Nome inválido!");
                }



                // Validação do formato do CPF usando uma expressão regular.
                if (string.IsNullOrEmpty(CPF) || string.IsNullOrWhiteSpace(CPF) || CPF.Length < 11 && CPF.Length > 15)
                {
                    throw new ArgumentException("CPF inválido!");
                }

                // 

                if (string.IsNullOrEmpty(Password) || string.IsNullOrWhiteSpace(Password) || Password.Length <= 6)
                {
                    throw new ArgumentException("Senha inválida!");
                }

                if (Oab != null)
                {
                    if (string.IsNullOrEmpty(Oab) || string.IsNullOrWhiteSpace(Oab) || Oab.Length < 8 && Oab.Length > 8)
                    {
                        throw new ArgumentException("Número da Oab inválida!");
                    }

                }

                // Criar hash da senha 
                var password = CreateHash.CreateHashMd5(Password);

                var createUser = _userRepository.CreateUsers(Name, CPF, IsAdvogado, password, Oab);

                return(createUser);

            }
            catch 
            {
                throw;
            
            }
        }
    }
}
