using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float oldPosition;
    private void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0))
        {
            oldPosition = Input.mousePosition.y;
        }


        if (Input.GetMouseButton(0))
        {
            
            float newPosition = Input.mousePosition.y;

            float difference = newPosition - oldPosition;

            Vector3 extra = new Vector3(difference, 0, 0);
            //this.transform.rotation = Quaternion.Euler(transform.eulerAngles + extra);
            transform.Rotate(extra);
            Debug.Log(extra);

            oldPosition = newPosition;
        }
    }
          
}
