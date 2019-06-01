using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildItem : MonoBehaviour {
    private Canvas canvas;

	// Use this for initialization
	void Start () {
        gameObject.transform.position = new Vector3();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        var worldManager = GameObject.Find("WorldManager").GetComponent<WorldManager>();
        worldManager.itemInstance = gameObject;
        
    }
	
	// Update is called once per frame
	void Update () {
        var position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        gameObject.transform.position = new Vector3(position.x, position.y, 0);

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            OpenMenu();
            var worldManager = WorldManager.GetInstance();
            worldManager.itemInstance = null;
            worldManager.SubtractMoney(100);
            Destroy(this);   
        }
	}

    void OpenMenu()
    {
        canvas.enabled = true;
    }
}
