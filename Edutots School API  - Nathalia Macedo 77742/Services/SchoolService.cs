using System.Net.Http.Json;
using Edutots_School_API____Nathalia_Macedo_77742.Models;


namespace Edutots_School_API____Nathalia_Macedo_77742.Services;

// This class talks to the API, so the page doesn't have to.
public class SchoolService
{
    private readonly HttpClient _http;

    public SchoolService(HttpClient http)
    {
        _http = http;
    }

    // Gets all schools from the API and turns the JSON into a list of School objects
    public async Task<List<School>> GetSchoolsAsync()
    {
        var schools = await _http.GetFromJsonAsync<List<School>>("api/school");

        // If the API sends nothing back, return an empty list instead of null
        return schools ?? new List<School>();
    }
}
