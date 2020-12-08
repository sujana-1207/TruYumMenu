using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuItemsService.Models;
using MenuItemsService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuItemsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(MenuItemController));
        private readonly IMenu _menurepo;
        // GET: api/MenuItem
        public MenuItemController(IMenu repository)
        {

            _menurepo = repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _log4net.Info("Http Get request Initiated");

                var menuitems = _menurepo.GetMenuItems();
                if (menuitems != null)
                {
                    _log4net.Info("successfully got details");
                    return Ok(menuitems);
                }
                _log4net.Info("Menu Items Requested but none were found");
                return new NoContentResult();
            }
            catch
            {
                _log4net.Error("Bad Request");
                return new BadRequestResult();
            }
        }

        // POST: api/MenuItem
        [HttpPost]
        public IActionResult Post([FromBody] MenuItem value)
        {
            try
            {
                _log4net.Info("HttpPost Request Initiated for Id " + value.Id);

                if (ModelState.IsValid)
                {
                    _log4net.Info("Model state is  valid for Id " + value.Id);


                    _menurepo.AddMenuItem(value);


                    return new  OkResult();

                }
                _log4net.Error("Model state is not valid for id " + value.Id);
                return NotFound();

            }
            catch
            {
                return BadRequest();
            }
            
        }

        // PUT: api/MenuItem/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MenuItem value)
        {
            try
            {
                _log4net.Info("Udate Request Initiated for Id " + value.Id);

                if (ModelState.IsValid)
                {
                    _log4net.Info("Model state is  valid for Id " + value.Id);


                    var updateMenuitem = _menurepo.UpdateMenuItem(value);

                    if (updateMenuitem != null)
                    {
                        return Ok(updateMenuitem);
                    }


                    return BadRequest();

                }
                _log4net.Error("Model state is not valid for id " + value.Id);
                return NotFound();

            }
            catch
            {
                return BadRequest();
            }

        }

    }
}
