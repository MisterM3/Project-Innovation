using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{

    [SerializeField] int amountSides = 4;

    [SerializeField] int currentSide = 0;

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

            Debug.Log(this.transform.localRotation.eulerAngles.x);
            
            if (this.transform.localRotation.x < .5f && this.transform.localRotation.x > 0) currentSide = 0;
            if (this.transform.localRotation.x < 1.0f && this.transform.localRotation.x > .5f) currentSide = 1;
            if (this.transform.localRotation.x < 0 && this.transform.localRotation.x > -0.5f) currentSide = 2;
            if (this.transform.localRotation.x < -0.5f  || this.transform.localRotation.x > -1.0f) currentSide = 3;
        }
    }
          
}
