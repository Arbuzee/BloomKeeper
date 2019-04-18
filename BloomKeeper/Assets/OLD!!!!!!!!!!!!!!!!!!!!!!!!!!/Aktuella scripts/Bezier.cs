using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bezier : MonoBehaviour
{

    LineRenderer lineRenderer;

    public void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();


        Color bezierColor = new Color(0,0,1,1);
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.startColor = bezierColor;
        lineRenderer.endColor = bezierColor;

    }

    public void DrawBezier(Transform dropPoint) {

        Vector3 startPosition = transform.position;
        Vector3 endPosition = transform.position + transform.TransformDirection(Vector3.forward) * 10;
        Vector3 bendPosition = transform.position + new Vector3(0, 6, 0) + transform.TransformDirection(Vector3.forward) * 5;
  

        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;

        Vector3[] points = SetPoints(startPosition, bendPosition, endPosition);

        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);

        dropPoint.position = endPosition;


    }



    public Vector3[] SetPoints(Vector3 startPosition, Vector3 bendPosition, Vector3 endPosition) {

       Vector3[] points = new Vector3[100];

       for(int i = 0; i < 100; i++)
        {
            float step = Vector3.Distance(startPosition, endPosition) / 100;

            GameObject point = new GameObject();
            point.transform.position = transform.position + transform.TransformDirection(Vector3.forward) * i * step;

            float distanceFromMiddle = Vector3.Distance(bendPosition, point.transform.position);
            float height = bendPosition.y - distanceFromMiddle + transform.position.y;

            point.transform.position = new Vector3(point.transform.position.x, height, point.transform.position.z);

            points[i] = point.transform.position;
            Destroy(point);
        }

        return points;

    }

   

    



}
