using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillScript: MonoBehaviour
{
    private Collider2D BillCollider;
    private Collider2D ChangeTrayCollider;
    private Collider2D RegisterCollider;
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    private bool moved =  false;
    private bool onTray = false;
    public int value;

    
    public void Awake()
    {
        BillCollider = gameObject.GetComponent<Collider2D>();
        ChangeTrayCollider = GameObject.Find("Change Tray").GetComponent<Collider2D>();
        RegisterCollider = GameObject.Find("Register Tray").GetComponent<Collider2D>();
    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Create duplicate bill below when picked up from register
            if (!moved)
            {
                Instantiate(gameObject);
                moved = true;
            }
            /*
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            */
            isBeingHeld = true;
        }
    }

    public void OnMouseUp()
    {
        isBeingHeld = false;
        this.gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 0);
        // If bill is dropped in neither tray, delete it
        if (!onTray)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isBeingHeld)
        {
            // Move bill to follow mouse while dragged
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);

            // Update whether the bill is on top of the change tray or not
            if (BillCollider.bounds.Intersects(ChangeTrayCollider.bounds))
            {
                onTray = true;
            }
            else { onTray = false;  }
        }
    }
}