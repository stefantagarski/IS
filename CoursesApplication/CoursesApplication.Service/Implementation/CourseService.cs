using CoursesApplication.Domain.DomainModels;
using CoursesApplication.Repository.Interface;
using CoursesApplication.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoursesApplication.Service.Implementation;

public class CourseService : ICourseService
{
    private readonly IRepository<Course> _courseRepository;

    public CourseService(IRepository<Course> courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public List<Course> GetAll()
    {
        return _courseRepository.GetAll(selector: x => x).ToList();
    }

    public Course? GetById(Guid id)
    {
        return _courseRepository.Get(
            selector: x => x,
            predicate: x => x.Id == id,
            include: x => x
                .Include(y => y.EnrolledStudents)
                .ThenInclude(es => es.Student)
                .Include(y => y.EnrolledStudents)
                .ThenInclude(y => y.Semester)
        );
    }

    public Course Insert(Course course)
    {
        return _courseRepository.Insert(course);
    }

    public ICollection<Course> InsertMany(ICollection<Course> courses)
    {
        return _courseRepository.InsertMany(courses);
    }

    public Course Update(Course flight)
    {
        return _courseRepository.Update(flight);
    }

    public Course DeleteById(Guid id)
    {
        var entity = GetById(id);

        if (entity == null)
        {
            throw new ArgumentNullException("");
        }

        return _courseRepository.Delete(entity);
    }
}