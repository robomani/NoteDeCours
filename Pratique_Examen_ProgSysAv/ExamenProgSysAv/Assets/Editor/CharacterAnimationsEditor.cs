using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System;


[CustomEditor(typeof(CharacterAnimations), true)]
[InitializeOnLoad]
public class CharacterAnimationsEditor : Editor
{
    public override bool RequiresConstantRepaint()
    {
        return true;
    }
}