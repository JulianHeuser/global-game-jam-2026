using System.Collections;
using UnityEngine;
using TMPro;

public class InfectionManager : MonoBehaviour
{
    public static InfectionManager current;
    bool isInfected;
    [SerializeField][Range(0, 10)] int infectedProbability=5;
    int misChecks;
    [SerializeField] TMP_Text strikeCounter;
    int success;
    
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioSourceButton;
    [SerializeField] AudioSource[] screams;

    private void Awake()
    {
        current = this;
    }

    public bool updateInfection() 
    {
        var genBool = (Random.Range(0, 10) < infectedProbability);
        isInfected=genBool;
        return genBool;
    }

    public void checkIfInfected(bool check)
    {
        if (isInfected != check) { misChecks++; }
        else { success++; }
        if (misChecks >= 3) { FindObjectOfType<ScoreHold>().updateScore(success); SceneLoader.loadScenebyName("GameOver"); }
        StartCoroutine(changeOutDelay());
        strikeCounter.text=misChecks.ToString();
        
        if (check)
            screams[Random.Range(0, screams.Length)].Play();

    }

    IEnumerator changeOutDelay() 
    {
    	audioSourceButton.Play();
	LightManager.current.TurnOff();
        yield return new WaitForSeconds(0.74f);
        NPCScript.current.changeBody();
	audioSource.Play();
        LightManager.current.enablePulsing(true);
        yield return new WaitForSeconds(0.75f);
        LightManager.current.enablePulsing(false);
        StopAllCoroutines();

    }


}
