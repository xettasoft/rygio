using FluentValidation;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Command.v1.ExperienceCommands.Dtos
{
    public class ExperienceStageDto
    {
        public int Stage { get; set; } = 1;
        public string Puzzle { get; set; }
        public bool IsMultiplePickAllowed { get; set; } = false;
        public DateTime VisibleBy { get; set; } = DateTime.UtcNow;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
        public IEnumerable<ExperienceStageCollectibleDto> Collectibles { get; set; }

    }

    public class ExperienceStageDtoValidator : AbstractValidator<ExperienceStageDto>
    {

        public ExperienceStageDtoValidator()
        {
            RuleFor(x => x.Radius).NotNull().NotEqual(0).WithMessage("Radius can not be zero.");
            RuleForEach(x => x.Collectibles)
                .SetValidator(new ExperienceStageCollectibleDtoValidator())
                .When(x => x.Collectibles != null);

        }

        private bool UniqueName(string name)
        {

            return false;
        }
    }
}
