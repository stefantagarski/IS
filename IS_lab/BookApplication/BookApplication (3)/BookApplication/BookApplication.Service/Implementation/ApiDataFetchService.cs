using BookApplication.Domain.DomainModels;
using BookApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BookApplication.Service.Implementation
{
    public class ApiDataFetchService : IApiDataFetchService
    {

        private readonly IChapterService _chapterService;
        private readonly IBookService _bookService;
        private readonly HttpClient _httpClient;

        public ApiDataFetchService(IChapterService chapterService, IBookService bookService, HttpClient httpClient)
        {
            _chapterService = chapterService;
            _bookService = bookService;
            _httpClient = httpClient;
        }

        public async Task<List<Book>> FetchBooksFromApi()
        {
            var booksDto = await _httpClient.GetFromJsonAsync<List<BookDTO>>("http://is-lab4.ddns.net:8080");

            var newBooks = booksDto.Select(x => new Book
            {
                Id = Guid.NewGuid(),
                Title = x.name,
                Author = x.authorFirstName + " " + x.authorFirstName,
                ISBN = x.isbnCode,
                Description = x.shortDescription,
                PublishedYear = x.publishedYear
            }).ToList();

            _bookService.InsertMany(newBooks);

            return newBooks;
        }

        public async Task<List<Chapter>> FetchChaptersFromApi(Guid bookId, string index)
        {
            string URL = $"http://is-lab4.ddns.net:8080/chapters?bookId={bookId}&studentIndex={index}";
            HttpResponseMessage message = await _httpClient.PostAsync(URL, null);
            var data = await message.Content.ReadFromJsonAsync<List<Chapter>>();

            _chapterService.InsertMany(data);

            return data;

        }
    }
}
