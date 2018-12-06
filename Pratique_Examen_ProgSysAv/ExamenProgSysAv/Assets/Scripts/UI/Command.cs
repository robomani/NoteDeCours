using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Command
{
    public string Name;
    public bool Enabled = true;
    public UnityAction action;
}
