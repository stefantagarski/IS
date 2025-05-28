using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoursesApplication.Domain.DomainModels;
using CoursesApplication.Domain.DTO;
using CoursesApplication.Repository.Data;
using CoursesApplication.Service.Interface;
using Microsoft.AspNetCore.Authorization;

namespace CoursesApplication.Web.Controllers
{
    [Authorize]
    public class StudentOnCourseController : Controller
    {
        private readonly IStudentOnCourseService _studentOnCourseService;
        private readonly ISemesterService _semesterService;

        public StudentOnCourseController(IStudentOnCourseService studentOnCourseService, ISemesterService semesterService)
        {
            _studentOnCourseService = studentOnCourseService;
            _semesterService = semesterService;
        }


        // GET: StudentOnCourse
        // Enrolled Courses Page
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_studentOnCourseService.GetAllByPassengerId(userId));
        }

        public IActionResult EnrollOnCourse(Guid courseId)
        {
            ViewData["SemesterId"] = new SelectList(_semesterService.GetAll(), "Id", "Name");
            ViewData["CourseId"] = courseId;
            return View();
        }

        [HttpPost]
        public IActionResult SubmitCourseEnrollemnt(EnrollOnCourseDto enrollOnCourseDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _studentOnCourseService.EnrollOnCourse(userId, enrollOnCourseDto.CourseId, enrollOnCourseDto.SemesterId, enrollOnCourseDto.ReEnroll);
            return RedirectToAction("Index");
        }
    }
}
