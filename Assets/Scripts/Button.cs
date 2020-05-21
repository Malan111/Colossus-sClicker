
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class Button : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image image;
    [SerializeField] private UnityEvent clickEvent;
    [SerializeField] private Color clickColor;
    [SerializeField] private float time;

    private bool isDown = false;
    private Color defaultColor;


    private void Start()
    {
        image = GetComponent<Image>();
        defaultColor = image.color;
    }

    private void Update()
    {
        if (!isDown) image.color = Color.Lerp(image.color, defaultColor, time * Time.deltaTime);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickEvent.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
        image.color = clickColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
    }
}
