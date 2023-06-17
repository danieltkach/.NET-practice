namespace BattleshipLibrary
{
    public class GridSpot
    {
        private string spotLetter;
		private int spotNumber;
        public enum SpotStatus { empty, hit, miss };
		private SpotStatus status = SpotStatus.empty;

        public string SpotLetter
		{
			set { spotLetter = value; }
		}

		public int SpotNumber
		{ 
			set { spotNumber = value; } 
		}

        public string GetCoordinate()
        {
            return spotLetter.ToString() + spotNumber.ToString();
        }

        public SpotStatus Status
		{
			get { return status; }
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