using FrontEnd_Student.Models;

namespace FrontEnd_Student.Services
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Student>>("https://localhost:7093/studentAPI/GetAllStudents");
        }

        public async Task<Student?> GetStudentByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Student>($"https://localhost:7093/studentAPI/GetStudentById/{id}");
        }

        public async Task<Student?> CreateStudentAsync(Student student)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7093/studentAPI/InsertNewStudent", student);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Student>();
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7093/studentAPI/DeleteStudentById/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<Student?> UpdateStudentAsync(Guid id, Student student)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7093/studentAPI/UpdateStudent/{id}", student);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Student>();
        }
    }
}

