using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VO_Quests.Abstraction;
using VO_Quests.UI.ViewModels;

namespace VO_Quests.Controllers
{
    public class QuestController : BaseController
    {
        public QuestController(IUnitOfWork uow) : base(uow)
        {

        }

        public IActionResult List()
        {
            var quest = _uow.Quests.GetAllQuests();

            return View(quest);
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var quest = _uow.Quests.GetById(id);

            var questSlots = _uow.Reservations.GetQuestSlots(id);


            var model = new QuestDetailsVM()
            {
                QuestId = quest.Id,
                QuestName = quest.QuestName,
                PosterPath = quest.PosterPath,
                Slots = questSlots
            };

            return View(model);
        }
    }
}
