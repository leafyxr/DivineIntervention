using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {
    private Camera mainCamera;
    private GameObject Player;
    [SerializeField]
    private float panSpeed = 0.5f;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
            Vector3 target = new Vector3(Player.transform.position.x, Player.transform.position.y, mainCamera.transform.position.z);
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, target, panSpeed * Time.deltaTime);
    }
}
