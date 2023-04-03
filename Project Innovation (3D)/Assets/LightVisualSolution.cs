using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightVisualSolution : MonoBehaviour
{
    [SerializeField] Puzzle1 puzzle;

    [SerializeField] float spacing;
    [SerializeField] GameObject prefabOn;
    [SerializeField] GameObject prefabOff;
    public void Start()
    {
        bool[,] lights = puzzle.getLightsCorrect();

        for (int i = 0; i < lights.GetLength(0); i++)
        {
            for (int j = 0; j < lights.GetLength(1); j++)
            {
                Vector3 localPos = new Vector3(i * spacing - 10, j * spacing, 0);
                Debug.Log("test");
                if (lights[i,j]) Instantiate(prefabOn, localPos, Quaternion.identity, this.transform);
                else Instantiate(prefabOff, localPos, Quaternion.identity, this.transform);

            }
        }
    }
}
