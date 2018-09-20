using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopup : MonoBehaviour {
    public bool isfading = true;
    public float rateOfFade = 0.1f;
    private Color currentColour;
    private float clock;
    public string SortingLayerName = "Default";
    // Use this for initialization
    void Start () {
        gameObject.GetComponent<MeshRenderer>().sortingLayerName = SortingLayerName;
        currentColour = GetComponent<TextMesh>().color;
	}
	
	// Update is called once per frame
	void Update () {
		if (isfading)
        {
            clock += Time.deltaTime;
            if (clock >= .1)
            {
                clock = 0;
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
                GetComponent<TextMesh>().color = new Color(currentColour.r, currentColour.g, currentColour.b, (currentColour.a - rateOfFade));
                currentColour = GetComponent<TextMesh>().color;
                if (currentColour.a <= 0)
                {
                    Destroy(gameObject,0.1f);
                }
            }
        }
	}
}
