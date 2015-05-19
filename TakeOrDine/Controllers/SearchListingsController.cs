using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TakeOrDine.Models.DB;

namespace TakeOrDine.Controllers
{
    public class SearchListingsController : ApiController
    {
        private TakeOrDineDbContext db = new TakeOrDineDbContext();

        // GET: api/SearchListings
        public List<ManageListing> Get(string zipCode)
        {
            // We only want to show listing that are still available.
            // TODO: How do we handle timeZone issue?
            var listingOfInterest = db.ManageListings
                .Where(l =>  DbFunctions.DiffHours(DateTime.Now, l.DateOfAvailability).Value > l.DeadlineOffsetInHrs);

            var finalListings = db.Hosts.Where(host => host.Zipcode == zipCode)
                .Join(listingOfInterest, r => r.HostId, s => s.HostId, (host, listing) => new { listing })
                .Select(r => r.listing)
                .ToList();

            return finalListings.ToList();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ManageListingExists(int id)
        {
            return db.ManageListings.Count(e => e.ListingId == id) > 0;
        }
    }
}