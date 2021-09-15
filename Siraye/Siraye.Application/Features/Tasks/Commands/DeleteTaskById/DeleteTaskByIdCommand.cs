using MediatR;
using Siraye.Application.Exceptions;
using Siraye.Application.Interfaces.Repositories;
using Siraye.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Siraye.Application.Features.Tasks.Commands.DeleteTaskById
{
    public class DeleteTaskByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteTaskByIdCommandHandler : IRequestHandler<DeleteTaskByIdCommand, Response<int>>
        {
            private readonly ITaskRepositoryAsync _taskRepository;
            public DeleteTaskByIdCommandHandler(ITaskRepositoryAsync taskRepository)
            {
                _taskRepository = taskRepository;
            }
            public async Task<Response<int>> Handle(DeleteTaskByIdCommand command, CancellationToken cancellationToken)
            {
                var Task = await _taskRepository.GetByIdAsync(command.Id);
                if (Task == null) throw new ApiException($"Task Not Found.");
                await _taskRepository.DeleteAsync(Task);
                return new Response<int>(Task.Id);
            }
        }
    }
}
