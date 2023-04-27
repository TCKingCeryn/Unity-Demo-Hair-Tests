using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDragRotate : MonoBehaviour
{

    //camera holder
    public Transform ObjectHolder;
    //[Space]
    //public float currDistance = 5.0f;
    //public float prevDistance;
    [Space]
    public float xRotate = 250.0f;
    public float yRotate = 120.0f;
    [Space]
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;




    private float x = 0.0f;
    private float y = 0.0f;

   


    // Start is called before the first frame update
    void Start()
    {
        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if (currDistance < 2)
        //{
        //    currDistance = 2;
        //}
        //currDistance -= Input.GetAxis("Mouse ScrollWheel") * 2;

        if (ObjectHolder && (Input.GetMouseButton(0) || Input.GetMouseButton(1)))
        {
            var pos = Input.mousePosition;
            float dpiScale = 1;
            if (Screen.dpi < 1) dpiScale = 1;
            if (Screen.dpi < 200) dpiScale = 1;
            else dpiScale = Screen.dpi / 200f;
            if (pos.x < 380 * dpiScale && Screen.height - pos.y < 250 * dpiScale) return;


            x += (float)(Input.GetAxis("Mouse X") * xRotate * 0.02);
            y -= (float)(Input.GetAxis("Mouse Y") * yRotate * 0.02);
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            var rotation = Quaternion.Euler(y, x, 0);
            //var position = rotation * new Vector3(0, 0, -currDistance) + CameraHolder.position;

            transform.rotation = rotation;
            //transform.position = position;
        }
        else
        {

        }

        //if (prevDistance != currDistance)
        //{
        //    prevDistance = currDistance;
        //    var rot = Quaternion.Euler(y, x, 0);
        //    var po = rot * new Vector3(0, 0, -currDistance) + CameraHolder.position;
        //    transform.rotation = rot;
        //    transform.position = po;
        //}
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }


}
