using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody2D rb;
    public GameObject thrownObject;
    public GameObject currentThrownObject;
    int clickCount;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        clickCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        }
        if (Input.GetMouseButtonDown(0))
        {
            clickCount++;
            if(clickCount < 2)
            {
                currentThrownObject = Instantiate(thrownObject);
                currentThrownObject.transform.position = this.transform.position;
                var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var force = pos - currentThrownObject.transform.position;
                currentThrownObject.GetComponent<Rigidbody2D>().AddForce(force.normalized * 1000);
            }
            else
            {
                clickCount = 0;
                var newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                newPos.z = 0;
                this.transform.position = newPos;
            }
            
        }
    }
}
