using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSettings", menuName = "ScriptableObjects/CharacterSettings")]
public class CharacterSettings : ScriptableObject
{
    public List<CharacterDialougeOBJ> TiedTree;
    public int preSyncNumber;
    public string preSyncName;
    public bool sirNameCanEndWithLetterPastP;
    public List<Sprite> head;
    public List<Sprite> neck;
    public List<Sprite> body;

}