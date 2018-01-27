using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInGame : MonoBehaviour {

    public GameObject m_menuInGame;

    public void Resume()
    {
        m_menuInGame.SetActive(!m_menuInGame.activeSelf);
    }


    private void Awake()
    {
        m_menuInGame.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            Resume();
    }
}
