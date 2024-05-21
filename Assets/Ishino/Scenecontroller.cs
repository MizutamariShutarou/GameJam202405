using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenecontroller : MonoBehaviour
{
    public void SceneChange(string nextScene)
    {
        SceneTransitionManager.Instance.TransitionScene(nextScene);
    }
}
