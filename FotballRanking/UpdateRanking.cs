
namespace FotballRanking
{
    class UpdatedRanking
    {
        Team[] teams;
        public UpdatedRanking(Team[] teams)
        {
            this.teams = teams;
        }

        public void Score(Team first, Team second, int firstGoals, int secondGoals)
        {
            if (firstGoals > secondGoals)
            {
                first.AddPoints(3);
            }
            else if (firstGoals < secondGoals)
            {
                second.AddPoints(3);
            }
            else
            {
                first.AddPoints(1);
                second.AddPoints(1);
            }
        }
    }
}