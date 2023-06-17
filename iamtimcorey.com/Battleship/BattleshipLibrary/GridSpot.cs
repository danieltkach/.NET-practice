namespace BattleshipLibrary
{
    public class GridSpot
    {
		private string spotLetter;
		private int spotNumber;
		private string status;

		public string SpotLetter
		{
			get { return spotLetter; }
			set { spotLetter = value; }
		}

		public int SpotNumber
		{ 
			get { return spotNumber; }
			set { spotNumber = value; } 
		}

		public string Status
		{
			get { return status; }
			set { status = value; }
		}
	}
}