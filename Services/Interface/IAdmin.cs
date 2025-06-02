using AssessmentPlatform.Model.DB;
using AssessmentPlatform.Model.DTO;

namespace AssessmentPlatform.Web.Services.Interface
{
    public interface IAdmin
    {

        Task<string> CreateorUpdateUniversity(UniversityInput universityInput);

        Task<List<UniversityInput>> ListofUniversity();

        Task<string> CreateorUpdateCollege(CollegeInput collegeInput, string[] course);

        Task<string> CreateorUpdateHiringPartner(HiringPartnerInput hiringPartnerInput);

        Task<string> CreateorUpdateTrainingCompany(TrainingCompanyInput trainingPartnerInput);

        Task<List<Course>> ListofCourse();

        Task<List<BranchCollege>> ListofBranchinCollege();

    }
}
