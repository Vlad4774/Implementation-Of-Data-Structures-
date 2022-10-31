
class Team
{
    private string nameOfTeam;
    private int points;
    public Team(string nameOfTeam, int points)
    {
        this.nameOfTeam = nameOfTeam;
        this.points = points;
    }

    public bool SwapTeams(Team that)
    {
        if (this.points < that.points)
        {
            return true;
        }

        return false;
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