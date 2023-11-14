using kriskt_42_20.Database;
using kriskt_42_20.Filters.PrepodDegreeFilters;
using kriskt_42_20.Interfaces.DegreesInterfaces;
using kriskt_42_20.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kriskt_42_20.Tests
{
    public class DegreeIntegrationTests
    {
        public readonly DbContextOptions<PrepodDbcontext> _dbContextOptions;

        public DegreeIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<PrepodDbcontext>()
            .UseInMemoryDatabase(databaseName: "prepod_db")
            .Options;
        }
        [Fact]
        public async Task GetPrepodsByDegreeAsync_KT4220_TwoObjects()
        {
            var ctx = new PrepodDbcontext(_dbContextOptions);
            var degreeService = new DegreeService(ctx);
            var degree = new List<Degree>
            {
                new Degree
                {
                    Name_degree = "доктор наук"
                },
                new Degree
                {
                    Name_degree = "кандидат наук"
                }
            };
            await ctx.Set<Degree>().AddRangeAsync(degree);

            var prepods = new List<Prepod>
            {
                new Prepod
                {
                    FirstName = "123",
                    LastName = "123",
                    MiddleName = "123",
                    Phone = "555",
                    Mail = "123@mail.ru",
                    KafedraId = 1,
                    DegreeId = 2,
                },
                new Prepod
                {
                    FirstName = "mem",
                    LastName = "mem",
                    MiddleName = "mem",
                    Phone = "9999",
                    Mail = "mem@gmail.com",
                    KafedraId = 2,
                    DegreeId = 2,
                }
            };
            await ctx.Set<Prepod>().AddRangeAsync(prepods);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new PrepodDegreeFilter
            {
                Name_degree = "кандидат наук"
            };
            var prepodsResult = await degreeService.GetPrepodsByDegreeAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(0, prepodsResult.Length);
        }
        

    }
}

