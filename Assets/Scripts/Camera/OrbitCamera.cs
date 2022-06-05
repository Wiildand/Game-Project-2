using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(CinemachineFreeLook))]
public class OrbitCamera : MonoBehaviour
{
    public GameObject scene;
    private CinemachineFreeLook _freelookCamera;
    public  GlobalProvider _globalProvider;
    // Start is called before the first frame update

    private string XAxisName = "Mouse X";
    private string YAxisName = "Mouse Y";
    void Start()
    {
        _freelookCamera = GetComponent<CinemachineFreeLook>();
        _freelookCamera.m_XAxis.m_InputAxisName = "";
        _freelookCamera.m_YAxis.m_InputAxisName = "";

        // set freelook camera to be scene transform without Y axis
        // create empty GameObject with same transform as scene
        GameObject target = new GameObject("Target");
        target.transform.position = new Vector3(scene.transform.position.x, 0, scene.transform.position.z);
        target.transform.rotation = scene.transform.rotation;
        target.transform.localScale = scene.transform.localScale;

        _freelookCamera.m_Follow = target.transform;
        _freelookCamera.m_LookAt = target.transform;


        // freelook settings
        // _freelookCamera.m_Orbits[i].m_Height = originalOrbits[i].m_Height * scale;
        // _freelookCamera.m_Orbits[i].m_Radius = originalOrbits[i].m_Radius * scale;

    
        // SUBCRIBE TO Event
        _globalProvider.mouse.scroll.performed += OnScroll;
        _globalProvider.mouse.dragEvent.AddListener(OnDrag);

    }

    private void OnScroll(CallbackContext context)
    {
        // // clamp between -1 and 1
        // float scroll = Mathf.Clamp(context.ReadValue<float>(), -1, 1);
        // _freelookCamera.m_Orbits[0].m_Height += scroll;
        // _freelookCamera.m_Orbits[1].m_Height += scroll;
        // _freelookCamera.m_Orbits[0].m_Radius += scroll;
        // _freelookCamera.m_Orbits[1].m_Radius += scroll;
        // _freelookCamera.m_Orbits[2].m_Radius += scroll;

    }

    void OnDrag(Vector2 delta)
    {


        _freelookCamera.m_XAxis.m_InputAxisValue = delta.x;
        _freelookCamera.m_YAxis.m_InputAxisValue = delta.y;

    }

}
