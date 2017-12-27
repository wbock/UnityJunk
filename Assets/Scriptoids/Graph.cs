﻿using UnityEngine;

public class Graph : MonoBehaviour
{

    public Transform pointPrefab;
    [Range(10, 100)] public int resolution = 10;

    Transform[] points;

    void Start()
    {
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        position.y = 0f;
        position.z = 0f;
		points = new Transform[resolution];

        for (int i = 0; i < resolution; i++)
        {
            Transform point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false); //Set point as child of graph
            points[i] = point;
        }
    }

    void Update()
    {
        for (int i = 0; i < points.Length; i++) {
			Transform point = points[i];
			Vector3 position = point.localPosition;
			position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time)) + 0.5f;
			point.localPosition = position;
		}
		//Debug.Log(points[0].localPosition + " " + points[resolution-1].localPosition);
    }
}