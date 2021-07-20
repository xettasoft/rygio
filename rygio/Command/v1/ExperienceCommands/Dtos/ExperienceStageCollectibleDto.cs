using FluentValidation;
using rygio.DataAccess;
using rygio.Domain.AppData;
using rygio.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Command.v1.ExperienceCommands.Dtos
{

    public class ExperienceStageCollectibleDto
    {
        public int CollectableId { get; set; }
        
    }

    public class ExperienceStageCollectibleDtoValidator : AbstractValidator<ExperienceStageCollectibleDto>
    {
        private ApplicationDbContext _context;
        public ExperienceStageCollectibleDtoValidator()
        {
           

            RuleFor(x => x.CollectableId).NotNull().LessThan(0).WithMessage("Invalid CollectableId.");

        }

        private bool UniqueName(string name)
        {

            return false;
        }
    }
}
