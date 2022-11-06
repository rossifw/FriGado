using FriGado.API.Domain;
using System.Collections.Generic;

namespace FriGado.API.Repository
{
    public interface IAnimalRepository
    {
        public Animal GetAnimal(int id);
        public IEnumerable<Animal> ListAll();

        public int Add(Animal animal);
        public int Update(Animal animal);
        public int Remove(int id);
    }
}
