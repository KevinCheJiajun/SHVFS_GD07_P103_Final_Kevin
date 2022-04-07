using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScorerComponent : MonoBehaviour
{
    public int teamID;
    public int zoneID;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ScorableZoneComponent>())
        {
            zoneID = other.GetComponent<ScorableZoneComponent>().zoneID;
        }
    }

    private void OnDestroy()
    {
        var teams = TeamPointSystem.Instance.teams;
        for (int i = 0; i < teams.Count; i++)
        {
            if (teams[i].ID == teamID)
            {
                teams[i].Members.Remove(this);
            }
        }
        var allzones = FindObjectsOfType<ScorableZoneComponent>();
        foreach (var zone in allzones)
        {
            if (zone.zoneID == this.zoneID)
            {
                var triggerTeamID = zone.zoneTeamID;
                for (int i = 0; i < triggerTeamID.Count; i++)
                {
                    if (triggerTeamID[i] == this.teamID)
                    {
                        triggerTeamID.Remove(triggerTeamID[i]);
                        break;
                    }
                }
            }
        }
    }
}