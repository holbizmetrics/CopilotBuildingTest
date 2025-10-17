using VibeCoding.Core.Models;

namespace VibeCoding.Core.Services;

public interface ICodeExecutionService
{
    Task<ExecutionResult> ExecuteCodeAsync(string code);
}
