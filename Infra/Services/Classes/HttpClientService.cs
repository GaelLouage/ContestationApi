using Infra.Dtos;
using Infra.Enum;
using Infra.Mappers;
using Infra.Models;
using Infra.Services.Interfaces;
using Infra.Singeltons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services.Classes
{
    public class HttpClientService : Interfaces.HttpClientService
    {
        private readonly HttpClient _httpClient;
        public HttpClientService(string baseAddress)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", UserSingleton.Instance.Token);
        }
        public async Task<ResponseDto?> GetResponseByFineNumberAsync(string fineNumber)
        {
            try
            {
                var status = await _httpClient.GetAsync($"Pdf/GetResponseByFineNumber?fineNumber={fineNumber}");

                if (status.IsSuccessStatusCode)
                {
                    var data = await status.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<ResponseDto?>(data);

                }
                else
                {
                    var error = await status.Content.ReadAsStringAsync();
                    return null;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Response>> GetResponsesAsync()
        {
            try
            {
                var status = await _httpClient.GetAsync("Pdf/GetResponses");

                if (status.IsSuccessStatusCode)
                {
                    var data = await status.Content.ReadAsStringAsync();

                    var responses = JsonConvert.DeserializeObject<List<Response>>(data);

                    return responses;
                }
                else
                {
                    var error = await status.Content.ReadAsStringAsync();
                    return null;
                }
            }
            catch 
            {
                return null;
            }
        }


        public async Task GetOpposersAsync(List<OpposerTask> opposersTasks, Action? action = null)
        {
            try
            {
                var status = await _httpClient.GetAsync("Pdf/GetOppossers");

                if (status.IsSuccessStatusCode)
                {
                    var data = await status.Content.ReadAsStringAsync();

                    var opposers = JsonConvert.DeserializeObject<List<OpposerDto>>(data);

                    foreach (var opposer in opposers)
                    {
                        var decision = (await GetResponseByFineNumberAsync(opposer.FineNumber));
                        var decisionToString = "NONE";
                        if (decision is not null)
                        {
                            decisionToString = decision.Decision == DecisionType.ACCEPTED ? "ACCEPTED" :
                                               decision.Decision == DecisionType.REJECTED ? "REJECTED" : "NONE";
                        }
                        opposersTasks.Add(opposer.MapToOpposerTask(decisionToString));
                    }
                    action?.Invoke();
                }
                else
                {
                    var error = await status.Content.ReadAsStringAsync();
                }
            }
            catch { }
        }

        public async Task DownloadPdfAsync(OpposerTask opposer, Action<string> action)
        {
            try
            {
                var status = await _httpClient.GetAsync($"Pdf/GetPdfByFineNumber?fineNumber={opposer.FineNumber}");

                if (status.IsSuccessStatusCode)
                {
                    var data = await status.Content.ReadAsStringAsync();

                    var pdf = JsonConvert.DeserializeObject<PdfDto>(data);
                    // Convert to bytes
                    byte[] pdfBytes = Convert.FromBase64String(pdf.PdfByteArray);

                    var tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"{opposer.FineNumber}.pdf");
                    await File.WriteAllBytesAsync(tempFilePath, pdfBytes);
                    action?.Invoke(tempFilePath);
                }
                else
                {
                    var error = await status.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<bool> GetPdfByFineNumberAsync(OpposerTask opposer)
        {
            try
            {
                var status = await _httpClient.GetAsync($"Pdf/GetPdfByFineNumber?fineNumber={opposer.FineNumber}");

                if (status.IsSuccessStatusCode)
                {
                    return true;
                }
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> InsertResponseAsync(List<OpposerTask> opposersTasks, DecisionType decisionType, OpposerTask opposer, string notes, Action action)
        {
            try
            {
                var responseDto = new ResponseDto()
                {
                    FineNumber = opposer.FineNumber,
                    Notes = notes,
                    Decision = decisionType,
                    Currency = "$",
                    DecisionDate = DateTime.Now.ToLongDateString(),
                    ReviewedBy = UserSingleton.Instance.User.UserName
                };
                var json = JsonConvert.SerializeObject(responseDto);

                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var status = await _httpClient.PostAsync("Pdf/InsertResponseType", data);

                if (status.IsSuccessStatusCode)
                {
                    var token = await status.Content.ReadAsStringAsync();
                    await GetOpposersAsync(opposersTasks);
                    // save pdf to database

                    var savePdf = await _httpClient.GetAsync($"Pdf?fineNumber={opposer.FineNumber}");
                    if (status.IsSuccessStatusCode)
                    {
                        action?.Invoke();
                        return $"Fine#:{responseDto.FineNumber} processed.";
                    }
                    return "Pdf wasn't saved into database.";
                   
                }
                else
                {
                    var error = await status.Content.ReadAsStringAsync();
                    return error;

                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public async Task<string> UpdateResponseAsync(List<OpposerTask> opposersTasks, DecisionType decisionType, OpposerTask opposer, string notes, Action action)
        {
            try
            {
                var responseDto = new ResponseDto()
                {
                    FineNumber = opposer.FineNumber,
                    Notes = notes,
                    Decision = decisionType,
                    Currency = "$",
                    DecisionDate = DateTime.Now.ToLongDateString(),
                    ReviewedBy = UserSingleton.Instance.User.UserName
                };
                var json = JsonConvert.SerializeObject(responseDto);

                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var status = await _httpClient.PatchAsync("Pdf/UpdateResponseType", data);

                if (status.IsSuccessStatusCode)
                {
                    var token = await status.Content.ReadAsStringAsync();
                    await GetOpposersAsync(opposersTasks);
                    // save pdf to database

                    var savePdf = await _httpClient.GetAsync($"Pdf?fineNumber={opposer.FineNumber}");
                    if (status.IsSuccessStatusCode)
                    {
                        action?.Invoke();
                        return $"Fine#:{responseDto.FineNumber} processed.";
                    }
                    return "Pdf wasn't saved into database.";

                }
                else
                {
                    var error = await status.Content.ReadAsStringAsync();
                    return error;

                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public async Task<string> LoginAsync(string userName, string password, Action action)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                {
                    return "Password & username cannot be empty";
                }
                var loginDto = new LoginDto()
                {
                    UserName = userName,
                    Password = password,
                };
                var json = JsonConvert.SerializeObject(loginDto);

                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var status = await _httpClient.PostAsync("User/Login", data);

                if (status.IsSuccessStatusCode)
                {
                    var token = await status.Content.ReadAsStringAsync();
                    UserSingleton.Instance.Token = token;
                    UserSingleton.Instance.User.UserName = loginDto.UserName;
                    UserSingleton.Instance.IsLoggedIn = true;
                    action?.Invoke();
                    return "";
                }
                else
                {
                    var error = await status.Content.ReadAsStringAsync();
                    return "Login failed: " + error;

                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
