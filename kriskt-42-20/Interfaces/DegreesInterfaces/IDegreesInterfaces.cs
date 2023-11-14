using kriskt_42_20.Database;
using kriskt_42_20.Filters.PrepodDegreeFilters;
using kriskt_42_20.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace kriskt_42_20.Interfaces.DegreesInterfaces
{
        public interface IDegreesService
        {
            public Task<Prepod[]> GetPrepodsByDegreeAsync(PrepodDegreeFilter filter, CancellationToken cancellationToken);
        }

        public class DegreeService : IDegreesService
        {
            private readonly PrepodDbcontext _dbContext;
            public DegreeService(PrepodDbcontext dbContext)
            {
                _dbContext = dbContext;
            }
            public Task<Prepod[]> GetPrepodsByDegreeAsync(PrepodDegreeFilter filter, CancellationToken cancellationToken = default)
            {
                var degrees = _dbContext.Set<Prepod>().Where(w => w.Degree.Name_degree == filter.Name_degree).ToArrayAsync(cancellationToken);

                return degrees;
            }
        }
}
