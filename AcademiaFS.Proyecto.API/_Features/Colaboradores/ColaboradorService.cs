using AcademiaFS.Proyecto.API._Common.Entities;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Dtos;
using AcademiaFS.Proyecto.API._Features.Colaboradores.Entities;
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
                                         NombreMunicipio = muni.Nombre
                                     });

            colaboradoresList.Include(p => p.SucursalesXcolaboradores).ToList();

            var colaboradoresMapeado = _mapper.Map<List<ColaboradoreListarDto>>(colaboradoresList);

            return Respuesta.Success(colaboradoresMapeado, "Todo bien", "200");
        }

        public Respuesta<ColaboradoreDto> InsertarColaboradores(ColaboradoreDto colaboradoresDto)
        {
            try
            {
                var colaboradores = _mapper.Map<Colaboradore>(colaboradoresDto);

                if (colaboradores.SucursalesXcolaboradores.Count() != colaboradores.SucursalesXcolaboradores.Where(x => x.DistanciaKm > 0 && x.DistanciaKm < 51).ToList().Count())
                    return Respuesta.Fault<ColaboradoreDto>("Todas las distancias deben ser mayor que 0 y menor que 50", "402");

                if (colaboradores.SucursalesXcolaboradores.Select(g => g.IdSucursal).Count() !=
                    colaboradores.SucursalesXcolaboradores.Select(g => g.IdSucursal).Distinct().Count())
                    return Respuesta.Fault<ColaboradoreDto>("No puede ingresar dos veces la misma sucursal");

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

                return Respuesta.Success(_mapper.Map<ColaboradoreDto>(colaboradores), "Operación exitosa", "200");
            }
            catch
            {
                return Respuesta.Fault<ColaboradoreDto>("Intente más tarde", "500"); 
            }
}
    }
}
 