namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.Services;
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Linq;

    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext db;

        public TripsController(
            IValidator validator,
            ApplicationDbContext db)
        {
            this.validator = validator;
            this.db = db;
        }

        public HttpResponse All()
        {
            var tripsQuery = this.db
                .Trips
                .AsQueryable();

            var trips = tripsQuery
                .Select(t => new ListingViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime,
                    Seats = t.Seats,
                    Description = t.Description
                }).ToList();

            return View(trips);
        }

        public HttpResponse Add() => View();

        [HttpPost]
        public HttpResponse Add(AddViewModel model)
        {
            var errors = this.validator.ValidateTrip(model).ToList();

            if (errors.Any())
            {
                //return Error(errors);
                return Redirect("/Trips/Add");
            }

            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = DateTime.Parse(model.DepartureTime),
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                Description = model.Description
            };

            db.Trips.Add(trip);
            db.SaveChanges();

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var tripsQuery = this.db
                .Trips
                .AsQueryable();

            var trip = tripsQuery
                .Select(t => new AddViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    ImagePath = t.ImagePath,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH: mm"),
                    Seats = t.Seats,
                    Description = t.Description
                })
                .Where(x => x.Id == tripId)
                .FirstOrDefault();

            if (trip == null)
            {
                return Redirect("/Trips/Details");
            }

            return View(trip);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var currentTrip = db.Trips.Where(x => x.Id == tripId).FirstOrDefault();

            var user = db.Users.Where(x => x.Id == this.User.Id).FirstOrDefault();

            if (currentTrip == null || user == null)
            {
                return Redirect("Trips/Details"); //??
            }

            var userTrip = new UserTrip
            {
                Trip = currentTrip,
                User = user
            };
            
            if (db.UserTrips.Where(x => x.UserId == user.Id && x.Trip.Id == currentTrip.Id).Any())
            {
                return Redirect($"/Trips/Details?tripId={currentTrip.Id}");
            }

            currentTrip.UserTrips.Add(userTrip);
            user.UserTrips.Add(userTrip);

            db.UserTrips.Add(userTrip);
            db.SaveChanges();

            return Redirect("/Trips/All");
        }
    }
}
