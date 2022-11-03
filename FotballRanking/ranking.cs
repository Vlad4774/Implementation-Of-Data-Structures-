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

    void SortRanking()
    {
        for (int step = 1; step < teams.Length; step++)
        {
            for (int j = step; j >= 1; j--)
            {
                if (teams[j].HasMorePoints(teams[j - 1]))
                {
                    Team aux = teams[j - 1];
                    teams[j - 1] = teams[j];
                    teams[j] = aux;
                }
            }
        }
    }

    public void Match(Team first, Team second, int firstGoals, int secondGoals)
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