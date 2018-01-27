using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryText : MonoBehaviour {

	public void VictoryTextSetActive()
    {
        Debug.Log(gameObject.activeSelf);
        gameObject.SetActive(!gameObject.activeSelf);
    }


    private void Update()
    {
        /*if(Input.GetButtonDown("Jump"))
        VictoryTextSetActive();*/
    }
}
