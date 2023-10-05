using API_ProcessJudicial.Domain.DTO;
using API_ProcessJudicial.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace API_ProcessJudicial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IValidateUsers _validate;
            public UsersController(IValidateUsers validate)
        {
            _validate = validate;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                var getUsers = _validate.GetUserId(id);

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

        // Implementação do método de ação para obter todas as informações de usuários via HTTP GET.

        [HttpGet]

        public IActionResult GetAllUser()
        {
            try
            {
                // Tenta recuperar todos os usuários usando o repositório "_usuariosRepository.GetallUsers()"
              //  var GetAllUser = _usuariosRepository.GetallUsers();

                // Se a operação for bem-sucedida, retorna uma resposta Ok contendo a lista de todos os usuários.
                return Ok();

            }
            catch (Exception ex)
            {
                // Em caso de exceção durante o processamento, retorna uma resposta BadRequest com um objeto ResponseErroDTO contendo a mensagem de erro.
                return BadRequest(new ResponseErroDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    MsgError = ex.Message
                });
            }
        }

        // Implementação do método de ação para criar um novo usuário via HTTP POST.

        [HttpPost]
        public IActionResult CreateUsers(UsersDTO users)
        {

            try
            {
                var validateUser = _validate.ValidadeUsers(users.Name, users.CPF, users.IsAdvogado, users.Password);
                return Ok(validateUser);

            }
            catch (Exception ex)
            {
                // Em caso de exceção não tratada, retorna uma resposta de erro interno com uma mensagem descritiva.
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErroDTO()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    MsgError = $"Ocorreu erro ao salvar usuário, Tente Novamente! {ex.Message}"
                });
            }
        }

        // Implementação do método de ação para atualizar informações de um usuário via HTTP PUT.

        [HttpPut("{IdUser}")]
        public IActionResult Put(UsersDTO users, long IdUser)
        {

            try
            {
                var erros = new List<string>();

                //// Validação do nome do usuário
                //if (string.IsNullOrEmpty(users.Nome) || string.IsNullOrWhiteSpace(users.Nome) || users.Nome.Length <= 2)
                //{
                //    erros.Add("Nome Inválido");
                //}

                //// Validação do formato do e-mail usando uma expressão regular
                //Regex regex = new Regex(@"^([\w\.\-\+\d]+)@([\w\-]+)((\.(\w){2,3})+)$");
                //if (string.IsNullOrEmpty(users.Email) || string.IsNullOrWhiteSpace(users.Email) || !regex.Match(users.Email).Success)
                //{
                //    erros.Add("Email Inválido");
                //}

                //// Se houver erros de validação, retorna uma resposta BadRequest com a lista de erros.
                //if (erros.Count > 0)
                //{
                //    return BadRequest(new ResponseErroDTO()
                //    {
                //        Status = StatusCodes.Status400BadRequest,
                //        Error = erros
                //    });
                //}

                //// Tenta atualizar os dados do usuário usando o repositório "_usuariosRepository.Update(users)".
                //var update = _usuariosRepository.Update(users);

                //// Se a atualização for bem-sucedida, retorna uma resposta Ok com uma mensagem indicando a conclusão.
                //if (update == true)
                //{
                //    return Ok("Usuário editado!");
                //}

                // Se o usuário não for encontrado ou ocorrer um problema durante a atualização, retorna uma resposta BadRequest com um objeto ResponseErroDTO vazio.
                return BadRequest(new ResponseErroDTO() { Status = StatusCodes.Status400BadRequest, });
            }
            catch (Exception ex)
            {
                // Em caso de exceção durante o processamento, retorna uma resposta de erro interno com uma mensagem descritiva.
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErroDTO()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    MsgError = $"Ocorreu erro ao editar usuário, Tente Novamente! {ex.Message}"
                });
            }

        }

        // Implementação do método de ação para deletar um usuário via HTTP DELETE, com base no parâmetro "id".

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Tenta deletar o usuário usando o repositório "_usuariosRepository.Delete(id)".
                //if (_usuariosRepository.Delete(id))
                    return Ok("Usuário Deletado!");

                // Se o usuário não for encontrado para deleção, retorna uma resposta BadRequest com um objeto ResponseErroDTO vazio.
               // return BadRequest(new ResponseErroDTO() { Status = StatusCodes.Status400BadRequest, });

            }
            catch (Exception ex)
            {
                // Em caso de exceção durante o processamento, retorna uma resposta BadRequest com um objeto ResponseErroDTO contendo a mensagem de erro.
                return BadRequest(new ResponseErroDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    MsgError = ex.Message
                });
            }


        }
    }
}
