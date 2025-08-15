using ProvaPub.Models;
using ProvaPub.Repository.Interfaces;

namespace ProvaPub.Services
{
	public class RandomService
	{
        INumberRepository _numberRepository;
        int limitRandomNumbers = 10000;

        public RandomService(INumberRepository numberRepository)
        {
            _numberRepository = numberRepository;            
        }

        public async Task<int> GetRandom()
		{
            var number = GenerateRandomNumber();            

            if(_numberRepository.CountNumbers() >= limitRandomNumbers)
            {
                throw new Exception("Não há mais números aleatórios possíveis para serem gerados.");
            }

            while (_numberRepository.NumberExists(number))
            {
                number = GenerateRandomNumber();
            }

            _numberRepository.Add(new RandomNumber() { Number = number });

            return number;
        }

        private int GenerateRandomNumber()
        {
            int seed = Guid.NewGuid().GetHashCode();
            var number = new Random(seed).Next(limitRandomNumbers);            
            return number;
        }

	}
}
