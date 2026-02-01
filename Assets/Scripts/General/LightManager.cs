using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    [SerializeField]Light2D SpotLight;
    static public LightManager current;
    float step=.8f;
    bool isLerping = false;
    [SerializeField][Range(0,1)]float timerDelay=1f;
    float timer=Mathf.Infinity;
    
    bool isOff = false;

    private void Awake()
    {
        current = this;
    }

    public void enablePulsing(bool chg) 
    {
        isOff = false;
        isLerping = chg;
    }
    
    public void TurnOff() {
        isOff = true;
    }


    private void Update()
    {
    	if (isOff) { 
    	    SpotLight.intensity = 0.0f;
            return;
        }
        if (!isLerping) { SpotLight.intensity = Mathf.Lerp(3, SpotLight.intensity, step); timer = Mathf.Infinity; ; return; }

        pullLightInAndOut();



    }

    private void pullLightInAndOut() 
    {
        timer += Time.deltaTime;
        if (timer>=timerDelay) 
        {
            
            SpotLight.intensity = Mathf.Lerp(0, SpotLight.intensity, Time.deltaTime*step);
            timer = 0;

            return;
        }


        SpotLight.intensity = Mathf.Lerp(SpotLight.intensity,3, Time.deltaTime*step);

    }


}
