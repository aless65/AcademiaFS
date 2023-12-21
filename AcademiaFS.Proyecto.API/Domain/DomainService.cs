using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Features.Viajes.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.API.Domain
{
    public class DomainService
    {
        public Respuesta<T> ValidacionCambiosBase<T>(Exception exception)
        {
            if (exception.Message.Contains("saving the entity changes"))
                return Respuesta.Fault<T>(Mensajes.DATOS_INCORRECTOS, Codigos.BadRequest);
            else
                return Respuesta.Fault<T>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
        }
    }
}
