using AssessmentPlatform.Model.DTO;
using AssessmentPlatform.Web.Services.Interface;

namespace AssessmentPlatform.Web.Services.Service
{
    public class AccountServices : IAccount
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        public AccountServices(HttpClient client, IConfiguration config) 
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _config = config ?? throw new ArgumentNullException("config");
        }

        public async Task<bool> checkUser(ValidateUserInput validateUserInput)
        {
            JsonContent content = JsonContent.Create(validateUserInput);
            string callUrl = _config.GetValue<string>("AppSettings:APIUrl")+ "api/User/ValidateUser";
            var response = await _client.PostAsync(callUrl, content);
            var contents = await response.Content.ReadAsStringAsync();
            return Convert.ToBoolean(contents);
        }
    }
}
