using AssessmentPlatform.Model.DB;
using AssessmentPlatform.Model.DTO;
using AssessmentPlatform.Web.Services.Interface;
using Microsoft.VisualBasic;
using System.Text.Json;

namespace AssessmentPlatform.Web.Services.Service
{
    public class AdminServices : IAdmin
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        public AdminServices(HttpClient client, IConfiguration config)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _config = config ?? throw new ArgumentNullException("config");
        }

        public async Task<string> CreateorUpdateCollege(CollegeInput collegeInput, string[] course)
        {
            JsonContent content = JsonContent.Create(collegeInput);
            string callUrl = _config.GetValue<string>("AppSettings:APIUrl") + "api/registration/AddCollege";
            var response = await _client.PostAsync(callUrl, content);
            var contents = await response.Content.ReadAsStringAsync();
            return contents;
        }

        public async Task<string> CreateorUpdateHiringPartner(HiringPartnerInput hiringPartnerInput)
        {
            JsonContent content = JsonContent.Create(hiringPartnerInput);
            string callUrl = _config.GetValue<string>("AppSettings:APIUrl") + "api/registration/AddHiringPartner";
            var response = await _client.PostAsync(callUrl, content);
            var contents = await response.Content.ReadAsStringAsync();
            return contents;
        }

        public async Task<string> CreateorUpdateTrainingCompany(TrainingCompanyInput trainingPartnerInput)
        {
            JsonContent content = JsonContent.Create(trainingPartnerInput);
            string callUrl = _config.GetValue<string>("AppSettings:APIUrl") + "api/registration/AddTrainingCompany";
            var response = await _client.PostAsync(callUrl, content);
            var contents = await response.Content.ReadAsStringAsync();
            return contents;
        }

        public async Task<string> CreateorUpdateUniversity(UniversityInput universityInput)
        {
            JsonContent content = JsonContent.Create(universityInput);
            string callUrl = _config.GetValue<string>("AppSettings:APIUrl") + "api/registration/AddUniversity";
            var response = await _client.PostAsync(callUrl, content);
            var contents = await response.Content.ReadAsStringAsync();
            return contents;
        }

        public async Task<List<BranchCollege>> ListofBranchinCollege()
        {
            string callUrl = _config.GetValue<string>("AppSettings:APIUrl") + "api/registration/GetAllCollegeBranch";
            var response = await _client.GetAsync(callUrl);
            var vv = response.Content.ReadAsAsync<List<BranchCollege>>().Result;
            return vv;
        }

        public async Task<List<Course>> ListofCourse()
        {
            string callUrl = _config.GetValue<string>("AppSettings:APIUrl") + "api/registration/GetAlCourses";
            var response = await _client.GetAsync(callUrl);
            var vv = response.Content.ReadAsAsync<List<Course>>().Result;
            return vv;
        }

        public async Task<List<UniversityInput>> ListofUniversity()
        {
         
            string callUrl = _config.GetValue<string>("AppSettings:APIUrl") + "api/registration/GetAllUniversities";
            var response = await _client.GetAsync(callUrl);
            var vv = response.Content.ReadAsAsync<List<UniversityInput>>().Result;
            return vv;
        }
    }
}
