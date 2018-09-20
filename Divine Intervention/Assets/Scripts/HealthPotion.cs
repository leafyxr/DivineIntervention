using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour {
    public int Value;
    private HealthBar playerhealth;
    [SerializeField]
    private GameObject text;
    private void Start()
    {
        playerhealth = FindObjectOfType<HealthBar>().GetComponent<HealthBar>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerhealth.regenHealth(Value);
            GameObject popup = Instantiate(text, transform.position, new Quaternion(0, 0, 0, 0));
            popup.GetComponent<TextMesh>().text = "+" + Value.ToString();
            popup.GetComponent<TextPopup>().isfading = true;
            Destroy(gameObject, 0.1f);
        }
    }
}
