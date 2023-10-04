using System;
using System.Collections.Generic;
using Domain;

namespace Data.Interfaces
{
	public interface IUserManagment
	{
		
            IEnumerable<User> GetCharacters();
            User GetCharacterById(int id);
            void InsertCharacter(User? character);
            User? UpdateCharacter(User? character);
            void DeleteCharacter(int id);
        
	}
}

