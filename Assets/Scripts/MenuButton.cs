//------------------------------------------------------------------------------
//
// File Name:	MenuButton.cs
// Author(s):	Jeremy Kings (j.kings) - Unity Project
//              Nathan Mueller - original Zero Engine project
// Project:		Endless Runner
// Course:		WANIC VGP
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ButtonFunctions
{
    Play,
    Exit,
    Restart,
    Credits,
    MainMenu
}

public class MenuButton : MonoBehaviour
{
    // Options for what to do when button is clicked
    public ButtonFunctions buttonFunction;

    // Function to call when button is clicked
    private delegate void ButtonAction();
    private ButtonAction buttonAction;

    // Start is called before the first frame update
    void Start()
    {
        buttonAction = null;

        switch(buttonFunction)
        {
            case ButtonFunctions.Play:
                buttonAction = Play;
                break;
            case ButtonFunctions.Exit:
                buttonAction = Exit;
                break;
            case ButtonFunctions.Restart:
                buttonAction = Restart;
                break;
            case ButtonFunctions.Credits:
                buttonAction = Credits;
                break;
            case ButtonFunctions.MainMenu:
                buttonAction = MainMenu;
                break;
        }
    }

    public void OnButtonClicked()
    {
        buttonAction();
    }

    private void Play()
    {
        SceneManager.LoadScene(1); //load the main play scene
    }

    private void Exit()
    {
    #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    private void Restart()
    {
        SceneManager.LoadScene(1); //load the main scene
    }

    private void Credits()
    {
        SceneManager.LoadScene(3); //load the credits scene
    }

    private void MainMenu()
    {
        SceneManager.LoadScene(0); //load the main menu
    }
    public void PlaySound(AudioClip ac) {
        GetComponent<AudioSource>().PlayOneShot(ac);
    }
}
