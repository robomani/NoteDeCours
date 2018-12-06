using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class ListUtil
{
    public static T GetRandomElement<T>(this IEnumerable<T> list)
    {
        var array = list as T[] ?? list.ToArray();
        return array[Random.Range(0, array.Length)];
    }
}
