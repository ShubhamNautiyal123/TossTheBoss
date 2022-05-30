using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is responsible to handle ball related functionalities.
/// </summary>

public class MainBall : MonoBehaviour
{
    #region ToolTip 
    [TextArea]
    [Tooltip("Main Ball Script")]
    public string INFO = "This script is responsible to handle ball related functionalities.";
    #endregion
    #region Callback
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Land")
        {
            References.reference.dragAndRelease.mainBall.GetComponent<Rigidbody>().isKinematic = true;
            References.reference.dragAndRelease.isMoving = false;
            References.reference.dragAndRelease.draggingAllowed = false;
            References.reference.soundAndMusic.PlaySoundClip("Lose");
            References.reference.uiHandler.GameOver();
        }
        if (other.gameObject.tag == "Coin")
        {
            References.reference.soundAndMusic.PlaySoundClip("Coin");
            Destroy(other.gameObject);
            References.reference.uiHandler.ScoreCalculator(1000);
        }
       
    }

    #endregion

}
