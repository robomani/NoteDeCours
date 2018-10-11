using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListeExtensions
{
    public static T Random<T>(this List<T> i_List)
    {
        if (i_List != null && i_List.Count > 0)
        {
            return i_List[UnityEngine.Random.Range(0, i_List.Count)];
        }

        return default(T);
    }

    public static T RandomRemove<T>(this List<T> i_List, List<T> i_Source)
    {
        if (i_List != null && i_List.Count > 0)
        {
            int random = UnityEngine.Random.Range(0, i_List.Count);
            T temp = i_List[random];
            i_List.Remove(temp);
            if (i_List.Count == 0)
            {
                i_List = new List<T>(i_Source);
            }

            return temp;
        }

        return default(T);
    }
}
