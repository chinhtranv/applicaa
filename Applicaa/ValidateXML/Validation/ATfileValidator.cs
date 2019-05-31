using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ValidateXML.Validation
{
    public class ATfileValidator : AbstractValidator<ATfile>
    {

        public ATfileValidator()
        {
            RuleFor(tfile => tfile.ATFpupilData).NotNull().WithMessage("Pupil data could not be null")
                                                .NotEmpty().WithMessage("Pupil data could not be empty");

        }
    }


    public class ATfilePupiValidator : AbstractValidator<ATfilePupil>
    {
        public ATfilePupiValidator()
        {
            RuleFor(x => x.ApplicationReference).NotNull().WithMessage("ApplicationReference could not be null")
                                    .NotEmpty().WithMessage("ApplicationReference could not be empty");

            RuleFor(x => x.Forename).NotNull().WithMessage("Forename could not be null")
                                    .NotEmpty().WithMessage("Forename could not be empty");

            RuleFor(x => x.Surname).NotNull().WithMessage("Surname could not be null")
                                   .NotEmpty().WithMessage("Surname could not be empty");

            RuleFor(x => x.DOB).NotNull().WithMessage("DOB could not be null")
                               .NotEmpty().WithMessage("DOB could not be empty");

            RuleFor(x => x.Gender).NotNull().WithMessage("Gender could not be null")
                                  .NotEmpty().WithMessage("Gender could not be empty")
                                 .Must(x => x == "M" || x == "F").WithMessage("Gender must be F or M");


        }
    }
}
