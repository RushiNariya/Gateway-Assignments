using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testing_Assignment_1.Models;
using Testing_Assignment_1.Repository;

namespace Testing_Assignment_1.Controllers
{
    public class PassengerController : ApiController
    {
        private readonly IDataRepository _dataRepository;
        public PassengerController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/User
        public IList<Passenger> Get()
        {
            return _dataRepository.getPassengersList();
        }

        // GET: api/User/5
        public IHttpActionResult Get(Guid id)
        {
            var obj = _dataRepository.GetById(id);
            return Ok(obj);
        }

        // POST: api/User
        public Passenger Post([FromBody] Passenger passenger)
        {
            return _dataRepository.AddPassenger(passenger);
        }

        // PUT: api/User/5
        public Passenger Put([FromBody] Passenger passenger)
        {
            return _dataRepository.Update(passenger);
        }

        // DELETE: api/User/5
        public bool Delete(Guid id)
        {
            var obj = _dataRepository.Delete(id);
            return obj;
        }
    }
}
