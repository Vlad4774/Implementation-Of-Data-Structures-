
 namespace FotballRanking
{
    public class RankingTest
    {
        [Fact]
        public void AddOneTeam()
        {
            Team[] teams = new Team[0];
            var ranking = new Ranking(teams);
            var newTeam = new Team("fcsb", 0);
            ranking.Add(newTeam, ref teams);
            Assert.Equal(1, ranking.PositionOf(newTeam, teams));
        }

        [Fact]
        public void AddMultipleTeamsButInDescedindOrderOfPoints()
        {
            Team[] teams = new Team[0];
            var ranking = new Ranking(teams);
            var newTeam = new Team("fcsb", 20);
            ranking.Add(newTeam, ref teams);
            newTeam = new Team("Sepsi", 17);
            ranking.Add(newTeam, ref teams);
            newTeam = new Team("Rapid", 15);
            ranking.Add(newTeam, ref teams);
            Assert.Equal(3, ranking.PositionOf(newTeam, teams));
        }

        [Fact]
        public void AddTwoTeamsButNotInOrderOfPoints()
        {
            Team[] teams = new Team[0];
            var ranking = new Ranking(teams);
            var newTeam = new Team("fcsb", 20);
            ranking.Add(newTeam, ref teams);
            newTeam = new Team("Sepsi", 27);
            ranking.Add(newTeam, ref teams);
            Assert.Equal(1, ranking.PositionOf(newTeam, teams));
        }

        [Fact]
        public void AddMultipleTeamsButNotInOrderOfPoints()
        {
            Team[] teams = new Team[0];
            var ranking = new Ranking(teams);
            var newTeam = new Team("fcsb", 20);
            ranking.Add(newTeam, ref teams);
            newTeam = new Team("Sepsi", 27);
            ranking.Add(newTeam, ref teams);
            newTeam = new Team("Rapid", 25);
            ranking.Add(newTeam, ref teams);
            Assert.Equal(2, ranking.PositionOf(newTeam, teams));
        }
    }
}