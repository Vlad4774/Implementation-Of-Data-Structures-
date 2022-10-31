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
}