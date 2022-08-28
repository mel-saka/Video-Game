using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackVector : MonoBehaviour

{
    // Start is called before the first frame update

    public Rigidbody2D rb;

    public Camera cam;
    public static Transform attackPoint;
    Vector2 movement;
    Vector2 mousePos;

    Vector3 newPosition;

    void Start()
    {
        newPosition = transform.position;
    }
    //Functions to take the World Camera and do a screen to world point on the mouse position
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //Vector3 mousePosition = GetMouseWorldPosition();
        //Vector3 attackDir = (mousePosition - transform.position).normalized;
        ////Debug.Log(attackDir);
        //float angle = Mathf.Atan2(attackDir.y, attackDir.x) * Mathf.Rad2Deg - 190f;
        //attackPoint.localEulerAngles = new Vector3(0, 0, angle);
        ////Debug.Log(angle);
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + 130f, Vector3.forward);
        transform.rotation = rotation;
    }
     void FixedUpdate()
    {
        /*Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;*/
    }

}
