using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazePuzzle : MonoBehaviour
{
    [SerializeField] private Button startButton = null;
    [SerializeField] private Button endButton = null;
    [SerializeField] private List<Button> hazardButtons = new List<Button>();

    private LineRenderer lineRenderer = null;
    private List<Button> selectedButtons = new List<Button>();
    private Button selectedButton = null;
    private Button previousButton = null;

    private bool isDone = false;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.sortingOrder = 1;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.material.color = Color.blue;
    }

    public void SelectButton(Button button)
    {
        if (isDone)
            return;

        if (selectedButton == null)
        {
            if (button == startButton)
            {
                selectedButton = button;
                selectedButtons.Add(button);
            }
            else
                return;
        }
        else
        {

            previousButton = selectedButton;

            if (button.transform.position.x == previousButton.transform.position.x ^
                button.transform.position.y == previousButton.transform.position.y &&
                !selectedButtons.Contains(button))
            {
                selectedButton = button;
                selectedButtons.Add(button);
                UpdateLines();
            }

            if (button == endButton)
            {
                if (!CorrectSequenceCheck())
                    ResetPuzzle();
                else
                    WinCondition();
            }
            
        }
    }

    private void UpdateLines()
    {
        Vector3[] positions = new Vector3[selectedButtons.Count];

        for (int i = 0; i < selectedButtons.Count; i++)
        {
            positions[i] = selectedButtons[i].gameObject.transform.position;
        }
        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
    }

    private bool CorrectSequenceCheck()
    {
        foreach (Button item in hazardButtons)
        {
            if (selectedButtons.Contains(item))
                return false;
        }

        for (int i = 0; i < selectedButtons.Count; i++)
        {
            if (i + 1 >= selectedButtons.Count)
                break;

            Vector2 position1 = selectedButtons[i].transform.position;
            Vector2 position2 = selectedButtons[i + 1].transform.position;

            foreach (Button item in hazardButtons)
            {
                if (item.transform.position.y == position1.y && item.transform.position.y == position2.y)
                {
                    if (item.transform.position.x > position1.x && item.transform.position.x < position2.x ||
                        item.transform.position.x < position1.x && item.transform.position.x > position2.x)
                    {
                        return false;
                    }

                }
                
                if (item.transform.position.x == position1.x && item.transform.position.x == position2.x)
                {
                    if (item.transform.position.y > position1.y && item.transform.position.y < position2.y ||
                        item.transform.position.y < position1.y && item.transform.position.y > position2.y)
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    private void ResetPuzzle()
    {
        selectedButtons.Clear();
        lineRenderer.positionCount = 0;
        previousButton = null;
        selectedButton = null;
    }
    private void WinCondition()
    {
        isDone = true;
        Debug.Log("do things");
    }


}
