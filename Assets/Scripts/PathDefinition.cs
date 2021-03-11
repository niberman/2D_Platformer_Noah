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
        if (Points = null || Points < 1)
        {
            return;
        }
        foreach(var i in Points; i = 1; i++)
        {
            Gizmos.DrawLine(Points[i - 1].position, Points[i].position);
        }

    }
}
