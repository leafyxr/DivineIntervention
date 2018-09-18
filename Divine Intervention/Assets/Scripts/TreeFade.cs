using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFade : MonoBehaviour {
    public float fadeTransparency;
    [SerializeField]
    private GameObject[] TreeParts;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (GameObject treePart in TreeParts)
            {
                Color originColor = treePart.GetComponent<SpriteRenderer>().color;
                treePart.GetComponent<SpriteRenderer>().color = new Color(originColor.r, originColor.g, originColor.b, fadeTransparency);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (GameObject treePart in TreeParts)
            {
                Color originColor = treePart.GetComponent<SpriteRenderer>().color;
                treePart.GetComponent<SpriteRenderer>().color = new Color(originColor.r, originColor.g, originColor.b, 1);
            }
        }
    }
}
