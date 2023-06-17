namespace BattleshipLibrary
{
    public class PlayerInfo
    {
        public string Username { get; set; }
        private List<GridSpot> shipLocations = new();
		private List<GridSpot> shotsGrid = new();

		public List<GridSpot> ShipLocations
		{
			get { return shipLocations; }
		}

		public void AddShipLocation(GridSpot spot)
		{
			shipLocations.Add(spot);
		}

		public List<GridSpot> ShotsGrid
		{
			get { return shotsGrid; }
		}

        public bool Shoot(PlayerInfo player, GridSpot coordinate)
        {
            foreach (var spot in player.ShipLocations)
            {
                if (spot.SpotLetter == coordinate.SpotLetter
                    && spot.SpotNumber == coordinate.SpotNumber)
                {
                    spot.SetHit();
                    return true;
                }
                else
                {
                    spot.SetMiss();
                }
            }
            return false;
        }
    }
}
