using System.Collections.Generic;

namespace Data.Factory
{
    public interface IFactory
    {
        bool Success { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }

        void CreateCharacter(List<string> characterize, string gender);
        List<string> GetEnumList<T>(T t);
    }
}
