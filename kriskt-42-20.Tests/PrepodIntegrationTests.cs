using kriskt_42_20.Database;
using kriskt_42_20.Filters.PrepodKafedraFilters;
using kriskt_42_20.Models;
using kriskt_42_20.Interfaces.PrepodInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        public async Task GetPrepodsByKafedraAsync_KT4220_TwoObjects()
        {
            // Arrange
            var ctx = new PrepodDbcontext(_dbContextOptions);
            var prepodService = new PrepodService(ctx);
            var kafedra = new List<Kafedra>
            {
                new Kafedra
                {
                    KafedraName = "Кафедра вычислительной техники"
                },
                new Kafedra
                {
                    KafedraName = "Кафедра компьютерных технологий"
                },
                new Kafedra
                {
                    KafedraName = "Кафедра информационных технологий и кибербезопасности (базовая)"
                }
            };
            await ctx.Set<Kafedra>().AddRangeAsync(kafedra);

            var prepods = new List<Prepod>
            {
                new Prepod
                {
                    FirstName = "Анна",
                    LastName = "Владимировна",
                    MiddleName = "Щипцова",
                    KafedraId = 1,
                },
                new Prepod
                {
                    FirstName = "Татьяна",
                    LastName = "Ароновна",
                    MiddleName = "Ларина",
                    KafedraId = 2,
                }
            };
            await ctx.Set<Prepod>().AddRangeAsync(prepods);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new PrepodKafedraFilter
            {
                KafedraName = "Кафедра компьютерных технологий"
            };
            var prepodsResult = await prepodService.GetPrepodsByKafedraAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(1, prepodsResult.Length);
        }
    }
}
