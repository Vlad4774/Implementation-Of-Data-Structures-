
class Team
{
    private string nameOfTeam;
    private int points;
    public Team(string nameOfTeam, int points)
    {
        this.nameOfTeam = nameOfTeam;
        this.points = points;
    }

    public bool HasMorePoints(Team that)
    {
        return this.points > that.points;
    }

    public void AddPoints(int points)
    {
        this.points += points;
    }
}