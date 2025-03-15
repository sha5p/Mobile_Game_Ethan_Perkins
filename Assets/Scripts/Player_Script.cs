using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.SceneManagement;
public class Player_Script : MonoBehaviour
{


    [Header("Components")]
    private HingeJoint2D hJoint;
    private Rigidbody2D rb;
    private LineRenderer lineRenderer;
    
    private EdgeCollider2D edgeCollider;
    private SpriteRenderer spriteRenderer;

    [Header("Anchor")]
    [SerializeField] private GameObject anchor;
    [SerializeField] private GameObject Level_Manager;

    [Header("varible private")]
    private int lastBestPosJoint;
    private int lastBestPosSelected;
    private int bestPos;
    private float bestDistance;
    private int touches;
    private Vector3 actualJointPos;
    public bool breakstring;
    private bool swinging;
    private Game_Manager_script coins;


    [Header ("Public variable")]
    [SerializeField] private float gravityRope =2f;
    [SerializeField] private float gravityAir =0.5f;
    [SerializeField] private float factorX = 1.2f;
    [SerializeField] private float factorY = 1f;


    [Header("Bool")]
    private bool sticked = false;
    public bool won = false;



    Audio_Manager audio_manager;


    private void Awake()
    {
        audio_manager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
    }
    private void Start()
    {
        won = false;
        swinging = false;
        breakstring = false;
        edgeCollider =GetComponent<EdgeCollider2D>();
        hJoint = GetComponent<HingeJoint2D>();
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coins = GameObject.Find("GameManager").GetComponent<Game_Manager_script>();
        // initialize
        lastBestPosJoint = 0;
        lastBestPosSelected = 0;
        touches = 0;
        //refrence script 
        anchor.transform.GetChild(lastBestPosSelected).gameObject.GetComponent<String>().Selected();
        for (int i = 0; i < anchor.transform.childCount; i++)
        {
           
            edgeCollider = anchor.transform.GetChild(i).GetComponent<EdgeCollider2D>();


            Vector2[] points = new Vector2[]
            {
                new Vector2(-0.5f, -0.5f), // Bottom-left
                new Vector2(0.5f, -0.5f),  // Bottom-right
                new Vector2(0.5f, 0.5f),   // Top-right
                new Vector2(-0.5f, 0.5f)   // Top-left
            };
            edgeCollider.points = points;
        }


            
    }


