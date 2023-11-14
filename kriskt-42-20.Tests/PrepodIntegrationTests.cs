﻿using kriskt_42_20.Database;
using kriskt_42_20.Filters.PrepodKafedraFilters;
using kriskt_42_20.Models;
using kriskt_42_20.Interfaces.PrepodsInterfaces;
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
                    KafedraName = "кафедра компьютерных технологий"
                },
                new Kafedra
                {
                    KafedraName = "кафедра вычислительной техники"
                }
            };
            await ctx.Set<Kafedra>().AddRangeAsync(kafedra);

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
            var filter = new PrepodKafedraFilter
            {
                KafedraName = "кафедра вычислительной техники"
            };
            var prepodsResult = await prepodService.GetPrepodsByKafedraAsync(filter, CancellationToken.None);

            // Assert
            //Assert.Single(prepodsResult);
            Assert.Equal(0, prepodsResult.Length);
        }
    }
}
