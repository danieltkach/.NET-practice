namespace GuestBook
{
    public class Guest
    {
        public string Name { get; set; }
        public int MembersCount { get; set; }
    }

    public class GuestBook
    {
        private List<Guest> guests = new List<Guest>();

        public void RegisterGuest(Guest guest)
        {
            guests.Add(guest);
        }

        public int GetTotalGuestCount()
        {
            int totalGuestsCount = 0;
            foreach (var guest in guests)
            {
                totalGuestsCount += guest.MembersCount;
            }
            return totalGuestsCount;
        }

        public IEnumerable<Guest> GetGuests()
        {
            return guests;
        }
    }
}
