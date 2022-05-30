using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Pivot point holder script
/// </summary>
public class HolderCollision : MonoBehaviour
{

    #region Callback
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Draggable")
        {
            References.reference.dragAndRelease.mainBall.transform.SetParent(other.transform);
        }
        else if (other.gameObject.tag == "Breakable")
        {
            StartCoroutine(References.reference.dragAndRelease.SettingMovemetTrue());
            References.reference.dragAndRelease.holder.SetActive(false);
            References.reference.dragAndRelease.mainBall.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(other.gameObject);
        }

    }
    
    #endregion
}
