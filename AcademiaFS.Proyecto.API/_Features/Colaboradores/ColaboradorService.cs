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

        public List<Colaboradore> ListaColaboradores()
        {
            List<Colaboradore> Colaboradores = _unitOfWork.Repository<Colaboradore>()
                                                            .AsQueryable()
                                                            .Include(p => p.SucursalesXcolaboradores)
                                                            .ToList();


            return Colaboradores;
        }

        public Respuesta<object> InsertarColaboradores(Colaboradore colaboradores)
        {
            try
            {
                if (colaboradores.SucursalesXcolaboradores.Count() != colaboradores.SucursalesXcolaboradores.Where(x => x.DistanciaKm > 0 && x.DistanciaKm < 51).ToList().Count())
                    return Respuesta.Fault<object>("Todas las distancias deben ser mayor que 0 y menor que 50", "402");

                if (colaboradores.SucursalesXcolaboradores.Select(g => g.IdSucursal).Count() !=
                    colaboradores.SucursalesXcolaboradores.Select(g => g.IdSucursal).Distinct().Count())
                    return Respuesta.Fault<object>("No puede ingresar dos veces la misma sucursal");

                _unitOfWork.Repository<Colaboradore>().Add(colaboradores);

                foreach (var item in colaboradores.SucursalesXcolaboradores)
                {
                    item.IdColaborador = colaboradores.IdColaborador;
                }

                _unitOfWork.Repository<SucursalesXcolaboradore>().AddRange(colaboradores.SucursalesXcolaboradores);

                _unitOfWork.SaveChanges();

                return Respuesta.Success<object>("Muy bien", "Operación exitosa", "200");
            }
            catch
            {
                return Respuesta.Fault<object>("Intente más tarde", "500"); 
            }
}
    }
}
 