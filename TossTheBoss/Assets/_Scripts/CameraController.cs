using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is responsible to handle the camera according to the target object
/// </summary>


public class CameraController : MonoBehaviour
{
    #region ToolTip 
    [TextArea]
    [Tooltip("Camera Script")]
    public string INFO = "This script is responsible to handle the camera according to the target object";
    #endregion

    #region References 
    public GameObject mainBall;
    public GameObject mainCamera;
    public float yOffset;
    #endregion

    #region Callback
    private void Update()
    {
       
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainBall.transform.position.y, mainCamera.transform.position.z)  + new Vector3(0, yOffset, 0);
        mainCamera.transform.LookAt(mainBall.transform.position);
    }
    #endregion
}
