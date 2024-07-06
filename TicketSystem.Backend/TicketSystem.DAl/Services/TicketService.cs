using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DAl.Services
{
    public static class TicketService
    {
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
