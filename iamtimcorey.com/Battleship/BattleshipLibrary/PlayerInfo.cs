namespace BattleshipLibrary
{
    public class PlayerInfo
    {
        public string Username { get; set; }
        public int Points { get; private set; } = 0;
       
        public void AddPoint()
        {
            Points++;
        }

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

        public List<GridSpotModel> ShotsGrid { get; } = new();
        
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
