using TMPro;
using UnityEngine;

public class ScoreRecieve : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    
    void Start()
    {
        scoreText.text= FindObjectOfType<ScoreHold>().grabScore().ToString();
    }


}
