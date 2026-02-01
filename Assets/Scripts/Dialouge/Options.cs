using TMPro;
using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField]CharacterDialougeOBJ selectedState;
    [SerializeField] TMP_Text text;


    public void updateObject(string pulledText,CharacterDialougeOBJ dialougeOBJ)
    {
        text.text = pulledText;
        selectedState = dialougeOBJ;
    }

    public void selectedNewOption() 
    {
        DialougeManager.current.updateCurrentState(selectedState, true);
    }
    

}
