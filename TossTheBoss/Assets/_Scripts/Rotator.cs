
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// To rotate objects
/// </summary>
public class Rotator : MonoBehaviour
{
    #region Reference
    float smoothness = 50;
    #endregion
    #region Callback  
    private void Update()
    {
        transform.Rotate(new Vector3(0,0,Time.deltaTime*smoothness));
    }
    #endregion
    
}
