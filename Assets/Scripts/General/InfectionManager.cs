using System.Collections;
using UnityEngine;

public class InfectionManager : MonoBehaviour
{
    public static InfectionManager current;
    bool isInfected;
    [SerializeField][Range(0, 10)] float infectedProbability;
    int misChecks;
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


    }

    IEnumerator changeOutDelay() 
    {
        LightManager.current.enablePulsing(true);
        yield return new WaitForSeconds(1.5f);
        LightManager.current.enablePulsing(false);
        StopAllCoroutines();

    }


}
