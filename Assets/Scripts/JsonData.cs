using System;
using System.Collections.Generic;

[Serializable]
public class JsonData
{
    public bool success;
    public List<ScoreList> data;
}

[Serializable]
public class ScoreList
{
    public string _id;
    public string username;
    public int score;
    public int __v;
}