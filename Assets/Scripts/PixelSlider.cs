using UnityEngine;
using UnityEngine.EventSystems;

public class PixelSlider : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public RectTransform track;
    public RectTransform knob;

    [Range(0f, 1f)]
    public float value = 1f;

    float halfWidth;

    void Start()
    {
        halfWidth = track.rect.width / 2f;
        UpdateKnob();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UpdateValue(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateValue(eventData);
    }

    void UpdateValue(PointerEventData eventData)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            track,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint
        );

        float x = Mathf.Clamp(localPoint.x, -halfWidth, halfWidth);
        value = Mathf.InverseLerp(-halfWidth, halfWidth, x);

        UpdateKnob();
    }

    void UpdateKnob()
    {
        float x = Mathf.Lerp(-halfWidth, halfWidth, value);
        knob.localPosition = new Vector3(x, 0, 0);
    }
}
