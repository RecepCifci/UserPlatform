using FluentValidation;
using UserPlatform.Application.Dtos;

namespace UserPlatform.Application.Validators;

public class UserValidator : AbstractValidator<UserDto>
{
    public UserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("İsim alanı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("İsim alanı en fazla 100 karakter olmalıdır.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email alanı boş bırakılamaz.")
            .EmailAddress().WithMessage("Email alanı için geçerli değerler giriniz.");

        RuleFor(x => x.Password)
             .NotEmpty().WithMessage("Şifre alanı boş bırakılamaz.")
             .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalı.")
                    .MaximumLength(16).WithMessage("Şifre uzunluğunuz 16'yı geçmemelidir.")
                    .Matches(@"[A-Z]+").WithMessage("Şifreniz en az bir büyük harf içermelidir.")
                    .Matches(@"[a-z]+").WithMessage("Şifreniz en az bir küçük harf içermelidir.")
                    .Matches(@"[0-9]+").WithMessage("Şifreniz en az bir rakam içermelidir.")
                    .Matches(@"[\!\?\*\.]+").WithMessage("Şifreniz en az bir (!? *.) içermelidir.");

        RuleFor(x => x.JoinDate)
            .NotEqual(DateTime.MinValue).WithMessage("Geçerli bir tarih değeri giriniz");
    }
}
