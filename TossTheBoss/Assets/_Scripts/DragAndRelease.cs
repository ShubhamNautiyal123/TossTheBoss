
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// This script is responsible to handle drag and release operations.
/// </summary>

public class DragAndRelease :MonoBehaviour,  IBeginDragHandler, IDragHandler, IEndDragHandler
{
    #region ToolTip 
    [TextArea]
    public string INFO = "This script is responsible to handle drag and release operations.";
    #endregion
    #region References 
    
    public Rigidbody mainBall;
    public Transform mainBallRotatingPart;
    [HideInInspector]
    public bool draggingAllowed;
    public bool isMoving;
    public GameObject holder;
    public int maxDistanceToReach;
    public Transform mainParent;


    Vector3 initialPosition;
    Vector3 draggingPosition;
    Vector3 finalPosition;
    bool gameWonTriggered;
    float scoreValue;
    #endregion
    #region Callbacks
    private void Update()
    {

        if (mainBall.GetComponent<Rigidbody>().velocity.magnitude > 0) {

            mainBallRotatingPart.Rotate(new Vector3(1, 1, 1));

        }
        if (mainBall.transform.localPosition.y >= maxDistanceToReach && !gameWonTriggered)
        {
            gameWonTriggered = true;
            mainBall.GetComponent<Rigidbody>().isKinematic = true;
            isMoving = false;
            draggingAllowed = false;
            References.reference.soundAndMusic.PlaySoundClip("Win");
            References.reference.uiHandler.GameWin();
        }

        if (Input.GetMouseButton(0))
        {
            
                if (isMoving ){
                mainBall.GetComponent<Rigidbody>().isKinematic = true;
                isMoving = false;
                holder.SetActive(true);
                References.reference.soundAndMusic.PlaySoundClip("Landing");
                References.reference.uiHandler.ScoreCalculator(scoreValue);
                scoreValue = 0;
            }
           
        
        }
       
    }

   
    public void OnBeginDrag(PointerEventData eventData)
    {
       initialPosition=Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        draggingPosition = Input.mousePosition;
        if (initialPosition.y - draggingPosition.y > 0){
            draggingAllowed = true;
        }

        else{
            draggingAllowed = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!draggingAllowed)
            return;

        finalPosition = Input.mousePosition;

        float deltaPosition= initialPosition.y - finalPosition.y;
         
        if (deltaPosition < 10)
            return;

        if (deltaPosition > 700)
            deltaPosition = 700;

        ForceCalculator(deltaPosition);

    }
    #endregion
    #region Functions
    
    public IEnumerator SettingMovemetTrue()
    {
        yield return new WaitForSeconds(0.1f);
        isMoving = true;

    }
    void ForceCalculator(float value)
    {
        mainBall.transform.SetParent(mainParent);
        Vector3 newForce = new Vector3(0, value , 0);
        mainBall.GetComponent<Rigidbody>().isKinematic = false;
        mainBall.AddForce(newForce,ForceMode.Force);
        scoreValue = value;
        isMoving = true;
        holder.SetActive(false);

        References.reference.soundAndMusic.PlaySoundClip("Jump");
      
    }
    #endregion
  
}
