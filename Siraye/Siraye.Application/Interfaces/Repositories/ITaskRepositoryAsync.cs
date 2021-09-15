using Siraye.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siraye.Application.Interfaces.Repositories
{
    public interface ITaskRepositoryAsync : IGenericRepositoryAsync<TaskEntity>
    {
        Task<bool> IsUniqueTitleAsync(string title);
    }
}
