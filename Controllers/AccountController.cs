using AssessmentPlatform.Model.DTO;
using AssessmentPlatform.Web.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AssessmentPlatform.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccount _account;
        public AccountController(IAccount account)
        {
            _account = account;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(ValidateUserInput vui)
        {
            bool userstatus = await _account.checkUser(vui);
            if (userstatus)
            {
                return View("AdminRegistration");
            }
            return View();
        }

        [HttpGet]
        public IActionResult AdminRegistration()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUniversity(ValidateUserInput vui)
        {
            bool userstatus = await _account.checkUser(vui);
            if (userstatus)
            {
                return View("AdminRegistration");
            }
            return View();
        }

    }
}
