using Microsoft.AspNetCore.Mvc;

namespace web_library.Reservation.Controller
{
    using DataProvider;
    using Request;
    using Service;
    using Model;

    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IReservationDataProvider _reservationDataProvider;

        public ReservationController(IReservationService reservationService, IReservationDataProvider reservationDataProvider)
        {
            _reservationService = reservationService;
            _reservationDataProvider = reservationDataProvider;
        }

        // GET: HomeController
        [HttpGet]
        public ActionResult<IEnumerable<ReservationModel>> Index()
        {
            return Ok(_reservationDataProvider.GetAll());
        }
        // POST: HomeController/Create
        [HttpPost]
        public ActionResult Create([FromBody] CreateReservationRequest request)
        {
            _reservationService.createReservation(request);
            return Ok();
        }
    }
}
