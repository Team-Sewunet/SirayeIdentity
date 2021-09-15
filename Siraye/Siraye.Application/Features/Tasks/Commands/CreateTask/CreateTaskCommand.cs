using AutoMapper;
using MediatR;
using Siraye.Application.Interfaces.Repositories;
using Siraye.Application.Wrappers;
using Siraye.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Siraye.Application.Features.Tasks.Commands.CreateTask
{
    public partial class CreateTaskCommand : IRequest<Response<int>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public Guid AssignedTo { get; set; }
    }
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Response<int>>
    {
        private readonly ITaskRepositoryAsync _taskRepository;
        private readonly IMapper _mapper;
        public CreateTaskCommandHandler(ITaskRepositoryAsync taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var _task = _mapper.Map<TaskEntity>(request);
            await _taskRepository.AddAsync(_task);
            return new Response<int>(_task.Id);
        }
    }
}
