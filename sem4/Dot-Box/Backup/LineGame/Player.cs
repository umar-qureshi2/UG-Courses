namespace LineGame
{
   public enum PlayerState { Busy, Available };
   public class Player
    {
        private static string PlayerName;
        private string _OpponentName;
        private int PlayerScore, _OpponentScore;
        private static bool Is_Server;
       
        private static PlayerState Player_State;
        public static string Name { get {return PlayerName;} set{PlayerName=value;}}
        public int Score{ get {return PlayerScore ;} set{PlayerScore=value;}}
        public string OpponentName { get { return _OpponentName; } set { _OpponentName = value; } }
        public int OpponentScore { get { return _OpponentScore; } set { _OpponentScore = value; } }
        public static PlayerState State{get {return Player_State;} set {Player_State=value;}}
        public static bool IsServer { get { return Is_Server; } set { Is_Server = value; } }

    }
}
