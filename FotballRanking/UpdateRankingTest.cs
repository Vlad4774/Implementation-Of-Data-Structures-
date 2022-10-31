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
            var updateRanking = new UpdateRanking(teams);
            updateRanking.Score(teams[0], teams[1], 2, 3);
            ranking.SortRanking();
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
            var updateRanking = new UpdateRanking(teams);
            updateRanking.Score(teams[0], teams[2], 1, 3);
            ranking.SortRanking();
            Assert.Equal(2, ranking.PositionOf(newTeam));
        }
    }
}