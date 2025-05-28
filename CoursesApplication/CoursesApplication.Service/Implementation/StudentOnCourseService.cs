using CoursesApplication.Domain.DomainModels;
using CoursesApplication.Repository.Interface;
using CoursesApplication.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoursesApplication.Service.Implementation;

public class StudentOnCourseService : IStudentOnCourseService
{
    private readonly IRepository<StudentOnCourse> _studentOnCourseRepository;
    private readonly ICourseService _courseService;
    private readonly ISemesterService _semesterService;

    public StudentOnCourseService(IRepository<StudentOnCourse> studentOnCourseRepository, ICourseService courseService, ISemesterService semesterService)
    {
        _studentOnCourseRepository = studentOnCourseRepository;
        _courseService = courseService;
        _semesterService = semesterService;
    }

    public StudentOnCourse EnrollOnCourse(string studentId, Guid courseId, Guid semesterId, bool reEnrolled)
    {
        var course = _courseService.GetById(courseId);
        var semester = _semesterService.GetById(semesterId);

        var studentOnCourse = new StudentOnCourse()
        {
            StudentId = studentId,
            CourseId = courseId,
            Course = course,
            Semester = semester,
            SemesterId = semester.Id,
            ReEnrollment = reEnrolled
        };
        
        return _studentOnCourseRepository.Insert(studentOnCourse);
    }

    public List<StudentOnCourse> GetAll()
    {
        return _studentOnCourseRepository.GetAll(selector: x => x).ToList();
    }

    public List<StudentOnCourse> GetAllByPassengerId(string passengerId)
    {
        return _studentOnCourseRepository.GetAll(selector: x => x,
            predicate: x => x.StudentId == passengerId,
            include: x => x.Include(y => y.Course).Include(y => y.Semester)).ToList();
    }

    public StudentOnCourse? GetById(Guid id)
    {
        return _studentOnCourseRepository.Get(selector: x => x, predicate: x => x.Id == id);
    }

    public StudentOnCourse Insert(StudentOnCourse flight)
    {
        return _studentOnCourseRepository.Insert(flight);
    }

    public StudentOnCourse Update(StudentOnCourse flight)
    {
        return _studentOnCourseRepository.Update(flight);
    }

    public StudentOnCourse DeleteById(Guid id)
    {
        var entity = GetById(id);

        if (entity == null)
        {
            throw new ArgumentNullException("");
        }
        
        return _studentOnCourseRepository.Delete(entity);
    }
}