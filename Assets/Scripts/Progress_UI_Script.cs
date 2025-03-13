using UnityEngine;
using UnityEngine.UI;

public class Progress_UI_Script : MonoBehaviour
{
    [SerializeField] private Image UIBar;
    [SerializeField] private Text start;
    [SerializeField] private Text end;


    [Header("Object references;")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform finishline;

    private Vector3 endLinePosition;

    private float fullDistance;
    private void Start()
    {
        endLinePosition=finishline.position;
        fullDistance = GetDistance();
    }
    private float GetDistance()
    {
        return (finishline.position - player.position).sqrMagnitude;
    }
    private void UpdateProgressFill(float value)
    {
        UIBar.fillAmount = value;
    }
    private void Update()
    {
        if (player.position.z <= finishline.position.z)
        {
            float newDistance  =GetDistance();
            float progressValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);
            UpdateProgressFill(progressValue);
        }
       
    }
}
