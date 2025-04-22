using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    AudioManager am;

    private void Start()
    {
        am = FindObjectOfType<AudioManager>();
    }
    public void Play()
    {
        am.Play("Menu Click");
        SceneManager.LoadScene("Intro");
    }

    public void Continue()
    {
        am.Play("Menu Click");
        SceneManager.LoadScene("MainGame");
    }
}
