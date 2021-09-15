using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using Siraye.Application.Interfaces.Repositories;
using Siraye.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Siraye.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        private readonly ITaskRepositoryAsync _taskRepository;

        public CreateTaskCommandValidator(ITaskRepositoryAsync taskRepository)
        {
            this._taskRepository = taskRepository;

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueTitle).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.Status)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        }

        private async Task<bool> IsUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await _taskRepository.IsUniqueTitleAsync(title);
        }
    }
}
