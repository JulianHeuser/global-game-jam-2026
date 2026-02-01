using System.Collections;
using UnityEngine;
using TMPro;

public class InfectionManager : MonoBehaviour
{
    public static InfectionManager current;
    bool isInfected;
    [SerializeField][Range(0, 10)] float infectedProbability;
    int misChecks;
    [SerializeField] TMP_Text strikeCounter;
    

    private void Awake()
    {
        current = this;
    }

    public bool updateInfection() 
    {
        return Random.RandomRange(0, 10) >= infectedProbability;
    }

    public void checkIfInfected(bool check)
    {
        StartCoroutine(changeOutDelay());
        if (isInfected!=check) { misChecks++; }
        strikeCounter.text=misChecks.ToString();

    }

    IEnumerator changeOutDelay() 
    {
        LightManager.current.enablePulsing(true);
        NPCScript.current.changeBody();
        yield return new WaitForSeconds(1.5f);
        LightManager.current.enablePulsing(false);
        StopAllCoroutines();

    }


}
