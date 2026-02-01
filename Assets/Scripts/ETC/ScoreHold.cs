using UnityEngine;

public class ScoreHold : MonoBehaviour
{
    int Score=0;

    public void updateScore(int chg) 
    {
        Score = chg;
    }

    public int grabScore() 
    {
        return Score;
    }

}
