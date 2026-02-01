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
    [SerializeField] GameObject rayBlock;
    
    [SerializeField] GameObject incorrectIndicator;
    
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioSourceButton;
    [SerializeField] AudioSource correctSound;
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
        StartCoroutine(changeOutDelay(isInfected == check));
        
        if (check)
            screams[Random.Range(0, screams.Length)].Play();

    }

    IEnumerator changeOutDelay(bool isCorrect) 
    {
    	audioSourceButton.Play();
	LightManager.current.TurnOff();
	
	if (isCorrect) {
	    incorrectIndicator.SetActive(false);
	    correctSound.Play();
	    strikeCounter.gameObject.SetActive(true);

            yield return new WaitForSeconds(0.185f);
            strikeCounter.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.185f);
            strikeCounter.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.37f);
        } else {
            GameObject newImageCheck = incorrectIndicator.transform.GetChild(misChecks - 1).gameObject;
            newImageCheck.SetActive(true);
            yield return new WaitForSeconds(0.185f);
            newImageCheck.SetActive(false);
            yield return new WaitForSeconds(0.185f);
            newImageCheck.SetActive(true);
            yield return new WaitForSeconds(0.37f);
        }
        
        NPCScript.current.changeBody();
	audioSource.Play();
        LightManager.current.enablePulsing(true);
        yield return new WaitForSeconds(0.75f);
	incorrectIndicator.SetActive(true);
	strikeCounter.gameObject.SetActive(false);
        LightManager.current.enablePulsing(false);
        rayBlock.SetActive(false);
        StopAllCoroutines();

    }


}
