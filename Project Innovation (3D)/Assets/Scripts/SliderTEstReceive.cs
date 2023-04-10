using shared;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SliderTEstReceive : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) SendSolution();
    }

    public void SendSolution()
    {
        SliderSolution solution =  new SliderSolution();
        solution.name = "SliderOne";
        solution.value1 = 2;
        solution.value2 = 0;
        solution.value3 = 7;

        TCPChatClient1.Instance.sendMessage(solution);
    }
}
