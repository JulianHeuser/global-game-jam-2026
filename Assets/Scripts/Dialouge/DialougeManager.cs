using System.Collections.Generic;
using UnityEngine;

public class DialougeManager : MonoBehaviour
{
    [SerializeField][Range(0,10)] float infectedProbability;
    CharacterDialougeOBJ currentState;
    bool isInfected;
    int misChecks;

    [SerializeField]List<CharacterDialougeOBJ> infectedLines;
    [SerializeField]List<CharacterDialougeOBJ> safeLines;

    [SerializeField] GameObject dialougeParent;
    [SerializeField] GameObject option;


    void Start()
    {
        selectIfInfected();
        
    }


    
    public void selectIfInfected() 
    {
        isInfected = Random.RandomRange(0, 10) >= infectedProbability;
        if (isInfected) 
        {
            currentState = infectedLines[Random.RandomRange(0,(infectedLines.Count)-1)];
            return;
        }
        currentState = infectedLines[Random.RandomRange(0,(safeLines.Count)-1)];

    }

    public void checkIfInfected(bool check) 
    {
        if (check == isInfected) 
        {
            misChecks++;
        }
    }



}
