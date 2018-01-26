using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour {

	public void GrowUIText(float _percentToGrow)
    {
        gameObject.transform.localScale += Vector3.one * _percentToGrow;
    }

    public void NormalScaleUIText()
    {
        gameObject.transform.localScale = Vector3.one;
    }
}
