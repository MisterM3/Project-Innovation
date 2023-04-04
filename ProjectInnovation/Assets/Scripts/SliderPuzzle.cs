using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPuzzle : MonoBehaviour
{
    [SerializeField] private List<Slider> sliders = new List<Slider>();
    [SerializeField] private List<int> correctValues = new List<int>();

    private void Start()
    {
        foreach (var item in sliders)
        {
            item.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        }
    }

    // Called when value of a slider changes
    public void ValueChangeCheck()
    {
        if (CheckSequence())
            WinCondition();
    }

    /// <summary>
    /// Compares values of sliders.value and correct value lists
    /// </summary>
    /// <returns></returns>
    private bool CheckSequence()
    {
        for (int i = 0; i < sliders.Count; i++)
        {
            if (sliders[i].value != correctValues[i])
                return false;
        }
        return true;
    }

    /// <summary>
    /// Called when puzzle is completed correctly
    /// </summary>
    private void WinCondition()
    {
        foreach (var item in sliders)
        {
            item.interactable = false;
        }
    }
}
