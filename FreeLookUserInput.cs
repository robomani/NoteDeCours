using Cinemachine;
using UnityEngine;
[RequireComponent(typeof(CinemachineFreeLook))]
public class FreeLookUserInput : MonoBehaviour 
{
    private CinemachineFreeLook m_FreeLookCam;
    
    private void Start () 
	{
        m_FreeLookCam = GetComponent<CinemachineFreeLook>();

    }

    private void LateUpdate () 
	{
        m_FreeLookCam.m_XAxis.m_InputAxisValue = Input.GetAxisRaw("Horizontal2");
        m_FreeLookCam.m_YAxis.m_InputAxisValue = Input.GetAxisRaw("Vertical2");
		//Debug.Log(Input.GetAxisRaw("Vertical2"));
		//Debug.Log(Input.GetAxisRaw("Horizontal2"));
    }
}