using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEditor.Events;
using UnityEngine.EventSystems;

public class MazePuzzleGenerator : MonoBehaviour
{

    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] float scale = 100;
    [SerializeField] GameObject prefabButton;
    [SerializeField] public GraphicRaycaster raycaster;
    [SerializeField] public EventSystem system;

    [SerializeField] GameObject mazePrefab;

    GameObject mazeObject;
    GameObject[,] buttonArray;

    //private UnityAction action;


    [System.Serializable]
    public class ButtonUnityEvent : UnityEvent<Button>
    {
        public int intParam;
    }



    public void Generate()
    {

        if (mazeObject == null) mazeObject = Instantiate(mazePrefab, this.transform); 
        MazePuzzle puzzle = mazeObject.GetComponent<MazePuzzle>();
        if (buttonArray != null)
        {
            for (int i = buttonArray.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = buttonArray.GetLength(1) - 1; j >= 0; j--)
                {
                    Debug.Log(i);
                    Debug.Log(j);
                    DestroyImmediate(buttonArray[i, j]);
                }
            }

            buttonArray = null;
        }
        else
        {
            buttonArray = new GameObject[width, height];

            for (int i = 0; i < buttonArray.GetLength(0); i++)
            {
                for (int j = 0; j < buttonArray.GetLength(1); j++)
                {

                    GameObject test = Instantiate(prefabButton, mazeObject.transform);
                    test.transform.localPosition = new Vector3(i*scale, j*scale, 0);


                    Button button = test.GetComponent<Button>();
                    UnityEventTools.AddObjectPersistentListener(button.onClick, puzzle.SelectButton, button);
                   // button.onClick.Pers(delegate { puzzle.SelectButton(button); } );
                  //  button.onClick.AddListener(delegate { Debug.Log("fea"); });
                    Debug.Log(button);
                    Debug.Log(mazeObject);
                    buttonArray[i, j] = test;
                    Debug.Log(buttonArray[i, j]);
                }
            }
        }

    }
}
