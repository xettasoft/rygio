using FluentValidation;
using rygio.Helper.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Command.v1.ExperienceCommands.Dtos
{
    public class ExperienceDto
    {
        public string Name { get; set; }
        public string MediaUrl { get; set; }
        public string Description { get; set; }
        public ExperienceType ExperienceType { get; set; }
        public bool IsPrivate { get; set; } = false;
        public DateTime StartBy { get; set; } = DateTime.UtcNow;
        public bool IsFree { get; set; } = true;
        public decimal Amount { get; set; }
        public int TargetMembers { get; set; }
        public string Reference { get; set; }
        public IEnumerable<ExperienceStageDto> Stages { get; set; }
        public IEnumerable<ExperienceMemberDto> ExperienceMembers { get; set; }
    }

    public class ExperienceDtoValidator : AbstractValidator<ExperienceDto>
    {
        public ExperienceDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Invalid Name.");
            RuleFor(x => x.Stages).NotNull().WithMessage("Stages can not be null.");
            RuleFor(x => x.Stages).Must(x => x.Count() >= 2).WithMessage("There must be more than one stage!").When(x => x.Stages != null);
            RuleForEach(x => x.Stages)
                .SetValidator(new ExperienceStageDtoValidator())
                .When(x => x.Stages != null);


        }

        private bool UniqueName(string name)
        {

            return false;
        }
    }
}
