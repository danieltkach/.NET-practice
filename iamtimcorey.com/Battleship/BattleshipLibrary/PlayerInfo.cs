namespace BattleshipLibrary
{
    public class PlayerInfo
    {
        public string Username { get; set; }
        private List<GridSpot> shipLocations = new();
        private List<GridSpot> shotsGrid = new();
        
        private int points = 0;
        public int Points {
            get
            {
                return points;
            }
            private set 
            {
                points = value;
            }
        }
        public void AddPoint()
        {
            points++;
        }
        
        public List<GridSpot> ShipLocations
		{
			get { return shipLocations; }
		}

		public void AddShipLocation(GridSpot spot)
		{
            spot.SetShip();
			shipLocations.Add(spot);
		}

		public List<GridSpot> ShotsGrid
		{
			get { return shotsGrid; }
		}

        public bool Shoot(PlayerInfo target, GridSpot coordinate)
        {
            foreach (var spot in target.ShipLocations)
            {
                if (
                    spot.SpotLetter == coordinate.SpotLetter
                    && spot.SpotNumber == coordinate.SpotNumber
                    && spot.Status != GridSpot.SpotStatus.hit
                    )
                {
                    spot.SetHit();
                    ShotsGrid.Add(spot);
                    return true;
                }
            }
            coordinate.SetMiss();
            ShotsGrid.Add(coordinate);
            return false;
        }
    }
}
