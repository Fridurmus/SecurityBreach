using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SightCone))]
public class SightConeEditor : Editor {

	void OnSceneGUI()
    {
        SightCone sightCone = (SightCone)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(sightCone.transform.position, Vector3.up, Vector3.forward, 360, sightCone.viewRadius);
        Vector3 maxViewAngleA = sightCone.DirFromAngle(-sightCone.maxViewAngle * 0.5f, false);
        Vector3 maxViewAngleB = sightCone.DirFromAngle(sightCone.maxViewAngle * 0.5f, false);

        Vector3 minViewAngleA = sightCone.DirFromAngle(-sightCone.minViewAngle * 0.5f, false);
        Vector3 minViewAngleB = sightCone.DirFromAngle(sightCone.minViewAngle * 0.5f, false);

        Handles.color = Color.blue;
        Handles.DrawLine(sightCone.transform.position, sightCone.transform.position + maxViewAngleA * sightCone.viewRadius);
        Handles.DrawLine(sightCone.transform.position, sightCone.transform.position + maxViewAngleB * sightCone.viewRadius);

        Handles.color = Color.cyan;
        Handles.DrawLine(sightCone.transform.position, sightCone.transform.position + minViewAngleA * sightCone.viewRadius);
        Handles.DrawLine(sightCone.transform.position, sightCone.transform.position + minViewAngleB * sightCone.viewRadius);

        Handles.color = Color.red;
        foreach(Transform visibleTarget in sightCone.visibleTargets)
        {
            Handles.DrawLine(sightCone.transform.position, visibleTarget.position);
        }
    }
}
