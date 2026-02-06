using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSettings", menuName = "ScriptableObjects/CharacterSettings")]
public class CharacterSettings : ScriptableObject
{
    public bool isInfected;

    public List<CharacterDialougeOBJ> TiedTree;
    public List<int> precinctNumber;
    public List<string> precinctName;
    public bool surnameCanEndWithLetterPastP;
    public bool rapidBreathing;
    public List<Sprite> head;
    public List<Sprite> neck;
    public List<Sprite> body;

}
