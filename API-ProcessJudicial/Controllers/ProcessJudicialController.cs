using API_ProcessJudicial.Domain.DTO;
using API_ProcessJudicial.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_ProcessJudicial.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProcessJudicialController : ControllerBase
    {
        private readonly IValidateUsers _validate;
        public ProcessJudicialController(IValidateUsers validate)
        {
            _validate = validate;
        }

        // Este método GET retorna detalhes de um processo judicial com base no ID do usuário, ou uma resposta BadRequest em caso de erro.
        [HttpGet("{IdUser}")]
        public IActionResult GetProcessId(long IdUser)
        {
            try
            {
                var getProcess = _validate.GetProcessId(IdUser);

                return Ok(getProcess);
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

        // Este método POST cria um novo processo judicial com base nos dados fornecidos, ou retorna uma resposta de erro interno do servidor em caso de exceção.
        [HttpPost]
        public IActionResult CreateProcessJudicial(ProcessJudicialDTO ProcessJudicial)
        {

            try
            {
                var validateUser = _validate.CreateProcessJudicial(ProcessJudicial.ProcessNumber, ProcessJudicial.Part, ProcessJudicial.Responsible, ProcessJudicial.Documents, ProcessJudicial.Theme, ProcessJudicial.ValueCause);
                return Ok(validateUser);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErroDTO()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    MsgError = $"Ocorreu erro ao salvar Processo Judicial, Tente Novamente! {ex.Message}"
                });
            }
        }
    }
}
