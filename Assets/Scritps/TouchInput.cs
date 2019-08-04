using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public LayerMask touchMask;
    private List<GameObject> _touchList = new List<GameObject>();
    private GameObject[] _oldTouch;
    private RaycastHit _hit;

    private void Update()
    {
    #if UNITY_EDITOR
    // Use Mosue 
    if(Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0) )
        {
            _oldTouch = new GameObject[_touchList.Count];
            _touchList.CopyTo(_oldTouch);
            _touchList.Clear();

            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out _hit, touchMask))
            {
                GameObject recipent = _hit.transform.gameObject;
                _touchList.Add(recipent);

                if(Input.GetMouseButtonDown(0))
                {
                    recipent.SendMessage("OnTouchDown", _hit.point, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("OnTouchDown");
                }

                if (Input.GetMouseButtonDown(0))
                {
                    recipent.SendMessage("OnTouchStay", _hit.point, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("OnTouchStay");
                }

                if (Input.GetMouseButtonDown(0))
                {
                    recipent.SendMessage("OnTouchUp", _hit.point, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("OnTouchUp");
                }
            }
            foreach (GameObject item in _oldTouch)
            {
                if(!_touchList.Contains(item))
                {
                    item.SendMessage("OnTouchExit", _hit.point, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("OnTouchExit");
                }
            }
        }
    #endif
    // Use Touch
    if(Input.touchCount > 0)
        {
            _oldTouch = new GameObject[_touchList.Count];
            _touchList.CopyTo(_oldTouch);
            _touchList.Clear();

            foreach (Touch touch in Input.touches)
            {
                Ray ray = GetComponent<Camera>().ScreenPointToRay(touch.position);
                if(Physics.Raycast(ray, out _hit, touchMask))
                {
                    GameObject recipent = _hit.transform.gameObject;
                    _touchList.Add(recipent);

                    if(touch.phase == TouchPhase.Began)
                    {
                        recipent.SendMessage("OnTouchDown", _hit.point, SendMessageOptions.DontRequireReceiver);
                    }

                    if (touch.phase == TouchPhase.Ended)
                    {
                        recipent.SendMessage("OnTouchEnded", _hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Stationary)
                    {
                        recipent.SendMessage("OnTouchStationary", _hit.point, SendMessageOptions.DontRequireReceiver);
                    }

                    if (touch.phase == TouchPhase.Canceled)
                    {
                        recipent.SendMessage("OnTouchCancled", _hit.point, SendMessageOptions.DontRequireReceiver);
                    }


                }
            }

            foreach (GameObject item in _oldTouch)
            {
                if(!_touchList.Contains(item))
                {
                    item.SendMessage("OnTouchExit", _hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
