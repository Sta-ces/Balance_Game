using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDLife : MonoBehaviour {

    public GameObject m_prefabsSpriteLife;

    public int m_numberLife = 3;
    public Color[] m_colorLifePlayer = new Color[2];

    public List<GameObject> m_panelsLifes;


    public static int GetLifesPlayerCount(GameObject _panelPlayer)
    {
        return _panelPlayer.GetComponentsInChildren<RawImage>().Length;
    }

    public static void RemovePlayerLife(GameObject _panelPlayer, int _numberLifeToRemove = 1)
    {
        RawImage[] hearts = _panelPlayer.GetComponentsInChildren<RawImage>();
        if (hearts.Length > 0)
            for (int h = 0; h < _numberLifeToRemove; h++)
            {
                Destroy(hearts[0].gameObject);
            }
        else
            Debug.Log("Player n'a plus de vie");
    }


    private void Awake()
    {
        CreateLife();
    }


    private void CreateLife()
    {
        int color = 0;
        foreach(GameObject panel in m_panelsLifes)
        {
            panel.GetComponent<GridLayoutGroup>().constraintCount = m_numberLife;
            for(int life = 0; life < m_numberLife; life++)
            {
                GameObject heart = Instantiate(m_prefabsSpriteLife, panel.transform);
                heart.GetComponent<RawImage>().color = m_colorLifePlayer[color];
            }
            color++;
        }
    }
}
