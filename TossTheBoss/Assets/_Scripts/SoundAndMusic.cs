using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Sounds and Music controller script.
/// </summary>
public class SoundAndMusic : MonoBehaviour
{
    #region Public References
    public AudioSource backgroundMusic;
    public GameObject gameSounds;
    public Sounds sounds;
    #endregion
    #region Callback
    private void Start()
    {
        if (PlayerPrefs.GetString("Music") == "")
        {
            PlayerPrefs.SetString("Music", "true");
            
        }

        if (PlayerPrefs.GetString("Music") == "false")
        {
            SetMusicOnAndOff(false);
        }
        else
        {
            SetMusicOnAndOff(true);
        }

        //DontDestroyOnLoad(soundAndMusic);
    }
    #endregion
    #region Functions
    public void SetMusicOnAndOff(bool value)
    {
        if (value)
        {
            PlayerPrefs.SetString("Music", "true");
            backgroundMusic.volume = 0.2f;
        }
        else
        {
            PlayerPrefs.SetString("Music", "false");
            backgroundMusic.volume = 0f;
        }
    }
    bool gameWinSoundPlayed;
    bool gameLoseSoundPlayed;
   
    public void PlaySoundClip(string name)
    {
      
        if (PlayerPrefs.GetString("Music")!= "false")
        {
           
            if (name == "Lose")
            {

                GameObject local = Instantiate(gameSounds);
                local.GetComponent<AudioSource>().clip = sounds.Lose;
                local.GetComponent<AudioSource>().volume = 0.5f;
                local.GetComponent<AudioSource>().Play();
                StartCoroutine(DestroySound(local, 2));

            }
            if (name == "Coin")
            {

                GameObject local = Instantiate(gameSounds);
                local.GetComponent<AudioSource>().clip = sounds.Coin;
                local.GetComponent<AudioSource>().volume = 0.5f;
                local.GetComponent<AudioSource>().Play();
                StartCoroutine(DestroySound(local, 2));

            }
            if (name == "Jump")
            {

                GameObject local = Instantiate(gameSounds);
                local.GetComponent<AudioSource>().clip = sounds.Jump;
                local.GetComponent<AudioSource>().volume = 0.5f;
                local.GetComponent<AudioSource>().Play();
                StartCoroutine(DestroySound(local, 2));

            }

            if (name == "Landing")
            {

                GameObject local = Instantiate(gameSounds);
                local.GetComponent<AudioSource>().clip = sounds.Landing;
                local.GetComponent<AudioSource>().volume = 0.5f;
                local.GetComponent<AudioSource>().Play();
                StartCoroutine(DestroySound(local, 2));

            }
            if (name == "Win")
            {

                GameObject local = Instantiate(gameSounds);
                local.GetComponent<AudioSource>().clip = sounds.Win;
                local.GetComponent<AudioSource>().volume = 0.5f;
                local.GetComponent<AudioSource>().Play();
                StartCoroutine(DestroySound(local, 2));

            }



        }
    }
    IEnumerator DestroySound(GameObject g, float t,bool check=false)
    {   if(!check)
            yield return new WaitForSeconds(t);
        else
            yield return new WaitForSeconds(5);
        Destroy(g);
        if (check)
        {
            backgroundMusic.volume = 0.2f;
        }
    }
    #endregion
}
