using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorableZoneComponent : MonoBehaviour
{
    public List<int> zoneTeamID = new List<int>();
    public float tickPoints;
    public float tickRate;
    private float timer = 0;
    public int zoneID = 0;
    private void Start()
    {
        var zones = TeamPointSystem.Instance.zones;
        zones.Add(this);
        zoneID = zones.IndexOf(this);
    }

    private void Update()
    {
        GetTheDamnScore();
    }

    private void GetTheDamnScore()
    {
        timer += Time.deltaTime;
        bool isSame = true;
        if (timer < tickRate) return;
        if (zoneTeamID.Count != 0)
        {
            var setTeamID = zoneTeamID[0];
            foreach (var triggerTeamID in zoneTeamID)
            {
                if (triggerTeamID != setTeamID)
                {
                    isSame = false;
                }
            }
            var teams = TeamPointSystem.Instance.teams;

                for (int i = 0; i < teams.Count; i++)
                {
                    if (teams[i].ID == setTeamID)
                    {
                        teams[i].teamScore += tickPoints;
                        Debug.Log($"Team{i} now get {teams[i].teamScore} Scores!");
                    }
                }
        }
        timer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ScorerComponent>())
        {
            zoneTeamID.Add(other.GetComponent<ScorerComponent>().teamID);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ScorerComponent>())
        {
            zoneTeamID.Remove(other.GetComponent<ScorerComponent>().teamID);
        }
    }

}
