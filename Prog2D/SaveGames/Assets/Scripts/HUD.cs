using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private Slider m_HPSlider;

    private void Start()
    {
        EventManager.Instance.RegisterEvent(EventID.UpdateHP, OnUpdateHP);
    }

    private void OnUpdateHP(object i_Arg)
    {
        m_HPSlider.value = (float)i_Arg;
    }
}
