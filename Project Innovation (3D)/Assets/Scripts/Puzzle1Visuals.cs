using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Visuals : MonoBehaviour
{

    [SerializeField] Puzzle1 puzzle;

    [SerializeField] float spacing;
    [SerializeField] GameObject prefab;
    public void Start()
    {
        bool[,] lights = puzzle.getLightsCorrect();

        for(int i = 0; i < lights.GetLength(0); i++)
        {
            for(int j = 0; j < lights.GetLength(1); j++)
            {
               Vector3 localPos = new Vector3(i * spacing, j * spacing, 0);
                Debug.Log("test");
                GameObject ob = Instantiate(prefab, localPos, Quaternion.identity, this.transform);

                ob.GetComponent<OnOffObject>().Setup(true, new Vector2Int(i,j), puzzle);
            }
        }
    }
}
