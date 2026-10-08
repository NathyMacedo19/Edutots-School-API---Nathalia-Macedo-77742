using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Edutots_School_API____Nathalia_Macedo_77742.Models;
using Edutots_School_API____Nathalia_Macedo_77742.Services;

namespace Edutots_School_API____Nathalia_Macedo_77742.Components.Pages
{
    public partial class Home : ComponentBase
    {
        [Inject]
        public SchoolService Service { get; set; } = null!;

        [Inject]
        public FavouritesService Favourites { get; set; } = null!;

        private List<School>? schools;
        private bool error;
        private string searchText = string.Empty;
        private string sortBy = "name";

        private readonly (string Year, int Students)[] sampleEnrolment =
        {
            ("2021", 640),
            ("2022", 720),
            ("2023", 810),
            ("2024", 865),
            ("2025", 940)
        };

        private int maxStudents => sampleEnrolment.Max(x => x.Students);

        private int WithEmail => schools?.Count(s => !string.IsNullOrWhiteSpace(s.EmailAddress)) ?? 0;

        private int ProprietorCount =>
            schools?.Select(s => s.ProprietorFullName)
                    .Where(name => !string.IsNullOrWhiteSpace(name))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .Count() ?? 0;

        private IEnumerable<School> FavouriteSchools =>
            schools?.Where(s => Favourites.IsFavourite(s.SchoolId)) ?? Enumerable.Empty<School>();

        private IEnumerable<School> FilteredSchools
        {
            get
            {
                if (schools == null) return Enumerable.Empty<School>();
                var q = schools.AsEnumerable();
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    var st = searchText.Trim();
                    q = q.Where(s => (s.SchoolName ?? "").Contains(st, StringComparison.OrdinalIgnoreCase)
                                     || (s.Address ?? "").Contains(st, StringComparison.OrdinalIgnoreCase));
                }
                q = sortBy switch
                {
                    "proprietor" => q.OrderBy(s => s.ProprietorFullName),
                    _ => q.OrderBy(s => s.SchoolName)
                };
                return q;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                schools = await Service.GetSchoolsAsync();
            }
            catch
            {
                error = true;
            }
        }

        private async Task Reload()
        {
            error = false;
            schools = null;
            try
            {
                schools = await Service.GetSchoolsAsync();
            }
            catch
            {
                error = true;
            }
        }

        private void ShowDetails(School school)
        {
            // Placeholder: open a details view or set a selectedSchool variable
        }

        private void ToggleFavourite(School school)
        {
            Favourites.Toggle(school.SchoolId);
        }
    }
}
