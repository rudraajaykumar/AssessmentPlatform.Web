using AssessmentPlatform.Model.DTO;
using AssessmentPlatform.Web.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

namespace AssessmentPlatform.Web.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IAdmin _admin;
        public RegistrationController(IAdmin admin)
        {
            _admin = admin;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> University()
        {
            var listofuniversity = await _admin.ListofUniversity();

            ViewBag.University = listofuniversity.Select(s => new SelectListItem
            {
                Value = s.UniversityID.ToString(),
                Text = s.UniversityName
            }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> University(UniversityInput vui)
        {
            string Universitystatus = await _admin.CreateorUpdateUniversity(vui);

            ViewBag.Message = Universitystatus;
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> College()
        {
            var listofuniversity = await _admin.ListofUniversity();

            ViewBag.University = listofuniversity.Select(s => new SelectListItem
            {
                Value = s.UniversityID.ToString(),
                Text = s.UniversityName
            }).ToList();

            var listofBranch = await _admin.ListofBranchinCollege();

            //ViewData["Course"] = listofCourse.Where(w => w.CourseTypeID == 1).Select(s => new SelectListItem
            //{
            //    Value = s.CourseID.ToString(),
            //    Text = s.CourseName
            //}).ToList();

            ViewBag.Branch = listofBranch.Select(s => new SelectListItem
            {
                Value = s.BranchCollegeID.ToString(),
                Text = s.BranchCollegeName
            }).ToList();

            var listofCourse = await _admin.ListofCourse();

                  //ViewData["Course"] = listofCourse.Where(w => w.CourseTypeID == 1).Select(s => new SelectListItem
                  //{
                  //    Value = s.CourseID.ToString(),
                  //    Text = s.CourseName
                  //}).ToList();

            ViewBag.Course = listofCourse.Where(w => w.CourseTypeID == 1).Select(s => new SelectListItem
            {
                Value = s.CourseID.ToString(),
                Text = s.CourseName
            }).ToList();


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> College(CollegeInput vui, string[] course, string[] branch)
        {
            if (course.Length > 0)
            {
                vui.Course = string.Join(",", course);
            }
            if (branch.Length > 0)
            {
                vui.branch = string.Join(",", branch);
            }
            string College = await _admin.CreateorUpdateCollege(vui, course);

            ViewBag.Message = College;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TrainingCompany()
        {
            var listofCourse = await _admin.ListofCourse();

            ViewBag.Course = listofCourse.Where(w => w.CourseTypeID == 2).Select(s => new SelectListItem
            {
                Value = s.CourseID.ToString(),
                Text = s.CourseName
            }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TrainingCompany(TrainingCompanyInput vui, string[] course)
        {
            if (course.Length > 0)
            {
                vui.Course = string.Join(",", course);
            }
            string TrainingCompany = await _admin.CreateorUpdateTrainingCompany(vui);

            ViewBag.Message = TrainingCompany;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> HiringPartner()
        {
          
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> HiringPartner(HiringPartnerInput vui)
        {
            string HiringPartner = await _admin.CreateorUpdateHiringPartner(vui);

            ViewBag.Message = HiringPartner;
            return View();
        }
    }
}
