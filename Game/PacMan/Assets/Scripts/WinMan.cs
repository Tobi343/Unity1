using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMan : MonoBehaviour
{

    private int coins;

    public void setCoins()
    {
        coins--;
    }
    // Start is called before the first frame update
    void Start()
    {
        coins = GameObject.FindGameObjectsWithTag("Point").Length-48;
    }

    // Update is called once per frame
    void Update()
    {
        if (coins < 1)
        {
            Debug.Log("Win");
        }
    }
}
