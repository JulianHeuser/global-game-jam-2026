using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class NPCScript : MonoBehaviour
{
    public static NPCScript current;


    private static readonly string[] firstNames = {
        "Yurekthos",
        "Vikk",
        "Tholus",
        "Taenek'tet",
        "Yudur",
        "Jolen",
        "Valkan",
        "Madu'akirbrak",
        "Haeborth",
        "Kaeth-Faesketh",
        "Kaadur",
        "Sakt",
        "Jako-kybranokod",
        "Huth-brehen",
        "Yeadsoboroth",
        "Yeag",
    };

    private static readonly string[] lastNames = {
        "Kalob",
        "Jaelheka",
        "Bahan'kaneb",
        "Kaag",
        "Taen",
        "Aeprap",
        "Yakdai",
        "Skion",
        "Jhorsk",
        "Na’on",
        "Jaadkareden",
    };

    private static readonly string[] lastNames_pastP = {
        "Alcarz",
        "Ka'albar",
        "Keth'tetsev",
        "Kyunsabov",
        "Gharka'er",
        "Jahel-naarat",
        "Olketheret",
        "Maeheket",
    };



    [SerializeField]
    private SpriteRenderer headSprite;
    [SerializeField]
    private SpriteRenderer neckSprite;
    [SerializeField]
    private SpriteRenderer bodySprite;

    [SerializeField]
    private float headBobIntensity = 0.06f;
    private float headBobRate = 2.0f;


    private void Awake()
    {
        current = this;
    }

    private string currentCharacterName = "";
    private string currentPrecinct = "";

    public void changeBody()
    {
        var state = DialougeManager.current.grabCurrentSettings();
        headSprite.sprite = state.head[Random.Range(0, state.head.Count )];
        bodySprite.sprite = state.body[Random.Range(0, state.body.Count )];
        neckSprite.sprite = state.neck[Random.Range(0, state.neck.Count )];
        
        Debug.Log("SET BODY");
        currentCharacterName = getRandomFirstName() + " " + getRandomLastName(state.surnameCanEndWithLetterPastP);
        currentPrecinct = string.Format("{0}-{1}",
        	state.precinctNumber[Random.Range(0, state.precinctNumber.Count)],
        	state.precinctName[Random.Range(0, state.precinctName.Count)]
        );
        
        if (state.rapidBreathing) {
            headBobIntensity = Random.Range(0.1f, 0.2f);
            headBobRate = Random.Range(2.5f, 5.0f);
        } else {
            headBobIntensity = Random.Range(0.04f, 0.08f);
            headBobRate = Random.Range(0.5f, 1.0f);
        }

    }

    public string getCurrentName() {
        return currentCharacterName;
    }


    public string getCurrentPrecinct() {
        return currentPrecinct;
    }

    private string getRandomFirstName()
    {
        return firstNames[Random.Range(0, firstNames.Length)];
    }

    private string getRandomLastName(bool useLetterPastP)
    {
        if (useLetterPastP)
            return lastNames_pastP[Random.Range(0, lastNames_pastP.Length)];

        return lastNames[Random.Range(0, lastNames.Length)];
    }

    private Vector3 headSpriteStartPos;
    void Start()
    {
        headSpriteStartPos = headSprite.transform.position;
    }

    void Update()
    {
        headSprite.transform.position = headSpriteStartPos + new Vector3(0.0f, Mathf.Sin(Time.time * headBobRate) * headBobIntensity, 0.0f);
    }
}
