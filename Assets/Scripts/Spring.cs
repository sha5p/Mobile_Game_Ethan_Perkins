using UnityEngine;

public class Spring : MonoBehaviour
{
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetTrigger("Touch");
    }
    void Update()
    {
        
    }
}
