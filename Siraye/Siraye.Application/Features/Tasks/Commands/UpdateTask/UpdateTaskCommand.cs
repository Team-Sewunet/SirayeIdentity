using MediatR;
using Siraye.Application.Exceptions;
using Siraye.Application.Interfaces.Repositories;
using Siraye.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Siraye.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest<Response<int>>
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public Guid AssignedTo { get; set; }
        public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Response<int>>
        {
            private readonly ITaskRepositoryAsync _taskRepository;
            public UpdateTaskCommandHandler(ITaskRepositoryAsync taskRepository)
            {
                _taskRepository = taskRepository;
            }
            public async Task<Response<int>> Handle(UpdateTaskCommand command, CancellationToken cancellationToken)
            {
                var task = await _taskRepository.GetByIdAsync(command.id);

                if (task == null)
                {
                    throw new ApiException($"Task Not Found.");
                }
                else
                {
                    task.Title = command.Title;
                    task.Description = command.Description;
                    task.Status = command.Status;
                    task.DueDate = command.DueDate;
                    task.AssignedTo = command.AssignedTo;
                    await _taskRepository.UpdateAsync(task);
                    return new Response<int>(task.Id);
                }
            }
        }
    }
}
