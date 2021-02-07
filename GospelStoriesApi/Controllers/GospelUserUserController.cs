using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GospelStoriesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GospelStoriesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GospelUserController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<GospelUser> Get()
        {
            using(var context = new GospelStoryDBContext())
            {
                //get all users
                return context.GospelUser.ToList();
            }
        }
    }
}
