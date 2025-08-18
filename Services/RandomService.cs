using Microsoft.EntityFrameworkCore;
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

            if (await _numberRepository.Query().CountAsync() >= limitRandomNumbers)
            {
                throw new InvalidOperationException("There are no more possible random numbers to be generated.");
            }

            while (await _numberRepository.Query().AnyAsync(x => x.Number == number))
            {
                number = GenerateRandomNumber();
            }

            await _numberRepository.AddAsync(new RandomNumber() { Number = number });

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
