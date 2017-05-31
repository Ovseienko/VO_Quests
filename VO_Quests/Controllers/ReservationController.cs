using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VO_Quests.Abstraction;
using VO_Quests.Models;
using VO_Quests.UI.ViewModels.Reserve;

namespace VO_Quests.Controllers
{
    public class ReservationController : BaseController
    {
        private UserManager<ApplicationUser> _userManager;
        public ReservationController(IUnitOfWork uow, UserManager<ApplicationUser> userManager) : base(uow)
        {
            _userManager = userManager;
        }
        
        public async Task<IActionResult> CreateNewReservation(NewReservationVM newReservation)
        {
            var user = await _userManager.GetUserAsync(User);

            var reservatingResult = _uow.Reservations.AddNewReservation(new Reservation()
            {
                SlotDate = newReservation.SlotDate,
                CreateDate = DateTimeOffset.Now,
                QuestId = newReservation.QuestId,
                UserId = user.Id
            });


            return View("Result", reservatingResult);
        }
    }
}
