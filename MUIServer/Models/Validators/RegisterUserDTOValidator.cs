using FluentValidation;
using MUIServer.Entities;

namespace MUIServer.Models.Validators
{
    public class RegisterUserDTOValidator : AbstractValidator<RegisterUserDTO>
    {
        public RegisterUserDTOValidator(MainServerDbContext mainServerDbContext)
        {
            RuleFor(a => a.BirthDate)
                .NotEmpty();
            
            RuleFor(b => b.UserName).NotEmpty().MinimumLength(3);

            RuleFor(i => i.UserName).Custom((value, context) =>
            {
                var userNameInUse = mainServerDbContext.Users.Any(j => j.UserName == value);

                if (userNameInUse)
                {
                    context.AddFailure("UserName", "UserName is in use.");
                }

            });

            RuleFor(c => c.EmailAddress)
                .NotEmpty()
                .EmailAddress();
            
            RuleFor(g => g.EmailAddress).Custom((value, context) => 
            {
                var emailInUse = mainServerDbContext.Users.Any(h => h.EmailAddress== value);

                if (emailInUse)
                {
                    context.AddFailure("Email", "Change E-mail address, that E-mail is in use.");
                }

            });
            
            RuleFor(d => d.Password)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(e => e.ConfirmPassword)
                .Equal(f => f.Password);

            
            
        }
    }
}
