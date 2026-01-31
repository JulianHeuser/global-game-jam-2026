using UnityEngine;

public class NPCScript : MonoBehaviour
{   
    private static readonly string[] firstNames = {
        "Yurekthos",
        "Vikk",
        "Tholus",
        "Taenek’tet",
        "Yudur",
        "Jolen",
        "Valkan"
    };
    
    private static readonly string[] lastNames = {
        "Kalob",
        "Jahel-naarat",
        "Jaelheka",
        "Bahan’kaneb",
        "Kaag",
        "Olketheret"
    };
    
    private static readonly string[] lastNames_pastP = {
        "Taen",
    };

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
    
    public void setBreathingRate(float rate) {
    	headBobRate = rate;
    }

    public string getRandomFirstName() {
    	return firstNames[Random.Range(0,firstNames.Length)];
    }
    
    public string getRandomLastName(bool useLetterPastP) {
    	if (useLetterPastP)
    	    return lastNames_pastP[Random.Range(0,lastNames_pastP.Length)];
    	
    	return lastNames[Random.Range(0,lastNames.Length)];
    }
    
    private Vector3 headSpriteStartPos;
    void Start() {
        headSpriteStartPos = headSprite.transform.position;
    }
    
    void Update() {
        headSprite.transform.position = headSpriteStartPos + new Vector3(0.0f, Mathf.Sin(Time.time * headBobRate) * headBobIntensity, 0.0f);
    }
}
