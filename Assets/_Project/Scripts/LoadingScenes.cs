using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScenes : MonoBehaviour {

	public void LoadLevel(int _sceneToLoad)
    {
        SceneManager.LoadScene(_sceneToLoad);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
