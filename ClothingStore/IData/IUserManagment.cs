using Domain;

namespace IData
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

