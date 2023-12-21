using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Common.Entities;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.Sucursales.Entities;
using AcademiaFS.Proyecto.API._Features.Transportistas.Entities;
using AcademiaFS.Proyecto.API._Features.Viajes.Dtos;
using AcademiaFS.Proyecto.API._Features.Viajes.Entities;
using AcademiaFS.Proyecto.API.Infrastructure;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace AcademiaFS.Proyecto.API.Domain
{
    public class DomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DomainService(UnitOfWorkBuilder unitOfWork)
        {
            _unitOfWork = unitOfWork.BuilderSistemaViajes();
        }

        public Respuesta<T> ValidacionCambiosBase<T>(Exception exception)
        {
            if (exception.Message.Contains("saving the entity changes"))
                return Respuesta.Fault<T>(Mensajes.DATOS_INCORRECTOS, Codigos.BadRequest);
            else
                return Respuesta.Fault<T>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
        }

        public bool SucursalExiste(int sucursal)
        {
            bool existe = _unitOfWork.Repository<Sucursale>().Where(x => x.IdSucursal == sucursal).Any();

            return existe;
        }

        public bool MunicipioExiste(int sucursal)
        {
            bool existe = _unitOfWork.Repository<Municipio>().Where(x => x.IdMunicipio == sucursal).Any();

            return existe;
        }

        public bool ColaboradorExiste(string identidad)
        {
            bool existe = _unitOfWork.Repository<Colaboradore>().Where(x => x.Identidad == identidad).Any();

            return existe;
        }
        public bool ColaboradorExisteId(int id)
        {
            bool existe = _unitOfWork.Repository<Colaboradore>().Where(x => x.IdColaborador == id).Any();

            return existe;
        }

        public bool TransportistaExiste(string identidad)
        {
            bool existe = _unitOfWork.Repository<Transportista>().Where(x => x.Identidad == identidad).Any();

            return existe;
        }

        public bool TransportistaExisteId(int IdTransportista)
        {
            bool existe = _unitOfWork.Repository<Transportista>().Where(x => x.IdTransportista == IdTransportista).Any();

            return existe;
        }
    }
}
