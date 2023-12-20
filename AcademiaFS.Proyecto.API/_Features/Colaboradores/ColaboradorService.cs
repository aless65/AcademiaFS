using AcademiaFS.Proyecto.API._Common;
using AcademiaFS.Proyecto.API._Common.Entities;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
using AcademiaFS.Proyecto.API._Features.Sucursales.Entities;
using AcademiaFS.Proyecto.API.Infrastructure;
using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using Microsoft.EntityFrameworkCore;

//using Farsiman.Application.Core.Standard.DTOs;
using Microsoft.OpenApi.Any;
using System;

namespace AcademiaFS.Proyecto.API._Features.Colaboradores
{
    public class ColaboradorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ColaboradorService(UnitOfWorkBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderSistemaViajes();
            _mapper = mapper;
        }

        public Respuesta<List<ColaboradoreListarDto>> ListaColaboradores()
        {
            var colaboradoresList = (from colaboradores in _unitOfWork.Repository<Colaboradore>().AsQueryable()
                                     join muni in _unitOfWork.Repository<Municipio>().AsQueryable()
                                     on colaboradores.IdMunicipio equals muni.IdMunicipio
                                     select new ColaboradoreListarDto
                                     {
                                         IdColaborador = colaboradores.IdColaborador,
                                         Nombres = colaboradores.Nombres,
                                         Apellidos = colaboradores.Apellidos,
                                         Identidad = colaboradores.Identidad,
                                         FechaNacimiento = colaboradores.FechaNacimiento,
                                         Sexo = colaboradores.Sexo,
                                         IdMunicipio = colaboradores.IdMunicipio,
                                         Direccion = colaboradores.Direccion,
                                         NombreMunicipio = muni.Nombre,
                                         SucursalesXcolaboradores = (from detalles in colaboradores.SucursalesXcolaboradores.AsQueryable()
                                                                     join colab in _unitOfWork.Repository<Colaboradore>().AsQueryable()
                                                                     on detalles.IdColaborador equals colab.IdColaborador
                                                                     join sucu in _unitOfWork.Repository<Sucursale>().AsQueryable()
                                                                     on detalles.IdSucursal equals sucu.IdSucursal
                                                                     select new SucursalesXcolaboradoreListarDto
                                                                     {
                                                                         IdSucursalXcolaborador = detalles.IdSucursalXcolaborador,
                                                                         IdSucursal = sucu.IdSucursal,
                                                                         NombreSucursal = sucu.Nombre,
                                                                         IdColaborador = colab.IdColaborador,
                                                                         NombreColaborador = $"{colab.Nombres} {colab.Apellidos}",
                                                                         DistanciaKm = detalles.DistanciaKm
                                                                     }).ToList()
                                     }).ToList();


            return Respuesta.Success(colaboradoresList, Mensajes.PROCESO_EXITOSO, Codigos.Error);
        }

        public Respuesta<ColaboradoreDto> InsertarColaboradores(ColaboradoreDto colaboradoresDto)
        {
            try
            {
                var colaboradores = _mapper.Map<Colaboradore>(colaboradoresDto);

                if(ColaboradorExiste(colaboradores.Identidad))
                    return Respuesta.Fault<ColaboradoreDto>("El colaborador ya existe", Codigos.BadRequest);

                if (colaboradores.SucursalesXcolaboradores.Count() != colaboradores.SucursalesXcolaboradores.Where(x => x.DistanciaKm > 0 && x.DistanciaKm < 51).ToList().Count())
                    return Respuesta.Fault<ColaboradoreDto>("Todas las distancias deben ser mayor que 0 y menor o igual que 50", Codigos.BadRequest);

                if (colaboradores.SucursalesXcolaboradores.Select(g => g.IdSucursal).Count() !=
                    colaboradores.SucursalesXcolaboradores.Select(g => g.IdSucursal).Distinct().Count())
                    return Respuesta.Fault<ColaboradoreDto>("No puede ingresar dos veces la misma sucursal", Codigos.BadRequest);

                //Solución temporal XD
                colaboradores.UsuaCreacion = 1;

                colaboradores.FechaCreacion = DateTime.Now;

                foreach (var item in colaboradores.SucursalesXcolaboradores)
                {
                    item.FechaCreacion = colaboradores.FechaCreacion;
                    item.UsuaCreacion = colaboradores.UsuaCreacion;
                }

                _unitOfWork.Repository<Colaboradore>().Add(colaboradores);

                _unitOfWork.SaveChanges();

                return Respuesta.Success(_mapper.Map<ColaboradoreDto>(colaboradores), Mensajes.PROCESO_EXITOSO, Codigos.Error);
            }
            catch(Exception ex) 
            {
                if (ex.Message.Contains("saving the entity changes"))
                    return Respuesta.Fault<ColaboradoreDto>(Mensajes.DATOS_INCORRECTOS, Codigos.BadRequest);
                else
                    return Respuesta.Fault<ColaboradoreDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error); 
            }
        }

        private bool ColaboradorExiste(string identidad)
        {
            bool existe = _unitOfWork.Repository<Colaboradore>().Where(x => x.Identidad == identidad).Any();

            return existe;
        }
    }
}
 