
namespace FotballRanking
{
    class RaportOfTeam
    {
        Team[] teams;
        public RaportOfTeam(Team[] teams)
        {
            this.teams = teams;
        }

        public string TheRaport(int position)
        {
            return teams[position].Raport(teams[position]);
        }
    }
}
