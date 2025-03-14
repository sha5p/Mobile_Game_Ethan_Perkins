using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class String : MonoBehaviour
{
    [SerializeField] private Sprite spriteSticked;
    [SerializeField] private Sprite spriteUnsticked;
    private GameObject line;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private EdgeCollider2D edgeCollider;

    private bool sticked = false;
    private float connected = 0;

    [SerializeField] private float animTime;
    [SerializeField] private AnimationCurve animationCurve;

    [Header("Player_script")]
    [SerializeField] private GameObject Player_script;
    private Sprite lastSprite;

    Audio_Manager audio_manager;
    private void Awake()
    {
        audio_manager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
    }
    private void Start()
    {
        Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        edgeCollider = GetComponent<EdgeCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        line = gameObject.transform.GetChild(1).gameObject;
        if (boxCollider == null)
        {
            
        }

        if (spriteRenderer.sprite == null)
        {
            
        }

        if (boxCollider != null && spriteRenderer != null)
        {
            boxCollider.size = spriteRenderer.sprite.bounds.size;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("toggle_script_setting.control_mobile" + toggle_script_setting.control_mobile);
        if ((collision.gameObject != null && collision.gameObject.name == "Cutter")&& toggle_script_setting.control_mobile == 0)
        {
            audio_manager.PlaySFX(audio_manager.Swip_Sound);
            Player_script.gameObject.GetComponent<Player_Script>().cutting();
            Debug.Log("Triggering with: " + collision.gameObject.name);
            // Your custom trigger handling logic here
        }
        else
        {
            Debug.LogWarning("collision.gameObject is null or not named 'Cutter'");
        }
    }
    private void Update()
    {
     

    }
    public void SetSticked()
    {

        spriteRenderer.sprite = spriteSticked;
        sticked = true;

    }
    public void SetUnsticked()
    {
        spriteRenderer.sprite = spriteUnsticked;
        sticked = true;
    }
    public void Selected()
    {
        if (connected == 0)
        {
            //pass
        }
        else
        {
            line.transform.localScale = Vector3.zero;
        }

    }

    public void Unselected()

    {
        StartCoroutine(SelectingJoint());
        line.transform.localScale = Vector3.zero;
    }


    IEnumerator SelectingJoint ()
    {
        float time = 0f;
        Vector3 startScale =Vector3.zero;
        Vector3 endScale = new Vector3(1.13f, 1.13f, 1.13f);

        while(time <= animTime)
        {
            time += Time.deltaTime;
            line.transform.localScale = Vector3.Lerp(startScale, endScale, animationCurve.Evaluate(time));
            yield return null;
        }
    }

}


