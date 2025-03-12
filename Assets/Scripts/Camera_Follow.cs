using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, - 10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    public float maxOffset;
    public float minX, maxX;
    private bool win = false;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!win)
        {
            
            transform.position = new Vector3(target.transform.position.x, 0f, -10f);
        }
        if (win)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position,targetPosition,ref velocity,smoothTime);
        }
        
    }

    public void Win()
    {
        win = true;
        maxOffset =0;
        gameObject.transform.position = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        Camera cam = GetComponent<Camera>();
        cam.orthographicSize = 2.0f;
        cam.transform.position = new Vector3(player.transform.position.x, cam.transform.position.y, cam.transform.position.z);

    }
}
