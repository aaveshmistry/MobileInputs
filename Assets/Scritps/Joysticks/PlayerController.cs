using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int moveSpeed = 4;
    public Joystick joystick;
  
    
    void Start()
    {
        this.transform.Translate = new Vector3(joystick.Horizontal, joystick.Vertical * moveSpeed, 0f) * 5f * Time.deltaTime, Space.World;
    }

    
}
