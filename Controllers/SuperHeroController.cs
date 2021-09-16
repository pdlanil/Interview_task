
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Persistence;
using TaskApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using QuickApp.RealTime;

namespace TaskApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuperHeroController : ControllerBase
    {
        private readonly ILogger<SuperHeroController> _logger;
        private readonly ApplicationDbContext _context;
        IHubContext<NotificationHub> _hub;
        public SuperHeroController(ILogger<SuperHeroController> logger, ApplicationDbContext context, IHubContext<NotificationHub> hub)
        {
            _logger = logger;
            _context = context;
            _hub = hub;
        }




        [HttpGet]
        [Route("getAllHeros")]
        public async Task<IActionResult> GetAllHeros()
        {
            var heroQuery = (await _context.Heros.Where(x => x.GroupName == Group.Avenger).Select(x => new HeroViewModel
            {
                FullName = x.FullName,
                Age = x.Age,
                GroupName = x.GroupName
            })
                .ToListAsync())
                .Select(x =>
                {
                    x.HeroGroupName = Enum.GetName(typeof(Group), x.GroupName);
                    return x;
                })
                .ToList();

            return Ok(heroQuery);
        }

        [Authorize(AuthenticationSchemes = "BasicAuthentication")]
        [HttpPost]
        [Route("newHero")]
        public async Task<IActionResult> AddNewHero([FromBody] HeroViewModel heroVm)
        {
           
            Hero hero = new Hero
            {
                Age = heroVm.Age,
                GroupName = heroVm.GroupName,
                FullName = heroVm.FullName,
            };
            try
            {
                _context.Heros.Add(hero);
                if (heroVm.GroupName == Group.Avenger)
                    await _hub.Clients.All.SendAsync("ReceiveMessage", $"{heroVm.FullName}");
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return new StatusCodeResult(StatusCodes.Status200OK);

        }

        [Route("getGroupType")]
        [HttpGet]
        public IActionResult GroupType()
        {
            List<dynamic> result = new List<dynamic>();
            foreach (Group item in Enum.GetValues(typeof(Group)))
            {
                result.Add(new { group_id = item, group_Name = item.ToString() });
            }
            return Ok(result);
        }


    }



}
