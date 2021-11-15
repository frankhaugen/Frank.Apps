using System;
using System.Numerics;

namespace Frank.Apps.StarMap.Services;

public class Physics
{
    public Vector2 Trajectory(Vector2 origin, float instant, float launchAngle, float initialVelocity)
    {

        Vector2 vector2 = new Vector2(0, 0);

        vector2.X = CalculateHorizontalVelocity(instant, initialVelocity, launchAngle);
        vector2.Y = CalculateVerticalVelocity(instant, initialVelocity, launchAngle);
        return vector2;
    }
    public static float CalculateHorizontalVelocity(float instant, float initialVelocity, float launchAngle)
    {
        return initialVelocity * MathF.Cos(launchAngle) * instant;
    }
    public static float CalculateVerticalVelocity(float instant, float initialVelocity, float launchAngle)
    {
        return initialVelocity * MathF.Sin(launchAngle) * instant - 0.5F * 9.81F * instant * instant;
    }
}