using System;
using Data;
using Data.Interfaces;
using Data.Concrete;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

            // Lo hago scoped ya que este manager maneja estado, tiene el currentUser
            //serviceCollection.AddScoped<ISessionService, SessionService>();
            //serviceCollection.AddScoped<ICharacterService, CharacterService>();
        }
    }
}

