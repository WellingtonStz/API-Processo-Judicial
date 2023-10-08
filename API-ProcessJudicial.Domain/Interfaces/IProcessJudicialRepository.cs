using API_ProcessJudicial.Domain.DTO;
using API_ProcessJudicial.Domain.Entities;

namespace API_ProcessJudicial.Domain.Interfaces
{
    public interface IProcessJudicialRepository
    {
        public JudicialProcess CreateProcessJudicial(string ProcessNumber, long Part, long Responsible, string Documents, string Theme, double ValueCause);
        public JudicialProcess GetProcessId(long IdUser);

    }
}
