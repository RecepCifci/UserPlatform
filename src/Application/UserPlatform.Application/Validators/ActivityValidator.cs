using FluentValidation;
using UserPlatform.Application.Dtos;
using UserPlatform.Domain.Enums;

namespace UserPlatform.Application.Validators;

public class ActivityValidator : AbstractValidator<ActivityDto>
{
    public ActivityValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("Kullanıcı Idsi boş bırakılamaz ve 0 dan küçük olamaz.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Açıklama alanı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Açıklama alanı en fazla 100 karakter olmalıdır.");

        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Aktivite tipi alanı boş bırakılamaz.")
            .IsInEnum().WithMessage("Aktivite tipi için geçerli değerler giriniz.");

        RuleFor(x => x.Date)
            .NotEqual(DateTime.MinValue).WithMessage("Geçerli bir tarih değeri giriniz");
 }
}
