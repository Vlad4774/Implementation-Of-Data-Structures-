using FotballRanking;
using System.Collections.Generic;
using Xunit;

class Ranking
{
    Team[] teams;
    public Ranking()
    {
        this.teams = new Team[0];
    }

    public void Add(Team newTeam)
    {
        Array.Resize(ref teams, teams.Length + 1);
        teams[teams.Length - 1] = newTeam;
        SortRanking();
    }

    public void SortRanking()
    {
        for (int i = 0; i < teams.Length - 1; i++)
        {
            for (int j = i + 1; j < teams.Length; j++)
            {
                if (teams[i].SwapTeams(teams[j]))
                {
                    Team team = teams[i];
                    teams[i] = teams[j];
                    teams[j] = team;
                }
            }
        }
    }

    public void Match(int position1, int position2, int goals1, int goals2)
    {
        var updateRanking = new UpdateRanking(teams);
        updateRanking.Score(teams[position1 - 1], teams[position2 - 1], goals1, goals2);
        SortRanking();
    }

    public int PositionOf(Team newTeam)
    {
        for (int i = 0; i < teams.Length; i++)
        {
            if (teams[i] == newTeam)
            {
                return i + 1;
            }
        }

        return 0;
    }

    public Team TeamAtPosition(int position)
    {
        return teams[position - 1];
    }
}