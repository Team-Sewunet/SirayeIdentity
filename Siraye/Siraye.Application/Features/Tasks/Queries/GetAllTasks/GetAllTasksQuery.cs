using AutoMapper;
using MediatR;
using Siraye.Application.Interfaces.Repositories;
using Siraye.Application.Wrappers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Siraye.Application.Features.Tasks.Queries.GetAllTasks
{
    public class GetAllTasksQuery : IRequest<PagedResponse<IEnumerable<GetAllTasksViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, PagedResponse<IEnumerable<GetAllTasksViewModel>>>
    {
        private readonly ITaskRepositoryAsync _TaskRepository;
        private readonly IMapper _mapper;
        public GetAllTasksQueryHandler(ITaskRepositoryAsync TaskRepository, IMapper mapper)
        {
            _TaskRepository = TaskRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllTasksViewModel>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllTasksParameter>(request);
            var Task = await _TaskRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var TaskViewModel = _mapper.Map<IEnumerable<GetAllTasksViewModel>>(Task);
            return new PagedResponse<IEnumerable<GetAllTasksViewModel>>(TaskViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
