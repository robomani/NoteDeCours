using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookUserInput : MonoBehaviour
{
    private CinemachineFreeLook m_FreeLookCam;
	
	private void Start ()
    {
        m_FreeLookCam = GetComponent<CinemachineFreeLook>();
	}


    private void Update ()
    {
        m_FreeLookCam.m_XAxis.m_InputAxisValue = Input.GetAxisRaw("Horizontal2");
        m_FreeLookCam.m_YAxis.m_InputAxisValue = Input.GetAxisRaw("Vertical2");
	}
}
