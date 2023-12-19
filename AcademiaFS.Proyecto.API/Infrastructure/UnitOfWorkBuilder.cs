using AcademiaFS.Proyecto.API.Infrastructure.SistemaViajes.Maps;
using Farsiman.Domain.Core.Standard.Repositories;
using Farsiman.Infraestructure.Core.Entity.Standard;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.API.Infrastructure
{
    public class UnitOfWorkBuilder
    {
        readonly IServiceProvider _serviceProvider;
        public UnitOfWorkBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;   
        }

        public IUnitOfWork BuilderSistemaViajes()
        {
            DbContext dbContext = _serviceProvider.GetService<SistemaViajesDBContext>() ?? throw new NullReferenceException();
            return new UnitOfWork(dbContext);
        }

    }
}
