using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Maintenance.Domain;
using Maintenance.Data;
using ShoppingCart.Interfaces;
using Newtonsoft.Json;

namespace MvcSalesApp.Web.Maintenance.Controller
{
    public class MainController : Microsoft.AspNetCore.Mvc.Controller
    {
        IGenericRepository<Customer> _repo;
        IOrderingService _orderingService;
        public MainController(IGenericRepository<Customer> repo, IOrderingService orderingService)
        {
            this._repo = repo;
            this._orderingService = orderingService;
        }


        // [HttpPost]
        // [Route("heroes/register")]
        // public ICommandResult Post([FromBody] RegisterHeroesCommand command)
        // {
        //     return _handler.Handle(command);
        // }
        
        [HttpGet]
        [Route("main")]
        public string Get()
        {
            // var repo = new GenericRepository<Customer>(new AppDbContext()); 

            // return _repo.All().FirstOrDefault().FirstName;
            return JsonConvert.SerializeObject(_orderingService.GetProductList().FirstOrDefault());
        }

        // [HttpGet]
        // [Route("heroes/{Id}")]
        // public GetHeroQueryResult Get(string Id)
        // {
        //     return _handler.Get(Id);
        // }

        // [HttpPut]
        // [Route("heroes/update")] 
        // public ICommandResult Put([FromBody] UpdateHeroesCommand command)
        // {
        //     return _handler.Handle(command);
        // }

        // [HttpDelete]
        // [Route("heroes/{Id}")]
        // public ICommandResult Delete(string Id)
        // {
        //     DeleteHeroCommand command = new DeleteHeroCommand(Id);
        //     return _handler.Handle(command);
        // }
    }
}