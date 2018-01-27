using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryText : MonoBehaviour {

    public GameObject m_Victory;
    public Text m_VictoryText;

	public void VictoryTextSetActive(string _winnerName)
    {
        m_VictoryText.text = _winnerName + "\nWIN!";
        m_Victory.SetActive(!m_Victory.activeSelf);
    }


    private void Awake()
    {
        m_Victory.SetActive(false);
    }
}
