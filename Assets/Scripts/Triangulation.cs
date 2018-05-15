using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Triangulation
{
    public static List<Vector2> GetVertices(List<Vector2> points)
    {
        var results = new List<Vector2>();
        var allPoints = new List<P>(points.Count);
        var checkPoints = new List<P>();
        for (int j = points.Count - 1; j >= 0; j--)
        {
            var a = points[(j + points.Count - 1) % points.Count];
            var b = points[j];
            var c = points[(j + 1) % points.Count];
            var p = new P { x = b.x, y = b.y };
            allPoints.Insert(0, p);
            if (GetClockwiseCoef(a.x - b.x, a.y - b.y, c.x - b.x, c.y - b.y) < 0f)
                checkPoints.Add(p);
        }
        for (int j = allPoints.Count - 1; j >= 0; j--)
        {
            var a = allPoints[(j + allPoints.Count - 1) % allPoints.Count];
            var b = allPoints[j];
            var c = allPoints[(j + 1) % allPoints.Count];
            if (GetClockwiseCoef(a.x - b.x, a.y - b.y, c.x - b.x, c.y - b.y) > 0f && !TriangleStrictlyAnyContains(a, b, c, checkPoints))
            {
                results.AddRange(new[] { new Vector2(a.x, a.y), new Vector2(b.x, b.y), new Vector2(c.x, c.y) });
                Remove(allPoints, j);
                j = allPoints.Count - 1;
            }
        }
        return results;
    }

    private static void Remove(List<P> p, int index)
    {
        p[index].needRemove = true;
        p.RemoveAt(index);
    }

    private class P
    {
        public float x;
        public float y;
        public bool needRemove;
    }

    private static float GetClockwiseCoef(float x1, float y1, float x2, float y2)
    { return Mathf.Sign(x1 * y2 - y1 * x2); }

    private static bool TriangleStrictlyAnyContains(P a, P b, P c, List<P> points)
    {
        if (points.Count == 0)
            return false;
        var ky1 = (b.y - a.y);
        var ky2 = (c.y - b.y);
        var ky3 = (a.y - c.y);
        var kx1 = (b.x - a.x);
        var kx2 = (c.x - b.x);
        var kx3 = (a.x - c.x);
        for (int i = 0; i < points.Count; i++)
        {
            var point = points[i];
            if (point.needRemove)
            {
                points.RemoveAt(i--);
                continue;
            }

            var a1 = (a.x - point.x) * ky1 - kx1 * (a.y - point.y);
            var b1 = (b.x - point.x) * ky2 - kx2 * (b.y - point.y);
            var c1 = (c.x - point.x) * ky3 - kx3 * (c.y - point.y);
            if ((a1 < 0 && b1 < 0 && c1 < 0) || (a1 > 0 && b1 > 0 && c1 > 0))
                return true;
        }
        return false;
    }
}