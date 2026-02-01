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
    

    private void Awake()
    {
        current = this;
    }

    public bool updateInfection() 
    {
        var genBool = (Random.RandomRange(0, 10) < infectedProbability);
        isInfected=genBool;
        return genBool;
    }

    public void checkIfInfected(bool check)
    {
        if (isInfected != check) { misChecks++; }
        StartCoroutine(changeOutDelay());
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
