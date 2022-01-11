using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTop : MonoBehaviour
{
    Vector3 mousePos;


    private void Start()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(lookPos.x - transform.position.x, lookPos.y - transform.position.y);
        transform.up = direction;
    }
}