using AutoMapper;
using Siraye.Application.Features.Tasks.Commands.CreateTask;
using Siraye.Application.Features.Tasks.Queries.GetAllTasks;
using Siraye.Domain.Entities;

namespace Siraye.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<TaskEntity, GetAllTasksViewModel>().ReverseMap();
            CreateMap<CreateTaskCommand, TaskEntity>();
            CreateMap<GetAllTasksQuery, GetAllTasksParameter>();
        }
    }
}
