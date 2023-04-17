using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnOffObject : MonoBehaviour
{



    [SerializeField] UnityEvent onLightOn;
    [SerializeField] UnityEvent onLightOff;
    [SerializeField] EventHandler<bool> onLightChange;
    [SerializeField] bool lightOn;
    [SerializeField] Puzzle1 puzzle;

    public Vector2Int position;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lightOn = !lightOn;

            if (lightOn) onLightOn?.Invoke();
            else onLightOff?.Invoke();

            onLightChange?.Invoke(this, lightOn);
            puzzle.ChangeLight(position, lightOn);

        }
    }


    public void Setup(bool isOn, Vector2Int position, Puzzle1 puzzle)
    {
        lightOn = isOn;
        this.position = position;
        this.puzzle = puzzle;
    }
}
