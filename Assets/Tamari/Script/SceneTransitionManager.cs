using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public SceneTransitionManager _instance = default;

    private SceneTransitionManager Instance => _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void TransitionScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
}
