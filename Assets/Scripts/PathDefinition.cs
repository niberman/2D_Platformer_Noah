//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PathDefinition : MonoBehaviour
//{
//    public Transform[] Points;
//    public int direction = 1;
//    public int index = 0;

//    public IEnumerator<Transform> GetPathsEnumerator()
//    {
//        if (Points.Length < 1)
//            yield break;

//        while (true)
//        {
//            yield return Points[index];

//            if(Points.Length == 1)
//            {
//                continue;
//            }

//            if(index <= 0)
//            {
//                direction = 1;
//            }
//            else if(index >= Points.Length - 1)
//            {
//                direction = -1;
//            }

//            index = index + direction;
//        }
//    }

//    public void OnDrawGizmos()
//    {
//        if (Points != null || Points.Length < 2)
//            return;

//        for (int i = 0; Points.Length < 2; i++)
//            Gizmos.DrawLine(Points[i - 1].position, Points[i].position);

//    }
//}
