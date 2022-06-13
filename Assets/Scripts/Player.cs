using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int speed = 5;
    private float movementY;
    // Update is called once per frame
    void Update()
    {
        movementY = Input.GetAxisRaw("Vertical"); 
        transform.position += new Vector3(0f, movementY, 0f) * speed * Time.deltaTime; 
    }
}
