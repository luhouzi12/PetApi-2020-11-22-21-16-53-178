﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace PetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetStoreController : Controller
    {
        private static IList<Pet> pets = new List<Pet>();
        [HttpPost("addNewPet")]
        public Pet AddPet(Pet pet)
        {
            pets.Add(pet);
            return pet;
        }

        [HttpGet("pets")]
        public IEnumerable<Pet> GetAllPets()
        {
            return pets;
        }

        [HttpGet("petname/{name}")]
        public Pet GetPetByName(string name)
        {
            var pet = pets.Where(pet => pet.Name == name).ToList()[0];
            return pet;
        }

        [HttpPatch("{updateModel.name}")]
        public Pet UpdatePriceByName(UpdatePriceModel updateModel)
        {
            pets.Where(pet => pet.Name == updateModel.Name).ToList()[0].Price = updateModel.Price;
            return pets.Where(pet => pet.Name == updateModel.Name).ToList()[0];
        }

        [HttpDelete("petname/{name}")]
        public void DeletePetsByName(string name)
        {
            pets.Remove(pets.Where(deletepet => deletepet.Name == name).ToList()[0]);
        }

        [HttpDelete("clear")]
        public void Clear()
        {
            pets.Clear();
        }
    }
}
