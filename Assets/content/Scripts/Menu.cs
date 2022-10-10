﻿using System.Collections;
using UnityEngine;

namespace Assets.content.Scripts
{
    public class Menu : MonoBehaviour
    {
        public void Quit()
        {
#if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        }

        public void Continue()
        {
            GameManager.Instance.Continue();
        }
    }
}