using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script contains all the references
/// </summary>
public class References : MonoBehaviour
{
    #region ToolTip  
    [TextArea]
    public string INFO = "This script contains all the references";
    #endregion
    #region Static Reference
    public static References reference;
    #endregion
    #region Public References 
    public UIHandler uiHandler;
    public DragAndRelease dragAndRelease;
    public SoundAndMusic soundAndMusic;
    #endregion
    #region Callback
    private void Awake()
    {
        if (reference == null)
            reference = this;
        else
            Destroy(this.gameObject);
    }
    #endregion
}
