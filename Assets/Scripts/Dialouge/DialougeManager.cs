using System.Collections.Generic;
using TMPro;
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
    [SerializeField] TMP_Text Dialouge;

    public static DialougeManager current;

    private void Awake()
    {
        current = this;
    }

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
            updatCurrentState(currentState);
            return;
        }
        currentState = infectedLines[Random.RandomRange(0,(safeLines.Count)-1)];
        updatCurrentState(currentState);
    }

    public void checkIfInfected(bool check) 
    {
        if (check == isInfected) 
        {
            misChecks++;
            Debug.Log("Failed");
        }
    }

    public void updatCurrentState(CharacterDialougeOBJ chg) 
    {
        currentState = chg;
        foreach(var item in GameObject.FindGameObjectsWithTag("DialougeOption")) 
        {
            Destroy(item);
        }
        int id = 0;
        foreach (var item in chg.additionalOptions) 
        {
            
            GameObject newOption = Instantiate(option, dialougeParent.transform);
            newOption.GetComponent<Options>().updateObject(chg.additionalOptionsText[id],chg);
            id++;

        }
        Dialouge.text = chg.dialouge;
    }


}