    private void Update()
    {
        
        if(!won)
        {
            CheckInput();
        }
        SetEdgeCollider(lineRenderer);
        bestPos = 0;
        bestDistance = float.MaxValue;
        for (int i =0; i < anchor.transform.childCount; i++) 
        {
            
            float actualDistance= Vector2.Distance(gameObject.transform.position,anchor.transform.GetChild(i).transform.position);
            if (actualDistance < bestDistance)
            {
                bestPos = i;
                bestDistance = actualDistance;
            }
        }
        

        if (sticked)
        {

            lineRenderer.SetPosition (0,gameObject.transform.position);
            lineRenderer.SetPosition (1, actualJointPos);
            

        }
        if(lastBestPosSelected != bestPos)
        {
            anchor.transform.GetChild(lastBestPosSelected).gameObject.GetComponent<String>().Unselected();
            anchor.transform.GetChild(bestPos).gameObject.GetComponent<String>().Selected();

           
        }
        lastBestPosSelected = bestPos;
    }
    void SetEdgeCollider(LineRenderer lineRenderer)
    {
        List<Vector2> edges = new List<Vector2>();
        for (int i = 0; i < anchor.transform.childCount; i++)
        {

            
            for (int point = 0; point < lineRenderer.positionCount; point++)
            {
                Vector3 lineRendererPoint = lineRenderer.GetPosition(point);

                int num = anchor.transform.childCount - 1;
                
                Vector2 localPoint = anchor.transform.GetChild(num).InverseTransformPoint(lineRendererPoint);
                edges.Add(localPoint);
            }

            if (edges.Count > 0)
            {
                edgeCollider.SetPoints(edges);
            }
            else
            {
                Debug.LogWarning("EdgeCollider: No points in LineRenderer.");
            }
        }
    }
    private void CheckInput()
    {
        if (((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || ((Input.touchCount > 0) && (touches == 0))) && swinging==false)&& Pause_Menu.pause==false)
        {
            audio_manager.PlaySFX(audio_manager.RopeAttachSound);


            lineRenderer.enabled = true;
            hJoint.enabled = true;
            rb.gravityScale = gravityRope;

            hJoint.connectedBody = anchor.transform.GetChild(bestPos).transform.GetChild(0).gameObject.GetComponent<Rigidbody2D> ();
            

            actualJointPos = anchor.transform.GetChild(bestPos).gameObject.transform.position;
            anchor.transform.GetChild(bestPos).gameObject.GetComponent<String>().SetSticked();
            anchor.transform.GetChild(bestPos).gameObject.GetComponent<String>().Unselected();
            
            lastBestPosJoint = bestPos;
            rb.angularVelocity = 0;
            sticked = true;
            swinging = true;
            
        }
        if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space) || (Input.touchCount == 0 && touches > 0)) && toggle_script_setting.control_mobile == 1)
        {
            lineRenderer.enabled = false;
            hJoint.enabled = false;
            rb.gravityScale = gravityAir;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x * factorX, rb.linearVelocity.y + factorY); //ykyk

            anchor.transform.GetChild(lastBestPosJoint).gameObject.GetComponent<String>().SetUnsticked();

            if (bestPos == lastBestPosJoint)
            {
                anchor.transform.GetChild(bestPos).gameObject.GetComponent<String>().Selected();
                anchor.transform.GetChild(lastBestPosJoint).gameObject.GetComponent<String>().Unselected();
            }

            rb.AddTorque(-rb.linearVelocity.magnitude);
            sticked = false;

            swinging = false;
            
        }


        touches = Input.touchCount;

    }
    public void cutting()
    {
        lineRenderer.enabled = false;
        hJoint.enabled = false;
        rb.gravityScale = gravityAir;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x * factorX, rb.linearVelocity.y + factorY); //ykyk

        anchor.transform.GetChild(lastBestPosJoint).gameObject.GetComponent<String>().SetUnsticked();

        if (bestPos == lastBestPosJoint)
        {
            anchor.transform.GetChild(bestPos).gameObject.GetComponent<String>().Selected();
            anchor.transform.GetChild(lastBestPosJoint).gameObject.GetComponent<String>().Unselected();
        }

        rb.AddTorque(-rb.linearVelocity.magnitude);
        sticked = false;

        swinging = false;
        
    }
    private void ChangeSprite()
    {

    }
    public bool getSticked()
    {
        return sticked;
    }
    public void reset(Vector3 initPos)
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        gameObject.transform.position = initPos;
        gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }
    public Vector3 LookAt2d(Vector3 vec)
    {
        return new Vector3(gameObject.transform.eulerAngles.x,gameObject.transform.eulerAngles.y,Vector2.SignedAngle(Vector2.up,vec));
    }
    public void win(float speedWin)
    {
        won = true;
        rb.gravityScale = 0;
        gameObject.transform.eulerAngles = LookAt2d(rb.linearVelocity);
        rb.linearVelocity = rb.linearVelocity.normalized * speedWin;
        rb.angularVelocity = 0;
        rb.AddForce(rb.transform.right * speedWin * Time.fixedDeltaTime, ForceMode2D.Impulse);
        Level_Manager.gameObject.GetComponent<Contiue>().nextlevel();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            string sceneName = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetInt(sceneName + "CollectedCoins", 1);
            PlayerPrefs.Save(); 

            audio_manager.PlaySFX(audio_manager.coin);
            Destroy(other.gameObject);
            
        }
    }
}


