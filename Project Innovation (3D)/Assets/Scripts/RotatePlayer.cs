using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [SerializeField] float speed;
    float oldPosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            oldPosition = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(1))
        {
            float newPosition = Input.mousePosition.x;

            float difference = newPosition - oldPosition;

            Vector3 extra = new Vector3(0, difference * speed, 0);
            //this.transform.rotation = Quaternion.Euler(transform.eulerAngles + extra);
            transform.Rotate(extra);

            oldPosition = newPosition;
        }

    }
}
