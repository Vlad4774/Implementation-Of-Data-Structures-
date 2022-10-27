namespace FotballRanking
{
    public class RaportTest
    {
        [Fact]
        public void CaseOneTeamInRanking()
        {
            Team[] teams = new Team[0];
            var ranking = new Ranking(teams);
            var newTeam = new Team("fcsb", 0);
            ranking.Add(newTeam, ref teams);
            var raport = new RaportOfTeam(teams);
            Assert.Equal("fcsb 0", raport.TheRaport(0));
        }

        [Fact]
        public void CaseTwoTeamInRanking()
        {
            Team[] teams = new Team[0];
            var ranking = new Ranking(teams);
            var newTeam = new Team("fcsb", 20);
            ranking.Add(newTeam, ref teams);
            newTeam = new Team("sepsi", 17);
            ranking.Add(newTeam, ref teams);
            var raport = new RaportOfTeam(teams);
            Assert.Equal("sepsi 17", raport.TheRaport(1));
        }
    }
}