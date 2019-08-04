using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputType : MonoBehaviour
{
    public GameObject capsule;
    public float upForce = 4f;
    private Rigidbody rigid;
    void OnTouchDown()
    {
        capsule.GetComponent<Rigidbody>().velocity = (Vector3.up * upForce);
        Debug.Log("Down");
    }

    void OnTouchStay()
    {
        Debug.Log("Stay");
    }

    void OnTouchUp()
    {
        Debug.Log("Up");
    }
    void OnTouchExit()
    {
        Debug.Log("Exit");
    }


}
