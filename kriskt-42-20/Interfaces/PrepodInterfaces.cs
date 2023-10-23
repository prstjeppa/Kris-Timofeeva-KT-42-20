﻿using kriskt_42_20.Models;
using kriskt_42_20.Database;
using kriskt_42_20.Filters.PrepodFilters;
using Microsoft.EntityFrameworkCore;

namespace kriskt_42_20.Interfaces.PrepodInterfaces
{
    public interface IPrepodService
    {
        public Task<Prepod[]> GetPrepodsByGroupAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken);
    }
    public class PrepodService : IPrepodService
    {
        private readonly PrepodDbcontext _dbContext;
        public PrepodService(PrepodDbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Prepod[]> GetPrepodsByGroupAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = _dbContext.Set<Prepod>().Where(w => w.Kafedra.KafedraName == filter.KafedraName).ToArrayAsync(cancellationToken);

            return prepod;
        }
    }
}