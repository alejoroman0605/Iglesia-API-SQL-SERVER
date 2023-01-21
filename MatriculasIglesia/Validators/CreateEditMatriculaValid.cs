
using FluentValidation;
using Library.Data.Interfaces;
using Library.Repository.Interfaces;
using MatriculasIglesia.Dtos.Matriculas;

namespace Trabajadores_API.Validators
{
    public class CreateEditMatriculaValid : AbstractValidator<CreateEditMatriculaDto>
    {
        private IUnitOfWork _repositorios;
        public CreateEditMatriculaValid(IUnitOfWork repositorios)
        {
            _repositorios = repositorios;

            RuleFor(dto => dto)
                .Must((entity, value, token) => AnyMatriculadoAsync(entity.ProyectoID, entity.NinoID, entity.Id).Result)
                .WithMessage("Ese niño está matriculado en ese proyecto");


        }

        public async Task<bool> AnyMatriculadoAsync(int ProyectoID, int NinoID, int Id)
        {
            return ! await _repositorios.Matriculas.AnyMatriculadoAsync(ProyectoID, NinoID, Id);
        }

    }
}
