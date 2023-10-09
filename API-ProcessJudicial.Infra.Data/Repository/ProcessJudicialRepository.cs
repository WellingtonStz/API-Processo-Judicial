using API_ProcessJudicial.Domain.Entities;
using API_ProcessJudicial.Domain.Interfaces;
using Crud_API.Models;

namespace API_ProcessJudicial.Infra.Data.Repository
{
    public class ProcessJudicialRepository : IProcessJudicialRepository
    {
        private readonly _DbContext _context;

        public ProcessJudicialRepository(_DbContext context)
        {
            _context = context;
        }

        public JudicialProcess CreateProcessJudicial(string ProcessNumber, long Part, long Responsible, string Documents, string Theme, double ValueCause)
        {
            try
            {

                var CreateProcess = new JudicialProcess()
                {
                    Documents = Documents,
                    Theme = Theme,
                    ValueCause = ValueCause,
                    Part = Part,
                    Responsible = Responsible,
                    ProcessNumber = ProcessNumber,

                };

                _context.Add(CreateProcess);

                // Salva as alterações no banco de dados.
                _context.SaveChanges();

                return CreateProcess;

            }
            catch
            {
                throw;
            }
        }

        public JudicialProcess GetProcessId(long IdUser)
        {

            try
            {
                var GetProcessId = _context.judicialprocesses.FirstOrDefault(a => a.IdJudicialProcess == IdUser || a.Responsible == IdUser || a.Part == IdUser);

                if (GetProcessId == null) throw new Exception("Não foi possível encontrar o processo judicial");

                return GetProcessId;

            }
            catch
            {
                throw;
            }
        }
    }
}
