using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    
    public Button _btnPlay;
    
    public void OnPlay()
    {
        SceneManager.LoadScene("Level 1");
    }
}
