
using Sample.BlazorServerAPP.DTO;

namespace Sample.BlazorServerAPP.Service
{
    public interface IOpenAIHelperService
    {
        Task<string> GetResponse(string message);
        Task<CompletionResponseDto> GetHttpResponseAsync(string prompt);
    }
}
