using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpriteUtil
{
    public static Coroutine AnimateColor(this MonoBehaviour target, Color from, Color to, float duration)
    {
        return target.StartCoroutine(AnimateColorInternal(target, from, to, duration));
    }

    private static IEnumerator AnimateColorInternal(this MonoBehaviour target, Color from, Color to, float duration)
    {
        var targetRenderer = target.GetComponentInChildren<SpriteRenderer>();

        for (float cooldown = 0; cooldown < duration; cooldown += Time.deltaTime)
        {
            targetRenderer.color = Color.Lerp(from, to, cooldown / duration);
            yield return null;
        }

        targetRenderer.color = to;
    }
}
