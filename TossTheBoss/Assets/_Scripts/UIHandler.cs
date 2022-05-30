using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script is responsible to handle all UI Related Stuff.
/// </summary>


public class UIHandler : MonoBehaviour
{
    #region ToolTip 
    [TextArea]
    [Tooltip("UI")]
    public string INFO = "This script is responsible to handle all UI Related Stuff.";
    #endregion
    #region References  
    public GameObject gameOverScreen;
    public GameObject gameWinScreen;
    public TextMeshProUGUI textScore1;

    int currentScore;
    #endregion
    #region Functions 
    public void GameOver(){
        gameOverScreen.SetActive(true);
        textScore1.gameObject.transform.SetParent(gameOverScreen.transform);
        textScore1.gameObject.transform.localPosition = Vector3.zero;
    }
    public void GameWin()
    {
        
        gameWinScreen.SetActive(true);
        textScore1.gameObject.transform.SetParent(gameOverScreen.transform);
        textScore1.gameObject.transform.localPosition = Vector3.zero;

    }
    public void RestartTheGame() {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel() {
        SceneManager.LoadScene("Level 17");
    }
    public void ScoreCalculator(float value) {
        currentScore = (int)(value / 100);
        currentScore+=int.Parse(textScore1.text);
        textScore1.text = currentScore.ToString();
    }
    #endregion
}
