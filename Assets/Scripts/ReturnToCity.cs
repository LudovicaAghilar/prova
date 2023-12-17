using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToCity : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene(4);
    }
    public void ResumeGame()
    {
        SumPause.Status = false; // Set pause status to false
    }

}
