using System;
using System.Threading.Tasks;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;

        }

         public async Task<IAsyncResult> AddCarToClient(int userid, int id)
        {

            var user = await _clientRepository.GetClientsByIdAsync(userid);
               if (user == null)  throw new Exception("User doesn't exist");

               var car = await _clientRepository.GetCarById(id);
               if (car == null)  throw new Exception("Car doesn't exist");

                if(user.Cars.Count == 0)
                {
                car.isTaken = true;
                car.AppUserId = user.Id;
                _clientRepository.Update(car);
                

                if (await _clientRepository.SaveAllAsync()) return Task.CompletedTask;
                }
                

                throw new Exception("U have too much cars MAN!!");

        }


          public async Task<IAsyncResult> RemoveCarFromClient(int userid, int id)
        {

           var user = await _clientRepository.GetClientsByIdAsync(userid);
               if (user == null)  throw new Exception("User doesn't exist");

               var car = await _clientRepository.GetCarById(id);
               if (car == null)  throw new Exception("Car doesn't exist");

                if(user.Cars.Count != 0)
                {
                car.isTaken = false;
                car.AppUserId = 4;
                _clientRepository.Update(car);
                

                if (await _clientRepository.SaveAllAsync()) return Task.CompletedTask;
                }
                

                  throw new Exception("U have too much cars MAN!!");

        }
    }
}