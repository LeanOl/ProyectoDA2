using System;
using Data;
using Domain;

namespace Logic.ServicesFactory
{
	public class ServiceFactory
	{
		public ServiceFactory()
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

