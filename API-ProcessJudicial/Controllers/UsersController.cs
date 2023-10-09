using API_ProcessJudicial.Domain.DTO;
using API_ProcessJudicial.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace API_ProcessJudicial.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IValidateUsers _validate;
            public UsersController(IValidateUsers validate)
        {
            _validate = validate;
        }

        // Este método GET retorna os detalhes de um usuário com base no ID fornecido, ou uma resposta BadRequest em caso de erro.
        [HttpGet("{IdUser}")]
        public IActionResult GetuserId(long IdUser)
        {
            try
            {
                var getUsers = _validate.GetUserId(IdUser);

                return Ok(getUsers);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseErroDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    MsgError = ex.Message
                });
            }

        }

        // Este método GET retorna a lista de usuários se bem-sucedido, ou uma resposta de erro interno do servidor em caso de exceção.
        [HttpGet]
        public IActionResult Getuser()
        {
            try
            {
                var GetUser = _validate.GetUsers();
                return Ok(GetUser);
            }
            catch (Exception ex) {

                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErroDTO()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    MsgError = $"Ocorreu erro ao salvar usuário, Tente Novamente! {ex.Message}"
                });
            }
        }

        // Este método GET obtém a lista de advogados, ou retorna uma resposta de erro interno do servidor em caso de exceção.
        [HttpGet]
        public IActionResult GetAdvogados()
        {
            try
            {
                var GetAdvogado = _validate.GetAdvogados();
                return Ok(GetAdvogado);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErroDTO()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    MsgError = $"Ocorreu erro ao salvar usuário, Tente Novamente! {ex.Message}"
                });
            }
        }

        // Este método POST cria um novo usuário com base nos dados fornecidos, ou retorna uma resposta de erro interno do servidor em caso de exceção.
        [HttpPost]
        public IActionResult CreateUsers(UsersDTO users)
        {

            try
            {
                var validateUser = _validate.ValidadeUsers(users.Name, users.CPF, users.IsAdvogado, users.Password, users.Oab);
                return Ok(validateUser);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErroDTO()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    MsgError = $"Ocorreu erro ao salvar usuário, Tente Novamente! {ex.Message}"
                });
            }
        }

        // Este método PUT atualiza os detalhes de um usuário com base nos dados fornecidos, ou retorna uma resposta de erro interno do servidor em caso de exceção.
        [HttpPut]
        public IActionResult Update(UpdateUserDTO users)
        {
            try
            {
                var validateUser = _validate.UpdateUsers(users);
                return Ok(validateUser);

            }
            catch (Exception ex)
            {
  
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErroDTO()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    MsgError = $"Ocorreu erro ao editar usuário, Tente Novamente! {ex.Message}"
                });
            }

        }

        // Este método DELETE exclui um usuário com base no ID fornecido, ou retorna uma resposta de erro interno do servidor em caso de exceção.
        [HttpDelete("{IdUser}")]
        public IActionResult Delete(long IdUser)
        {
            try
            {
                var DeleteUsers = _validate.DeleteUsers(IdUser);
                if(DeleteUsers)
                {
                    return Ok("Usuário Deletado!");
                }
               
                 return BadRequest(new ResponseErroDTO() { Status = StatusCodes.Status400BadRequest, });

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseErroDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    MsgError = ex.Message
                });
            }


        }

        // Este método POST é usado para autenticar um usuário com base nas informações de login fornecidas.
        [HttpPost] 
        public IActionResult Login(LoginDTO login)
        {   
            try
            {
                var LoginUsers = _validate.Login(login);
                return Ok(LoginUsers);

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseErroDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    MsgError = ex.Message
                });
            }
        }

    }
}
