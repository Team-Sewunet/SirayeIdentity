using Microsoft.EntityFrameworkCore;
using Siraye.Application.Interfaces.Repositories;
using Siraye.Domain.Entities;
using Siraye.Infrastructure.Persistence.Contexts;
using Siraye.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siraye.Infrastructure.Persistence.Repositories
{
    public class TaskRepositoryAsync : GenericRepositoryAsync<TaskEntity>, ITaskRepositoryAsync
    {
        private readonly DbSet<TaskEntity> _Tasks;

        public TaskRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _Tasks = dbContext.Set<TaskEntity>();
        }

        public Task<bool> IsUniqueTitleAsync(string title)
        {
            return _Tasks
                .AllAsync(p => p.Title!= title);
        }
    }
}
