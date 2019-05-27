using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storefront : MonoBehaviour {
    private Canvas canvas;

    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
    }

    void Show()
    {
        canvas.enabled = true;
    }

    void Hide()
    {
        canvas.enabled = false;
    }
}
