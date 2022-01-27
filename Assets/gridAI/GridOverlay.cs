using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridOverlay : MonoBehaviour, IPointerEnterHandler
{
    float transparency = 0.5f;
    SpriteRenderer renderer;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateColor(Color color)
    {
        renderer.color = new Color(color.r, color.g, color.b, transparency);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //if (MouseManager.Instance.canPlaceItem())
        //{
        //    MouseManager.Instance.moveToGrid(transform);
        //}
    }
}
