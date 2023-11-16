using kriskt_42_20.Database;
using kriskt_42_20.Models;
using kriskt_42_20.Interfaces.PrepodsInterfaces;
using Microsoft.EntityFrameworkCore;
using kriskt_42_20.Filters.PrepodKafedraFilters;

namespace kriskt_42_20.Tests
{
    public class PrepodIntegrationTests
    {
        public readonly DbContextOptions<PrepodDbcontext> _dbContextOptions;

        public PrepodIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<PrepodDbcontext>()
            .UseInMemoryDatabase(databaseName: "prepod_db")
            .Options;
        }

        [Fact]
        public async Task GetPrepodsByKafedraAsync_KT4220_OneObjects()
        {
            // Arrange
            var ctx = new PrepodDbcontext(_dbContextOptions);
            var prepodService = new PrepodService(ctx);
            var kafedra = new List<Kafedra>
            {
                new Kafedra
                {
                    KafedraId =1,
                    KafedraName = "кафедра компьютерных технологий"
                },
                new Kafedra
                {   
                    KafedraId =2,
                    KafedraName = "кафедра инженерной техники"
                }
            };
            await ctx.Set<Kafedra>().AddRangeAsync(kafedra);

            await ctx.SaveChangesAsync();

            var degree = new List<Degree>
            {
                new Degree
                {
                    DegreeId =1,
                    Name_degree = "доктор наук"
                },
                new Degree
                {
                    DegreeId =2,
                    Name_degree = "кандидат наук"
                }
            };
            await ctx.Set<Degree>().AddRangeAsync(degree);

            await ctx.SaveChangesAsync();

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
                    DegreeId = 2
                },
                new Prepod
                {
                    FirstName = "mem",
                    LastName = "mem",
                    MiddleName = "mem",
                    Phone = "9999",
                    Mail = "mem@gmail.com",
                    KafedraId = 1,
                    DegreeId = 2
                },
                new Prepod
                {
                    FirstName = "mem1",
                    LastName = "mem1",
                    MiddleName = "mem1",
                    Phone = "99991",
                    Mail = "mem1@gmail.com",
                    KafedraId = 2,
                    DegreeId = 2
                }
            };
            await ctx.Set<Prepod>().AddRangeAsync(prepods);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new PrepodKafedraFilter
            {
                KafedraName = "кафедра компьютерных технологий"
            };
            var prepodsResult = await prepodService.GetPrepodsByKafedraAsync(filter, CancellationToken.None);

            Assert.Equal(2, prepodsResult.Length);
        }
    }
}
