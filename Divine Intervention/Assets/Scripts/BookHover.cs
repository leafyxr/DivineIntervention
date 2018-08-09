using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookHover : MonoBehaviour {
    [SerializeField]
    GameObject targetObject;
    Vector2 tempPos = new Vector2();
    public float hoverAmplitude = 0.5f;
    public float hoverFrequency = 1f;
    private float speed = 2;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetObject.transform.position, speed * Time.deltaTime);
            tempPos = transform.position;
            tempPos.y += Mathf.Sin(Time.timeSinceLevelLoad * Mathf.PI * hoverFrequency) * hoverAmplitude;
            transform.position = tempPos;
        }

    }
}
