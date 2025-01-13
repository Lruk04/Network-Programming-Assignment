using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCollider : MonoBehaviour{
    private void Awake() {
        PolygonCollider2D poly = GetComponent<PolygonCollider2D>();
        if(poly == null){
            poly = gameObject.AddComponent<PolygonCollider2D>();
        }
        // Vector2[] points = poly.points;
        // EdgeCollider2D edge = gameObject.AddComponent<EdgeCollider2D>();
        // edge.points = points;
        List<Vector2> points = new List<Vector2>();
        foreach (Vector2 p in poly.points)
            points.Add(p);

        points.Add(new Vector2(points[0].x, points[0].y));
        EdgeCollider2D edge = gameObject.AddComponent<EdgeCollider2D>();
        edge.points = points.ToArray();
        Destroy(poly);
    }
}