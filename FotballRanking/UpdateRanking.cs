
namespace FotballRanking
{
    class UpdateRanking
    {
        Team team;
        private int goals;
        public UpdateRanking(Team team, int goals)
        {
            this.team = team;
            this.goals = goals;
        }

        public void Update(UpdateRanking first, UpdateRanking second)
        {
            if (first.goals > second.goals)
            {
                first.team.AddPoints(team, 3);
            }
            else if (first.goals < second.goals)
            {
                second.team.AddPoints(team, 3);
            }
            else
            {
                first.team.AddPoints(team, 1);
                second.team.AddPoints(team, 1);
            }
        }
    }
}
