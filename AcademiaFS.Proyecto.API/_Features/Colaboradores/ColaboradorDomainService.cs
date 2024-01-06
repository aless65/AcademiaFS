using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Entities;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.API._Features.Colaboradores
{
    public class ColaboradorDomainService
    {
        public Respuesta<bool> ValidarColaborador(List<Colaboradore> colaboradores, ColaboradoreDto colaborador)
        {
            if(colaboradores.Any(x => x.Identidad == colaborador.Identidad))
                return Respuesta.Fault(Mensajes.REPETIDO("Colaborador"), Codigos.BadRequest, false);

            if (colaborador.SucursalesXcolaboradores.Select(g => g.IdSucursal).Count() !=
                    colaborador.SucursalesXcolaboradores.Select(g => g.IdSucursal).Distinct().Count())
                return Respuesta.Fault(Mensajes.REPETIR_SUCURSAL, Codigos.BadRequest, false);

            return Respuesta.Success(true);
        }
    }
}
