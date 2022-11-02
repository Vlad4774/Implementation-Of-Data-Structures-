
 namespace FotballRanking
{
    public class RankingTest
    {
        [Fact]
        public void AddOneTeam()
        {
            var ranking = new Ranking();
            var newTeam = new Team("fcsb", 0);
            ranking.Add(newTeam);
            Assert.Equal(1, ranking.PositionOf(newTeam));
        }

        [Fact]
        public void AddMultipleTeamsButInDescedindOrderOfPoints()
        {
            var ranking = new Ranking();
            var newTeam = new Team("fcsb", 20);
            ranking.Add(newTeam);
            newTeam = new Team("Sepsi", 17);
            ranking.Add(newTeam);
            newTeam = new Team("Rapid", 15);
            ranking.Add(newTeam);
            Assert.Equal(3, ranking.PositionOf(newTeam));
        }

        [Fact]
        public void AddTwoTeamsButNotInOrderOfPoints()
        {
            var ranking = new Ranking();
            var newTeam = new Team("fcsb", 20);
            ranking.Add(newTeam);
            newTeam = new Team("Sepsi", 27);
            ranking.Add(newTeam);
            Assert.Equal(1, ranking.PositionOf(newTeam));
        }

        [Fact]
        public void AddMultipleTeamsButNotInOrderOfPoints()
        {
            var ranking = new Ranking();
            var newTeam = new Team("fcsb", 20);
            ranking.Add(newTeam);
            newTeam = new Team("Sepsi", 27);
            ranking.Add(newTeam);
            newTeam = new Team("Rapid", 25);
            ranking.Add(newTeam);
            Assert.Equal(2, ranking.PositionOf(newTeam));
        }
    }
}