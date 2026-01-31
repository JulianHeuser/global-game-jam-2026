using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    [SerializeField]Light2D SpotLight;
    static public LightManager current;
    float step=.8f;
    bool isLerping = false;
    [SerializeField][Range(0,1)]float timerDelay=1f;
    float timer;

    private void Awake()
    {
        current = this;
    }

    public void enablePulsing(bool chg) 
    {
        isLerping = chg;
    }


    private void Update()
    {
        if (!isLerping) { SpotLight.intensity = Mathf.Lerp(1, SpotLight.intensity, step); return; }

        pullLightInAndOut();



    }

    private void pullLightInAndOut() 
    {
        timer += Time.deltaTime;
        if (timer>=timerDelay) 
        {
            
            SpotLight.intensity = Mathf.Lerp(0, SpotLight.intensity, Time.deltaTime*step);
            timer = 0;
            Debug.Log("Flash out");
            return;
        }
        Debug.Log("Flash in");

        SpotLight.intensity = Mathf.Lerp(SpotLight.intensity,1, Time.deltaTime*step);

    }


}
