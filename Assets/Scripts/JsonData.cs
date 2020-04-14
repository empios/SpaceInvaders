using System;
using System.Collections.Generic;

[Serializable]
public class JsonData
{
    public List<ScoreList> scores;
}

[Serializable]
public class ScoreList
{
    public int id;
    public string nickname;
    public int score;
    public DateTime created_at;
    public DateTime updated_at;
}