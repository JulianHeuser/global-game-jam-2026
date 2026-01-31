using UnityEngine;

public class NPCScript : MonoBehaviour
{

    [SerializeField]
    private Sprite[] heads;
    
    [SerializeField]
    private Sprite[] necks;
    
    [SerializeField]
    private Sprite[] bodies;

    [SerializeField]
    private SpriteRenderer headSprite;
    [SerializeField]
    private SpriteRenderer neckSprite;
    [SerializeField]
    private SpriteRenderer bodySprite;
    
    [SerializeField]
    private float headBobIntensity = 0.06f;
    private float headBobRate = 2.0f;

    public void setHead(int index) {
    	headSprite.sprite = heads[index];
    }
    
    public void setNeck(int index) {
    	neckSprite.sprite = necks[index];
    }
    
    public void setBody(int index) {
    	bodySprite.sprite = bodies[index];
    }
    
    private void setBreathingRate(float rate) {
    	headBobRate = rate;
    }
    
    private Vector3 headSpriteStartPos;
    void Start() {
        headSpriteStartPos = headSprite.transform.position;
    }
    
    void Update() {
        headSprite.transform.position = headSpriteStartPos + new Vector3(0.0f, Mathf.Sin(Time.time * headBobRate) * headBobIntensity, 0.0f);
    }
}
