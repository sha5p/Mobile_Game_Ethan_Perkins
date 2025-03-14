using NUnit.Framework.Internal;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class toggle_script_setting : MonoBehaviour
{

    [SerializeField] RectTransform uiHandleRectTransform;


    [SerializeField] TextMeshProUGUI text_control;
    [SerializeField] Color background_color;
    [SerializeField] Color handle_color;

    Color backgroundDefaultColor, handleDefaultColor;
    Toggle toggle;

    Vector2 handlePosition;

    Image backgroundImage, handleImage;

    public static int control_mobile;
    private void Awake()
    {
        toggle=GetComponent<Toggle>();

        handlePosition = uiHandleRectTransform.anchoredPosition;

        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();

        handleImage = uiHandleRectTransform.parent.gameObject.GetComponent<Image>();

        backgroundDefaultColor = backgroundImage.color;
        handleDefaultColor = handleImage.color;
        toggle.onValueChanged.AddListener(OnSwitch);

        if (toggle.isOn)
        {
            OnSwitch(true);
        }

    }
    void OnSwitch(bool on)
    {
        if(on)
        {
            
            PlayerPrefs.SetInt("Control", 0);
            control_mobile = PlayerPrefs.GetInt("Control", 0);

            text_control.text = "touch";
            uiHandleRectTransform.anchoredPosition = handlePosition * -1;
            backgroundImage.color = backgroundDefaultColor;
            handleImage.color = handleDefaultColor;

            Debug.Log(control_mobile);
        }
        else
        {
            PlayerPrefs.SetInt("Control", 0);
            control_mobile = PlayerPrefs.GetInt("Control", 1);
            control_mobile = 1;
            text_control.text = "swipe";
            uiHandleRectTransform.anchoredPosition=handlePosition; 
            backgroundImage.color = backgroundDefaultColor;
            handleImage.color = handleDefaultColor;
            Debug.Log(control_mobile);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        control_mobile = PlayerPrefs.GetInt("Control", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
