namespace FotballRanking
{
    public class UpdateRankingTest
    {
        [Fact]
        public void SecondTeamWinsAgainstFirstTeam()
        {
            Team[] teams = new Team[0];
            var ranking = new Ranking();
            var newTeam = new Team("fcsb", 5);
            ranking.Add(newTeam);
            newTeam = new Team("sepsi", 3);
            ranking.Add(newTeam);
            ranking.Match(1, 2, 1, 3);
            Assert.Equal(1, ranking.PositionOf(newTeam));
        }

        [Fact]
        public void ThirdTeamWinsMatch()
        {
            Team[] teams = new Team[0];
            var ranking = new Ranking();
            var newTeam = new Team("fcsb", 17);
            ranking.Add(newTeam);
            newTeam = new Team("Sepsi", 18);
            ranking.Add(newTeam);
            newTeam = new Team("Rapid", 19);
            ranking.Add(newTeam);
            ranking.Match(1, 3, 1, 2);
            Assert.Equal(2, ranking.PositionOf(newTeam));
        }
    }
}