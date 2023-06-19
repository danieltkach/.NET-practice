namespace BattleshipLibrary
{
    public class GridSpotModel
    {
        public enum SpotStatus { empty, ship, hit, miss };
		private SpotStatus status = SpotStatus.empty;
        public string SpotLetter { get; set; }
		public int SpotNumber { get; set; }
		
        public string GetCoordinate()
        {
            return SpotLetter.ToString() + SpotNumber.ToString();
        }

        public SpotStatus Status
		{
			get { return status; }
		}

		public void SetShip()
		{
			status = SpotStatus.ship;
		}

		public void SetHit()
		{
			status = SpotStatus.hit;
		}

		public void SetMiss()
		{
			status = SpotStatus.miss;
		}
	}
}