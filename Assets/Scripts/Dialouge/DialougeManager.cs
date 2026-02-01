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
    [SerializeField] AudioSource audioSource;

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
        Debug.Log(isInfected);
        if (isInfected) 
        {
            gen = Random.Range(0, (InfectedOptions.Count));
            currentState = (InfectedOptions[gen]).TiedTree[Random.Range(0, InfectedOptions[gen].TiedTree.Count)];
            currentSettings = InfectedOptions[gen];
            updateCurrentState(currentState);
            NPCScript.current.changeBody();
            return;
        }
        gen = Random.Range(0, (NonInfectedOptions.Count) );
        currentState = (NonInfectedOptions[gen]).TiedTree[Random.Range(0,NonInfectedOptions[gen].TiedTree.Count)];
        currentSettings= NonInfectedOptions[gen];
        NPCScript.current.changeBody();
        updateCurrentState(currentState);
    }

  

    public void updateCurrentState(CharacterDialougeOBJ chg, bool playSound = false) 
    {
        if (playSound)
            audioSource.Play();
    
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
        
        Dialouge.text = chg.dialouge.Replace("%NAME", NPCScript.current.getCurrentName()).Replace("%PRECINCT", NPCScript.current.getCurrentPrecinct());
    }

    public CharacterSettings grabCurrentSettings()
    {
        return currentSettings;
    }

}
