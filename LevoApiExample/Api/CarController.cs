using LevoApiExample.Models;
using System.Linq;
using System.Web.Http;
using System;

namespace LevoApiExample.Api
{
    //[Authorize]
    public class CarController : ApiController
    {
        private readonly ApplicationDbContext context;

        public CarController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/Car
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var listToReturn = this.context.Cars.ToList();
            if (listToReturn == null)
            {
                return NotFound();
            }

            return Ok(listToReturn);

        }

        // GET: api/Car/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var carToReturn = this.context.Cars.Where(c => c.Id == id).FirstOrDefault();
            if (carToReturn == null)
            {
                return NotFound();
            }
            return Ok(carToReturn);

        }

        // POST: api/Car/
        [HttpPost]
        public IHttpActionResult Add(Car car)
        {
            if (!ModelState.IsValid)
                return BadRequest("Wrong data");
            try
            {
                this.context.Cars.Add(car);
                this.context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        // PUT: api/Car/
        [HttpPut]
        public IHttpActionResult Update(Car car)
        {
            if (!ModelState.IsValid)
                return BadRequest("Wrong data");

            var carToUpdate = this.context.Cars.Where(c => c.Id == car.Id).FirstOrDefault();
            if (carToUpdate != null)
            {
                carToUpdate.Brand = car.Brand;
                carToUpdate.Model = car.Model;
                carToUpdate.YearOfProduction = car.YearOfProduction;

                this.context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        // DELETE: api/Car/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if(id <= 0)
            {
                return BadRequest($"{id} is not valid id");
            }
            var carToDelete = this.context.Cars.Where(c => c.Id == id).FirstOrDefault();
            if (carToDelete != null)
            {
                this.context.Cars.Remove(carToDelete);
                this.context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
