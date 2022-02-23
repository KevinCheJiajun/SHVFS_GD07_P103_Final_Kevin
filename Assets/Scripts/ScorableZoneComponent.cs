using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorableZoneComponent : MonoBehaviour
{
    public List<int> ZoneTeamID = new List<int>();
    public float TickPoints;
    public float TickRate;
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
        if (timer < TickRate) return;
        if (ZoneTeamID.Count != 0)
        {
            var setTeamID = ZoneTeamID[0];
            foreach (var triggerTeamID in ZoneTeamID)
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
                        teams[i].teamScore += TickPoints;
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
            ZoneTeamID.Add(other.GetComponent<ScorerComponent>().TeamID);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ScorerComponent>())
        {
            ZoneTeamID.Remove(other.GetComponent<ScorerComponent>().TeamID);
        }
    }
}
