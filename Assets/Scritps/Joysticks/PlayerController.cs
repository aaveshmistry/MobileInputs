using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int moveSpeed = 4;
    public Joystick moveJoystick;
    public Joystick rotateJoystick;
  
    
    void Update()
    {
        this.transform.Translate(new Vector3(moveJoystick.Horizontal, moveJoystick.Vertical, 0f) * moveSpeed * Time.deltaTime, Space.World);

        this.transform.Rotate(new Vector3(0,0, rotateJoystick.Horizontal) * moveSpeed * Time.deltaTime, moveSpeed);
    }

    
}
