using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCollect : MonoBehaviour {
    public int Value;
    private DataManager dataManager;
    [SerializeField]
    private GameObject text;
    private void Start()
    {
        dataManager = FindObjectOfType<DataManager>().GetComponent<DataManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            dataManager.data.Gold += Value;
            GameObject popup = Instantiate(text, transform.position, new Quaternion(0,0,0,0));
            popup.GetComponent<TextMesh>().text = "+" + Value.ToString() + "g";
            popup.GetComponent<TextPopup>().isfading = true;
            Destroy(gameObject, 0.1f);
        }
    }
}
