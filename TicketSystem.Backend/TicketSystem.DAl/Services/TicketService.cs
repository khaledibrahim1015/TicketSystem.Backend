using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DAl.Services
{
    /// <summary>
    /// Static class for ticket-related utilities.
    /// </summary>
    public static class TicketService

    {     /// <summary>
          /// Determines the color status of a ticket based on its creation date.
          /// </summary>
          /// <param name="creationDate">The creation date of the ticket.</param>
          /// <returns>The color status string.</returns>
        public static string GetTicketColor(DateTime creationDate)
        {
            var ageInMinutes = (DateTime.UtcNow - creationDate).TotalMinutes;

            if (ageInMinutes <= 15)
                return "yellow";
            else if (ageInMinutes <= 30)
                return "green";
            else if (ageInMinutes <= 45)
                return "blue";
            else
                return "red";
        }

    }
}
