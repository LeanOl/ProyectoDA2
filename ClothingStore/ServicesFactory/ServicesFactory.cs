using IData;
using Data.Concrete;
using Domain;
using Logic.Concrete;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Data;


namespace ServicesFactory
{
	public class ServicesFactory
	{
		public ServicesFactory()
		{
		}

        public void RegistrateServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<DbContext, ClothingStoreContext>();
            serviceCollection.AddScoped<IGenericRepository<User>, UserManagement>();
            serviceCollection.AddScoped<IGenericRepository<Promotion>,PromotionManagement>();
            serviceCollection.AddScoped<IGenericRepository<Session>, SessionManagement>();
            serviceCollection.AddScoped<IGenericRepository<Product>, ProductManagement>();
            serviceCollection.AddScoped<IPromotionLogic, PromotionLogic>();
            serviceCollection.AddScoped<IUserLogic, UserLogic>();
            serviceCollection.AddScoped<ISessionService, SessionService>();
            serviceCollection.AddScoped<IProductLogic, ProductLogic>();
            serviceCollection.AddScoped<IProductManagement, ProductManagement>();
            
        }
    }
}

