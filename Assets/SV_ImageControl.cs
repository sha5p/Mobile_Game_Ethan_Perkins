using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SV_ImageControl : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    [SerializeField]
    private Image pickerImage;

    private RawImage SVimage;

    private ColorPickerControl CC;

    private RectTransform rectTransform, pickerTransform;

    public void OnDrag(PointerEventData eventData)
    {
        UpdateColour(eventData);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        UpdateColour(eventData);
    }
    private void Awake()
    {
        SVimage=GetComponent<RawImage>();
        CC = FindObjectOfType<ColorPickerControl>();
        rectTransform = GetComponent<RectTransform>();

        pickerTransform = GetComponent<RectTransform>();
        pickerTransform = pickerImage.GetComponent<RectTransform>();
        pickerTransform.position = new Vector2(-(rectTransform.sizeDelta.x * 0.0f),-(rectTransform.sizeDelta.y*0.05f));
    }
    private void UpdateColour(PointerEventData eventData)
    {
        Vector3 pos = rectTransform.InverseTransformPoint(eventData.position);
        float deltaX = rectTransform.sizeDelta.x *0.5f;
        float deltaY = rectTransform.sizeDelta.y * 0.5f;
        if(pos.x< -deltaX)
        {
            pos.x = -deltaX;
        }
        else if(pos.x>deltaX)
        {
            pos.x = deltaX;
        }
        if (pos.y< -deltaY)
        {
            pos.y = deltaY;
        }
        else if (pos.y > deltaY)
        {
            pos.y = deltaY;
        }

        float x = pos.x+ deltaX;
        float y = pos.y+ deltaY;

        float xNorm =x/rectTransform.sizeDelta.x;
        float yNorm = y/rectTransform.sizeDelta.y;

        pickerTransform.localPosition = pos;
        pickerImage.color = Color.HSVToRGB(0, 0, 1 - yNorm);

        CC.SetSV(xNorm, yNorm);
    }
}
