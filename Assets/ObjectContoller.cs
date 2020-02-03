using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContoller : MonoBehaviour
{
    public GameObject thrownObject;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            Destroy(thrownObject, 2.0f);
        }
    }
}
