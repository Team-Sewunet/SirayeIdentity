using MediatR;
using Siraye.Application.Exceptions;
using Siraye.Application.Interfaces.Repositories;
using Siraye.Application.Wrappers;
using Siraye.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Siraye.Application.Features.Tasks.Queries.GetTaskById
{
    public class GetTaskByIdQuery : IRequest<Response<TaskEntity>>
    {
        public int Id { get; set; }
        public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Response<TaskEntity>>
        {
            private readonly ITaskRepositoryAsync _TaskRepository;
            public GetTaskByIdQueryHandler(ITaskRepositoryAsync TaskRepository)
            {
                _TaskRepository = TaskRepository;
            }
            public async Task<Response<TaskEntity>> Handle(GetTaskByIdQuery query, CancellationToken cancellationToken)
            {
                var Task = await _TaskRepository.GetByIdAsync(query.Id);
                if (Task == null) throw new ApiException($"Task Not Found.");
                return new Response<TaskEntity>(Task);
            }
        }
    }
}
