using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mandelbulb : MonoBehaviour
{
    public static bool isInMandelbulb(Vector3Int pos, int w, int h, int d, int limit, int powScale)
    {
        float x = map(pos.x, 0, w-1, -1, 1);
        float y = map(pos.y, 0, h-1, -1, 1);
        float z = map(pos.z, 0, d-1, -1, 1);

        Vector3 zeta = new Vector3(0, 0, 0);
        while(limit > 0)
        {
            float rad = Mathf.Sqrt(zeta.x * zeta.x + zeta.y * zeta.y + zeta.z * zeta.z);
            float theta = Mathf.Atan2(Mathf.Sqrt(zeta.x * zeta.x + zeta.y * zeta.y), zeta.z);
            float phi = Mathf.Atan2(zeta.y, zeta.x);
            if (rad > 2) return false;

            float scaledRad = Mathf.Pow(rad,powScale);
            float scaledTheta = theta * powScale;
            float scaledPhi = phi * powScale;

            float newx = scaledRad * Mathf.Sin(scaledTheta) * Mathf.Cos(scaledPhi);
            float newy = scaledRad * Mathf.Sin(scaledTheta) * Mathf.Sin(scaledPhi);
            float newz = scaledRad * Mathf.Cos(scaledTheta);

            zeta.x = newx + x;
            zeta.y = newy + y;
            zeta.z = newz + z;
            limit--;
            
        }
        return true;
    }
    public static float map(float value, float fmin, float fmax, float tmin, float tmax)
    {
        return (value - fmin) * (tmax - tmin) / (fmax - fmin) + tmin;
    }
}
