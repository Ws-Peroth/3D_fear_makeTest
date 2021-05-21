using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMove : MonoBehaviour
{
    public GameObject mainCamera;
    public float speed;

    private void Start()
    {
        speed = -5f;
        gameObject.transform.rotation = Quaternion.identity;
        mainCamera.transform.rotation = Quaternion.identity;
    }

    public void Walk()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward  * speed * Time.deltaTime);
        }
    }

    public void Spin()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -0.1f, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0.1f, 0);
        }
    }

    public void ViewYChange()
    {
        if (Input.GetKey(KeyCode.S))
        {
            if (mainCamera.transform.rotation.x <= 45.0f)
                mainCamera.transform.Rotate(0.1f, 0, 0);
            else
                mainCamera.transform.rotation = Quaternion.Euler(45.0f, mainCamera.transform.rotation.y, mainCamera.transform.rotation.y);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (mainCamera.transform.rotation.x >= -45.0f)
                mainCamera.transform.Rotate(-0.1f, 0, 0);
            else
                mainCamera.transform.rotation = Quaternion.Euler(-45.0f, mainCamera.transform.rotation.y, mainCamera.transform.rotation.y);
        }
    }
    void Update()
    {
        Walk();
        Spin();
        ViewYChange();
    }
}
