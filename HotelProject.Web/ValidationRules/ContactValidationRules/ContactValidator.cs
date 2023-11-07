using FluentValidation;
using HotelProject.Web.Dtos.ContactDto;

namespace HotelProject.Web.ValidationRules.ContactValidationRules
{
    public class ContactValidator : AbstractValidator<CreateContactDto>
    {
        public ContactValidator()
        {
            //RuleFor(x => x.SenderName).NotEmpty().WithMessage("İsim Soyisim Boş geçilemez").MaximumLength(50).WithMessage("50 Harften fazla olamaz.");
            //RuleFor(x => x.Sender).NotEmpty().WithMessage("Mail Boş geçilemez").EmailAddress().WithMessage("Hatalı Mail girişi");
            //RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş geçilemez").MaximumLength(100).WithMessage("100 Harften fazla olamaz.");
            //RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj Boş geçilemez").MaximumLength(200).WithMessage("200 Harften fazla olamaz.");
            RuleFor(x => x.SenderName)
            .NotNull().NotEmpty()
            .WithMessage("Isim Soyisim Bos gecilemez")
            .MaximumLength(50)
            .WithMessage("50 Harften fazla olamaz");

            RuleFor(x => x.Sender)
                .NotNull().NotEmpty()
                .WithMessage("Mail Bos gecilemez")
                .EmailAddress()
                .WithMessage("Hatalı Mail girişi");

            RuleFor(x => x.Subject)
                .NotNull().NotEmpty()
                .WithMessage("Konu Bos gecilemez")
                .MaximumLength(100)
                .WithMessage("100 Harften fazla olamaz");

            RuleFor(x => x.MessageContent)
                .NotNull().NotEmpty()
                .WithMessage("Mesaj Bos gecilemez")
                .MaximumLength(200)
                .WithMessage("200 Harften fazla olamaz");
        }
    }
}
