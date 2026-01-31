using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DialougeOBJ", menuName ="ScriptableObjects/DialougeOBJ")]
public class CharacterDialougeOBJ : ScriptableObject
{
    [TextArea(10,60)]
    public string dialouge;

    public List<CharacterDialougeOBJ> additionalOptions;

    public List<string> additionalOptionsText;
    public List<string> responses;



}
