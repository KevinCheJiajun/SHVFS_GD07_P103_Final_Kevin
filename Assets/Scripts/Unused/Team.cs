using System;
using System.Collections.Generic;


[Serializable]
public class Team
{
    public int ID;
    public List<ScorerComponent> Members;
    public float teamScore;
}