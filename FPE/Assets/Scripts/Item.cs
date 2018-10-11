using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity
{
    common,
    uncommon,
    rare,
    unique,
}

public class Item : MonoBehaviour
{
    public Rarity m_Rarity = Rarity.common;
}
