
//using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using Newtonsoft.Json;
////using OpenAI_API;
////using OpenAI_API.Completions;
//using Org.BouncyCastle.Asn1.Ocsp;
//using Sample.BlazorServerApp.DTO;
//using Sample.BlazorServerApp.Service;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Text.Json;
//using System.Timers;

//namespace Sample.BlazorServerApp.Implementation
//{
//    public class OpenAIHelperService : IOpenAIHelperService
//    {
//        private readonly IHttpClientFactory _httpClient;
//        private readonly ILogger<OpenAIHelperService> _logger;
//        private string _apiKey = "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";
//        private string _model = "text-davinci-003";
//        public OpenAIHelperService(IHttpClientFactory httpClient, ILogger<OpenAIHelperService> logger)
//        {
//            _logger = logger;
//            _httpClient = httpClient;
//           // _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
//        }
//        public async Task<string> GetResponse(string message)
//        {
//            try
//            {
//                OpenAIAPI api = new OpenAIAPI(new APIAuthentication(_apiKey));
//                var client = new OpenAI_API.APIAuthentication(_apiKey);
//                var result = await api.Completions.CreateCompletionAsync(
//                    new CompletionRequest(
//                        message,
//                       // model: Model.DavinciText,
//                        temperature: 0.1));
//                return result.Completions[0].Text.ToString();
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

//        public async Task<CompletionResponseDto> GetHttpResponseAsync(string prompt)
//        {
//            try
//            {
//                CompletionResponseDto completionResponse = new CompletionResponseDto();
//                CompletionRequestDto completionRequest = new CompletionRequestDto
//                {
//                    Model = _model,
//                    Prompt = prompt,
//                    MaxTokens = 120,
//                    TopP = 0.3f,
//                    FrequencyPenalty = 0.5f,
//                    PresencePenalty = 0
//                };
//                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/engines/davinci-codex/completions");
//                //request.Headers.Add("Authorization", _apiKey);
//                request.Content = new StringContent(JsonConvert.SerializeObject(completionRequest), Encoding.UTF8, "application/json");
//                var client = _httpClient.CreateClient();
//                request.Headers.Add("Authorization", "Bearer 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");
//                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",_apiKey);
//                HttpResponseMessage httpResponse = await client.SendAsync(request);
//                //var httpResponse = await _httpClient.PostAsJsonAsync("https://api.openai.com/v1/engines/davinci-codex/completions", completionRequest);

//                if (httpResponse.IsSuccessStatusCode)
//                {
//                    var content = await httpResponse.Content.ReadAsStringAsync();
//                    string responseString = await httpResponse.Content.ReadAsStringAsync();
//                    {
//                        if (!string.IsNullOrWhiteSpace(responseString))
//                        {
//                            completionResponse = System.Text.Json.JsonSerializer.Deserialize<CompletionResponseDto>(responseString);
//                        }
//                    }
//                    return completionResponse;
//                }
//                else
//                {
//                    throw new Exception("Failed to generate response from GPT.");
//                }
//                //using (HttpClient httpClient = new HttpClient())
//                //{
//                //    using (var httpReq = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/completions"))
//                //    {
//                //        httpReq.Headers.Add("Authorization", $"Bearer {_apiKey}");
//                //        string requestString = JsonSerializer.Serialize(completionRequest);
//                //        httpReq.Content = new StringContent(requestString, Encoding.UTF8, "application/json");
//                //        using (HttpResponseMessage? httpResponse = await httpClient.SendAsync(httpReq))
//                //        {
//                //            if (httpResponse is not null)
//                //            {
//                //                if (httpResponse.IsSuccessStatusCode)
//                //                {
//                //                    string responseString = await httpResponse.Content.ReadAsStringAsync();
//                //                    {
//                //                        if (!string.IsNullOrWhiteSpace(responseString))
//                //                        {
//                //                            completionResponse = JsonSerializer.Deserialize<CompletionResponseDto>(responseString);
//                //                        }
//                //                    }
//                //                }
//                //            }
//                //            return completionResponse;
//                //        }
//                //    }
//                //}
//            }
//            catch (Exception ex)
//            {

//                throw;
//            }
//        }
//    }
//}
