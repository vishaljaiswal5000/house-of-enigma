using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween
{
    public RectTransform Target { get; private set; }

    public Vector3 StartPos { get; private set; }

    public Vector3 EndPos { get; private set; }

    public float StartTime { get; private set; }

    public float Duration { get; private set; }

    public Tween(RectTransform targetObject, Vector3 startPos, Vector3 endPos, float startTime, float duration)
    {
        this.Target = targetObject;
        this.StartPos = startPos;
        this.EndPos = endPos;
        this.StartTime = startTime;
        this.Duration = duration;
    }
}
