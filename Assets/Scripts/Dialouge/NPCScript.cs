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

    public void changeBody()
    {
        var state = DialougeManager.current.grabCurrentSettings();
        headSprite.sprite = state.head[Random.RandomRange(0, state.head.Count )];
        bodySprite.sprite = state.body[Random.RandomRange(0, state.body.Count )];
        neckSprite.sprite = state.neck[Random.RandomRange(0, state.neck.Count )];

    }


    public void setBreathingRate(float rate)
    {
        headBobRate = rate;
    }

    public string getRandomFirstName()
    {
        return firstNames[Random.Range(0, firstNames.Length)];
    }

    public string getRandomLastName(bool useLetterPastP)
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
