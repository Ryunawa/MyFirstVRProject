using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using  UnityEngine.XR.Interaction.Toolkit;

public class ContinuousMovement : MonoBehaviour
{
    public float speed = 1;
    public XRNode inputSource;

    private XROrigin _rig;
    private Vector2 inputAxis;
    public CharacterController _character;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        //Quaternion headYaw = Quaternion.Euler(0, _rig.Camera.transform.eulerAngles.y, 0);
        Vector3 direction = new Vector3(inputAxis.x, 0, inputAxis.y);
        _character.Move(direction * (Time.fixedDeltaTime * speed));
    }
}
