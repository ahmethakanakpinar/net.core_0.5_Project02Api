using FluentValidation;
using HotelProject.Web.Dtos.ContactDto;

namespace HotelProject.Web.ValidationRules.ContactValidationRules
{
    public class SendMessageValidator : AbstractValidator<SendMessageDto>
    {
        public SendMessageValidator()
        {
            RuleFor(x => x.ReceiverName)
            .NotNull().NotEmpty()
            .WithMessage("Isim Soyisim Bos gecilemez")
            .MaximumLength(50)
            .WithMessage("50 Harften fazla olamaz");

            RuleFor(x => x.Receiver)
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
