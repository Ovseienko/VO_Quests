using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VO_Quests.Abstraction;

namespace VO_Quests.Controllers
{
    public class BaseController : Controller
    {
        public IUnitOfWork _uow { get; set; }
        public BaseController(IUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
