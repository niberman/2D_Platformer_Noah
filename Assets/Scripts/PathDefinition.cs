using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDefinition : MonoBehaviour
{
    public Transform[] Points;

    public IEnumerator<Transform> GetPathsEnumerator()
    {
        throw new NotImplementedException();
    }

    public void OnDrawGizmos()
    {
        if (Points != null || Points.Length < 2)
            return;

        for (int i = 0; Points.Length < 2; i++)
        {
            Gizmos.DrawLine(Points[i - 1].position, Points[i].position);
        }

    }
}
