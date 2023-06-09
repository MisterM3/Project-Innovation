using shared;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MazePuzzle : MonoBehaviour
{
    [SerializeField] private Button startButton = null;
    [SerializeField] private Button endButton = null;
    [SerializeField] private List<Button> hazardButtons = new List<Button>();

    [SerializeField] private string networkEventName;

    private LineRenderer lineRenderer = null;
    private List<Button> selectedButtons = new List<Button>();
    private Button selectedButton = null;
    private Button previousButton = null;

    private bool isDone = false;
    private bool isOtherDone = false;

    [SerializeField] Vector3 offSet;

    public UnityEvent bothMazeDoneUEvent;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.sortingOrder = 1;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.material.color = Color.blue;
    }

    public void SelectButton(Button button)
    {
        //Do nothing if puzzle is finished
        if (isDone)
            return;

        //If the selectedButton is null it means the puzzle has not started yet so the startButton has to be the one that was pressed first
        if (selectedButton == null)
        {
            if (button == startButton)
            {
                selectedButton = button;
                selectedButtons.Add(button);
                UpdateLines();
            }
            else
                return;
        }
        else
        {

            previousButton = selectedButton;

            //Check if the pressed button is not diagonal from the previous button in the sequence and if it is not already in the sequence
            if (button.transform.localPosition.x == previousButton.transform.localPosition.x ^
            button.transform.localPosition.y == previousButton.transform.localPosition.y)
            {
                selectedButton = button;
                selectedButtons.Add(button);
                UpdateLines();

                //Check if the pressed button is the final button, at this point we check if it is right or wrong
                if (button == endButton)
                {
                    if (!CorrectSequenceCheck())
                        ResetPuzzle();
                    else
                        WinCondition();
                }
            }
        }
    }

    /// <summary>
    /// Updates lineRenderer lines in the sequence of buttons
    /// </summary>
    private void UpdateLines()
    {
        Vector3 position = new Vector3();
        lineRenderer.positionCount = selectedButtons.Count;

        position = selectedButtons[selectedButtons.Count - 1].gameObject.transform.localPosition + offSet;

        lineRenderer.useWorldSpace = false;

        lineRenderer.SetPosition(selectedButtons.Count - 1, position);

    }

    //Simple bool that checks if the sequence is correct
    private bool CorrectSequenceCheck()
    {
        //check if the sequence of buttons contains a hazardButton
        foreach (Button item in hazardButtons)
        {
            if (selectedButtons.Contains(item))
                return false;
        }

        //check inbetween each button in the sequence if there is a hazard tile in the way
        for (int i = 0; i < selectedButtons.Count; i++)
        {
            if (i + 1 >= selectedButtons.Count)
                break;

            Vector2 position1 = selectedButtons[i].transform.localPosition;
            Vector2 position2 = selectedButtons[i + 1].transform.localPosition;

            foreach (Button item in hazardButtons)
            {
                if (item.transform.localPosition.y == position1.y && item.transform.localPosition.y == position2.y)
                {
                    if (item.transform.localPosition.x > position1.x && item.transform.localPosition.x < position2.x ||
                        item.transform.localPosition.x < position1.x && item.transform.localPosition.x > position2.x)
                    {
                        return false;
                    }

                }

                if (item.transform.localPosition.x == position1.x && item.transform.localPosition.x == position2.x)
                { 
                    if (item.transform.localPosition.y > position1.y && item.transform.localPosition.y < position2.y ||
                        item.transform.localPosition.y < position1.y && item.transform.localPosition.y > position2.y)
                    {
                        return false;
                    }

                }
            }
        }

        return true;
    }


    /// <summary>
    /// Resets puzzle
    /// </summary>
    private void ResetPuzzle()
    {
        selectedButtons.Clear();
        lineRenderer.positionCount = 0;
        previousButton = null;
        selectedButton = null;
    }

    /// <summary>
    /// Called when puzzle is completed correctly
    /// </summary>
    private void WinCondition()
    {
        isDone = true;
        Debug.Log("do things");

        ChatMessage message = new ChatMessage();
        message.name = networkEventName;
        message.message = "done";

        TCPChatClient1.Instance.sendMessage(message);
        Debug.Log("doneOne");

        if (isOtherDone)
        {
            bothMazeDoneUEvent?.Invoke();
        }

    }

    public void OtherDone()
    {
        Debug.Log("testfeafaf");
        isOtherDone = true;
        if (isDone)
        {
            bothMazeDoneUEvent?.Invoke();
        }
    }

}
