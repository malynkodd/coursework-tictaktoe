namespace Alien_Invaders
{

    public enum Result
    {
        Win, 
        Draw,
        Lose
    }
    public class GameResult
    {
        public int Rating;
        public Account Opponent;
        public Result Result;

        public GameResult(int rating,  Result result) {
            Rating = rating;
            Result = result;
        }
    }
}