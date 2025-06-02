using AssessmentPlatform.Model.DTO;

namespace AssessmentPlatform.Web.Services.Interface
{
    public interface IAccount
    {
        Task<bool> checkUser(ValidateUserInput validateUserInput);
    }
}
