
class Team
{
    private string nameOfTeam;
    private int points;
    public Team(string nameOfTeam, int points)
    {
        this.nameOfTeam = nameOfTeam;
        this.points = points;
    }

    public void SwapTeams(ref Team first, ref Team second)
    {
        if (first.points < second.points)
        {
            Team team = first;
            first = second;
            second = team;
        }
    }

    public string Raport(Team team)
    {
        return team.nameOfTeam.ToString() + " " + team.points.ToString();
    }
}

class Ranking
{
    Team[] teams;
    public Ranking(Team[] teams)
    {
        this.teams = teams;
    }

    public void Add(Team newTeam, ref Team[] teams)
    {
        Array.Resize(ref teams, teams.Length + 1);
        teams[teams.Length - 1] = newTeam;
        SortRanking(ref teams);
    }

    public void SortRanking(ref Team[] teams)
    {
        for (int i = 1; i < teams.Length; i++)
        {
            teams[i - 1].SwapTeams(ref teams[i - 1], ref teams[i]);
        }
    }

    public int PositionOf(Team newTeam, Team[] teams)
    {
        for (int i = 0; i < teams.Length; i++)
        {
            if(teams[i] == newTeam)
            {
                return i + 1;
            }
        }

        return 0;
    }
}