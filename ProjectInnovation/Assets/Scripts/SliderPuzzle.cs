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

    public void ValueChangeCheck()
    {
        if (CheckSequence())
            WinCondition();
    }

    private bool CheckSequence()
    {
        for (int i = 0; i < sliders.Count; i++)
        {
            if (sliders[i].value != correctValues[i])
                return false;
        }
        return true;
    }

    private void WinCondition()
    {
        foreach (var item in sliders)
        {
            item.interactable = false;
        }
    }
}
