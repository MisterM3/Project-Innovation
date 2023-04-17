using shared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
   [SerializeField] bool[,] lightsCorrect;
    bool[,] lightNow;

    [SerializeField] int amountHor;
    [SerializeField] int amountVer;


    public void Awake()
    {
        lightsCorrect = new bool[amountHor, amountVer];
        lightNow = new bool[amountHor, amountVer];

        for (int i = 0; i < amountHor; i++)
        {
            for (int j = 0; j < amountVer; j++)
            {

                int randomInt = Random.Range(0, 2);

                lightsCorrect[i,j] = (randomInt == 0? true: false);

                lightNow[i, j] = true;
            }
        }

        foreach(bool light in lightsCorrect)
        {
            Debug.Log(light);
        }
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Y))
        {
            PuzzleOneSetup setup = new PuzzleOneSetup();
            setup.name = "light";
            setup.lightBool = lightsCorrect;

            TCPChatClient1.Instance.sendMessage(setup);

            Debug.Log("fafeafa");
        }
    }


    public bool[,] getLightsCorrect()
    {
        return lightsCorrect;
    }


    public void ChangeLight(Vector2Int position, bool isOn)
    {
        lightNow[position.x, position.y] = isOn;
        if (CheckLight()) Debug.LogWarning("FAEFA");
    }

    public bool CheckLight()
    {
        for (int i = 0; i < amountHor; i++)
        {
            for (int j = 0; j < amountVer; j++)
            {
                if (lightsCorrect[i, j] != lightNow[i, j])
                {
                    Debug.Log(i + " " + j);
                    return false;
                }
            }
        }

        return true;
    }


    public void SendCorrectLight()
    {

    }
}
