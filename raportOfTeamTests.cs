namespace FotballRanking
{
    public class RaportTest
    {
        [Fact]
        public void AddOneTeam()
        {
            Team[] teams = new Team[0];
            var ranking = new Ranking(teams);
            var newTeam = new Team("fcsb", 0);
            ranking.Add(newTeam, ref teams);
            var raport = new RaportOfTeam(teams);
            Assert.Equal("fcsb 0", raport.TheRaport(0));
        }
    }
}