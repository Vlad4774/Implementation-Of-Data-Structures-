
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

    public Team AddPoints(Team team, int points)
    {
        team.points += points;
        return team;
    }
}