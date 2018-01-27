using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AtTheEndOfTheCredits : MonoBehaviour {

    public string m_levelToLoadAtTheEnd;
    public int m_timeForTheCredits = 20;

    IEnumerator Start () {
        Animator _clipInfo = GetComponent<Animator>();
        AnimatorClipInfo[] _clips = _clipInfo.GetCurrentAnimatorClipInfo(0);
         yield return new WaitForSeconds(_clips[0].clip.length * 20);
         SceneManager.LoadScene(m_levelToLoadAtTheEnd);
    }
}
