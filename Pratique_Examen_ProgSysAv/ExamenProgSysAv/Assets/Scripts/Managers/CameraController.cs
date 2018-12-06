using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public Transform m_Character;

    public float m_MinimumX;
    public float m_MaximumX;

    public float m_MinimumY;
    public float m_MaximumY;

    private Camera m_Camera;

    private float m_Width;
    private float m_Height;

    // Use this for initialization
    void Start ()
    {
        m_Camera = GetComponent<Camera>();

        Vector3 bottomLeft = m_Camera.ScreenToWorldPoint(Vector3.zero);
        Vector3 topRight = m_Camera.ScreenToWorldPoint(new Vector3(m_Camera.pixelWidth, m_Camera.pixelHeight));

        m_Width = Mathf.Abs((bottomLeft - topRight).x);
        m_Height = Mathf.Abs((bottomLeft - topRight).y);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 targetPosition = m_Character.position - Vector3.forward * 5;
        float xMin = m_MinimumX + m_Width / 2;
        float xMax = m_MaximumX - m_Width / 2;
        float yMin = m_MinimumY + m_Height / 2;
        float yMax = m_MaximumY - m_Height / 2;
        targetPosition.x = Mathf.Clamp(targetPosition.x, xMin, xMax);
        targetPosition.y = Mathf.Clamp(targetPosition.y, yMin, yMax);

        transform.position = targetPosition;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(m_MinimumX, m_MinimumY), new Vector3(m_MinimumX, m_MaximumY));

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(m_MaximumX, m_MinimumY), new Vector3(m_MaximumX, m_MaximumY));

        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(m_MinimumX, m_MinimumY), new Vector3(m_MaximumX, m_MinimumY));

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(m_MinimumX, m_MaximumY), new Vector3(m_MaximumX, m_MaximumY));


        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(m_Width, m_Height));
    }
}
