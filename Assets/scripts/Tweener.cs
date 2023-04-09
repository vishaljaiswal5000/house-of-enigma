using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private List<Tween> activeTweens = new List<Tween>();

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < activeTweens.Count; i++)
        {
            if (activeTweens[i] != null)
            {
                //between vector A and B
                float distance = Vector3.Distance(activeTweens[i].Target.position, activeTweens[i].EndPos);

                //Time passed after tween added
                float timeSinceStarted = Time.time - activeTweens[i].StartTime;

                // Distance already moved 
                float completed = timeSinceStarted / activeTweens[i].Duration;

                if (completed < 1)
                {
                    activeTweens[i].Target.anchoredPosition = Vector3.Lerp(activeTweens[i].StartPos, activeTweens[i].EndPos, EaseIn(completed));
                }
                else
                {
                    activeTweens[i].Target.anchoredPosition = activeTweens[i].EndPos;
                    activeTweens.Remove(activeTweens[i]);

                }
            }
        }
    }


    public bool AddTween(RectTransform targetObject, Vector3 startPos, Vector3 endPos, float Duration)
    {
        if (!TweenExists(targetObject))
        {
            activeTweens.Add(new Tween(targetObject, startPos, endPos, Time.time, Duration));
            return true;
        }

        return false;
    }

    public float EaseIn(float t)
    {
        return t * t * t;
    }

    public bool TweenExists(RectTransform target)
    {
        // Linq instead of loop
        Tween tween = activeTweens.Find(x => x.Target == target);

        if (tween != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
