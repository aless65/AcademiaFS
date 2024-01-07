using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API.Infrastructure;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Academia.Proyecto.API._Common
{
    public class CommonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommonService(UnitOfWorkBuilder unitOfWork)
        {
            _unitOfWork = unitOfWork.BuilderSistemaViajes();
        }

        public Respuesta<T> RespuestasCatch<T>(DbUpdateException ex, string objeto)
        {
            var innerException = ex.InnerException;

            if (innerException is SqlException sqlException)
            {

                //_unitOfWork.Repository<ErroresDb>()
                //.Add(new ErroresDb
                //{
                //    FechaYHora = DateTime.Now,
                //    Codigo = sqlException.Number.ToString(),
                //    Mensaje = sqlException.Message,
                //});

                //_unitOfWork.SaveChanges();

                if (sqlException.Number == 2601 || sqlException.Number == 2627)
                    return Respuesta.Fault<T>(Codigos.Error, Mensajes.REPETIDO(objeto));
                else if (sqlException.Number == 547)
                    return Respuesta.Fault<T>(Codigos.Error, Mensajes.LLAVE_FORANEA);
            }

            return Respuesta.Fault<T>(Codigos.Error, Mensajes.PROCESO_FALLIDO);
        }
    }
}
