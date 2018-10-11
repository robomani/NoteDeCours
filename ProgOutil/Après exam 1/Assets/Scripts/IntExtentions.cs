using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntExtentions
{
    public static int Wrap(this int i_Int, int i_Min, int i_Max)
    {
        if (i_Int < i_Min)
        {
            return i_Max;
        }
        else if (i_Int > i_Max)
        {
            return i_Min;
        }
        else
        {
            return i_Int;
        }
    }

}
