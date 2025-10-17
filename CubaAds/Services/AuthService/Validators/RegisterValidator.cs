using FluentValidation;
using FastEndpoints;
using CubaAds.Endpoints.AuthEndpoint.DTOs.Requests.UserRequests;


namespace CubaAds.Services.AuthService.Validators
{
    public class RegisterValidator : Validator<RegistUserRequest>
    {

        //fastendpoint detecta esta validacion automaticamente antes de ejecutar HandleAsync
        public RegisterValidator() 
        {
            RuleFor(x => x.email)
                .NotEmpty()
                .WithMessage("El email es requerido")
                .EmailAddress()
                .WithMessage("Formato de email no valido");

            RuleFor(x => x.password)
                .NotEmpty()
                .WithMessage("Se requiere una contraseña")
                .MinimumLength(8)
                .WithMessage("La contraseña debe tener al menos 8 caracteres");

            RuleFor(x => x.rol.ToString())
                .Must(r => r == "Admin" || r == "Anunciante" || r == "App")
                .WithMessage("Rol invalido debe ser Admin, Anunciante o App");
        }

    }
}
