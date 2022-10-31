
namespace FotballRanking
{
    class UpdateRanking
    {
        Team[] teams;
        public UpdateRanking(Team[] teams)
        {
            this.teams = teams;
        }

        public void Score(Team first, Team second, int firstGoals, int secondGoals)
        {
            if (firstGoals > secondGoals)
            {
                first.AddPoints(first, 3);
            }
            else if (firstGoals < secondGoals)
            {
                second.AddPoints(second, 3);
            }
            else
            {
                first.AddPoints(first, 1);
                second.AddPoints(second, 1);
            }
        }
    }
}
