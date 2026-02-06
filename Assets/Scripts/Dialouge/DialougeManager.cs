using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialougeManager : MonoBehaviour
{
    CharacterSettings currentSettings;
    CharacterDialougeOBJ currentState;

    [SerializeField] List<CharacterSettings> characterList;


    [SerializeField] GameObject dialougeParent;
    [SerializeField] GameObject option;
    [SerializeField] TMP_Text Dialouge;
    [SerializeField] AudioSource audioSource;

    public static DialougeManager current;

    private int currentOptionIndex = 0;

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
        if (currentOptionIndex < characterList.Count) {
            currentState = (characterList[currentOptionIndex]).TiedTree[Random.Range(0,characterList[currentOptionIndex].TiedTree.Count)];
            currentSettings= characterList[currentOptionIndex];
            updateCurrentState(currentState);
            NPCScript.current.changeBody();
            InfectionManager.current.setInfection(currentSettings.isInfected);
        }

        currentOptionIndex++;
    }

    public bool isLast() {
        print(currentOptionIndex);
        return currentOptionIndex > characterList.Count;
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
