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
        private List<GridModel> shipLocations = new();
        
        public List<GridModel> ShipLocations
		{
			get { return shipLocations; }
		}
		
        public void AddShipLocation(GridModel spot)
		{
            spot.SetShip();
			shipLocations.Add(spot);
		}

        // Shots
        private List<GridModel> shotsGrid = new();
        
        public List<GridModel> ShotsGrid
		{
			get { return shotsGrid; }
		}
        
        public bool Shoot(PlayerInfo target, GridModel coordinate)
        {
            foreach (var spot in target.ShipLocations)
            {
                if (
                    spot.SpotLetter == coordinate.SpotLetter
                    && spot.SpotNumber == coordinate.SpotNumber
                    && spot.Status != GridModel.SpotStatus.hit
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
