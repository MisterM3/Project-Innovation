using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[CustomEditor(typeof(MazePuzzleGenerator))]
public class MazeGeneratorEditor : Editor
{ 
    public override void OnInspectorGUI()
    {
        MazePuzzleGenerator generator = target as MazePuzzleGenerator;

        base.OnInspectorGUI();
        if (GUILayout.Button("Generate"))
        {
            generator.Generate();
        }
    }

    public void OnSceneGUI()
    {
        MazePuzzleGenerator generator = target as MazePuzzleGenerator;
        Event e = Event.current;
        if (e.type == EventType.KeyUp && e.keyCode == KeyCode.S)
        {
         //   Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

            Debug.Log("ea");
          //  RaycastHit hit;

            PointerEventData m_PointerEventData = new PointerEventData(generator.system);
            //Set the Pointer Event Position to that of the mouse position

            List<RaycastResult> results = new List<RaycastResult>();
            m_PointerEventData.position = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
            Debug.Log(GUIUtility.GUIToScreenPoint(Event.current.mousePosition));
            generator.raycaster.Raycast(m_PointerEventData, results);
            Debug.Log(results.Count);
            foreach(RaycastResult result in results) 
            {
                Debug.Log(result.gameObject.name);
            }
        }
    }
}
