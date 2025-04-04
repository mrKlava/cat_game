using UnityEngine;
using UnityEngine.EventSystems;

public class TouchButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPressed = false; // Track button state

    // Called when the button is touched
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    // Called when the button is released
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}