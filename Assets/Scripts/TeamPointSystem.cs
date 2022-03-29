using System.Collections.Generic;
using System.Linq;


public class TeamPointSystem : Singleton<TeamPointSystem>
{
    public int minNumOfTeam;
    public List<Team> teams = new List<Team>();
    public List<ScorableZoneComponent> zones = new List<ScorableZoneComponent>();

    public override void Awake()
    {
        base.Awake();
        var scorerComponents = FindObjectsOfType<ScorerComponent>();
        foreach (var scorerComponent in scorerComponents)
        {
            if (!teams.Any(team => team.ID.Equals(scorerComponent.teamID)))
            {
                var team = new Team()
                {
                    ID = scorerComponent.teamID,
                    Members = new List<ScorerComponent> { scorerComponent }
                };
                teams.Add(team);
            }
            else
            {
                var team = teams.FirstOrDefault(team => team.ID.Equals
                (scorerComponent.teamID));
                if (team.Members.Contains(scorerComponent)) return;
                team.Members.Add(scorerComponent);
            }
        }
    }
}
