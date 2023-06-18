namespace BattleshipLibrary
{
    public class PlayerInfo
    {
        public string Username { get; set; }
                
        // Points
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

        // Ships
        private List<GridSpotModel> shipLocations = new();
        
        public List<GridSpotModel> ShipLocations
		{
			get { return shipLocations; }
		}
		
        public void AddShipLocation(GridSpotModel spot)
		{
            spot.SetShip();
			shipLocations.Add(spot);
		}

        // Shots
        private List<GridSpotModel> shotsGrid = new();
        
        public List<GridSpotModel> ShotsGrid
		{
			get { return shotsGrid; }
		}
        
        public bool Shoot(PlayerInfo target, GridSpotModel coordinate)
        {
            foreach (var spot in target.ShipLocations)
            {
                if (
                    spot.SpotLetter == coordinate.SpotLetter
                    && spot.SpotNumber == coordinate.SpotNumber
                    && spot.Status != GridSpotModel.SpotStatus.hit
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
