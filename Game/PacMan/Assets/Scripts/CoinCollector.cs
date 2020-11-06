using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    public int points = 100;
    [SerializeField]
    public TMP_Text pointText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Point")
        {
            pointText.text = (int.Parse(pointText.text)+points).ToString();
            Destroy(collision.gameObject);
        }
    }
}
