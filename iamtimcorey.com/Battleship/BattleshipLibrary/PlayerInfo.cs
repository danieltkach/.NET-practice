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

		public void AddShot(GridSpot spot)
		{
			shotsGrid.Add(spot);
		}
	}
}
