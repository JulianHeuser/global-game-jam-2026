using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialougeManager : MonoBehaviour
{
    CharacterSettings currentSettings;
    CharacterDialougeOBJ currentState;
    
    bool isInfected;

    [SerializeField] List<CharacterSettings> InfectedOptions;
    [SerializeField] List<CharacterSettings> NonInfectedOptions;


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
        int gen;
        isInfected = InfectionManager.current.updateInfection();
        if (isInfected) 
        {
            gen = Random.RandomRange(0, (InfectedOptions.Count) - 1);
            currentState = (InfectedOptions[gen]).TiedTree[Random.RandomRange(0, InfectedOptions[gen].TiedTree.Count - 1)];
            currentSettings = InfectedOptions[gen];
            updateCurrentState(currentState);
            return;
        }
        gen = Random.RandomRange(0, (NonInfectedOptions.Count) - 1);
        currentState = (NonInfectedOptions[gen]).TiedTree[Random.RandomRange(0,NonInfectedOptions[gen].TiedTree.Count-1)];
        currentSettings= NonInfectedOptions[gen];
        updateCurrentState(currentState);
    }

  

    public void updateCurrentState(CharacterDialougeOBJ chg) 
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
            newOption.GetComponent<Options>().updateObject(chg.additionalOptionsText[id],item);
            id++;

        }
        Dialouge.text = chg.dialouge;
    }

    public CharacterSettings grabCurrentSettings()
    {
        return currentSettings;
    }

}
