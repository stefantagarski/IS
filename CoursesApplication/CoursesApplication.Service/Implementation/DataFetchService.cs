using System.Net.Http;
using System.Net.Http.Json;
using CoursesApplication.Domain.DomainModels;
using CoursesApplication.Domain.DTO;
using CoursesApplication.Service.Interface;

namespace CoursesApplication.Service.Implementation;

public class DataFetchService : IDataFetchService
{
    private readonly HttpClient _httpClient;
    private readonly ICourseService _courseService;
    
    public DataFetchService(IHttpClientFactory httpClientFactory, ICourseService courseService)
    {
        _httpClient = httpClientFactory.CreateClient();
        _courseService = courseService;
    }
    public async Task<List<Course>> FetchCoursesFromApi()
    {
        var coursesDto = await _httpClient.GetFromJsonAsync<List<CourseDetailsDTO>>("http://is-lab4.ddns.net:8080/courses");
        var courses = coursesDto.Select(x => new Course()
        {
            Id = Guid.NewGuid(),
            Name = x.Title,
            Credits = x.ECTS,
            SemesterType = x.SemesterType,
        }).ToList();
        _courseService.InsertMany(courses);
        return courses;
    }
}