namespace FotballRanking
{
    public class UpdateRankingTest
    {
        [Fact]
        public void SecondTeamWinsAgainstFirstTeam()
        {
            var ranking = new Ranking();
            var homeTeam = new Team("fcsb", 5);
            ranking.Add(homeTeam);
            var awayTeam = new Team("sepsi", 3);
            ranking.Add(awayTeam);
            ranking.Match(homeTeam, awayTeam, 1, 3);
            Assert.Equal(1, ranking.PositionOf(awayTeam));
        }

        [Fact]
        public void ThirdTeamWinsMatch()
        {
            var ranking = new Ranking();
            var awayTeam = new Team("fcsb", 17);
            ranking.Add(awayTeam);
            var newTeam = new Team("Sepsi", 18);
            ranking.Add(newTeam);
            var homeTeam = new Team("Rapid", 19);
            ranking.Add(newTeam);
            ranking.Match(homeTeam, awayTeam, 1, 2);
            Assert.Equal(2, ranking.PositionOf(newTeam));
        }
    }
}