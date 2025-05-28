using CoursesApplication.Domain.DomainModels;
using CoursesApplication.Repository.Interface;
using CoursesApplication.Service.Interface;

namespace CoursesApplication.Service.Implementation;

public class SemesterService : ISemesterService
{
    private readonly IRepository<Semester> _repository;

    public SemesterService(IRepository<Semester> repository)
    {
        _repository = repository;
    }

    public List<Semester> GetAll()
    {
        return _repository.GetAll(selector: x => x).ToList();
    }

    public Semester? GetById(Guid id)
    {
        return _repository.Get(selector: x => x, predicate: x => x.Id == id);
    }

    public Semester Insert(Semester flight)
    {
        return _repository.Insert(flight);
    }

    public ICollection<Semester> InsertMany(ICollection<Semester> flights)
    {
        return _repository.InsertMany(flights);
    }

    public Semester Update(Semester flight)
    {
        return _repository.Update(flight);
    }

    public Semester DeleteById(Guid id)
    {
        var entity = GetById(id);

        if (entity == null)
        {
            throw new ArgumentNullException("");
        }
        
        return _repository.Delete(entity);
    }
}