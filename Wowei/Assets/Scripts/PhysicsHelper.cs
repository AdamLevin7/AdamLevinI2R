using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PhysicsHelper
{
    /// <summary>
    /// Gets the angle the vector is pointing at based on what its z rotation would be.
    /// </summary>
    public static float ToAngle(this Vector2 direction)
    {
        float angle = Mathf.Atan(-direction.x / direction.y) * 180 / Mathf.PI;
        if (angle < 0)
            angle += 180;
        if (direction.x > 0)
            angle += 180;
        if (direction.y < 0 && angle < 90)
            angle += 180;
        return angle;
    }

    /// <summary>
    /// Gets a vector of magnitude 1 that is pointing in the direction of the specified angle.
    /// </summary>
    public static Vector2 ToDirection(this float angle)
    {
        float radAngle = angle * Mathf.PI / 180;
        return new Vector2(Mathf.Sin(radAngle), -Mathf.Cos(radAngle));
    }
}
