using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    public GameObject buff = null;
    public float step;
    public enum Direction
    {
        Vertical,
        Horizontal
    }
    public Direction direction;
    private float size;
    private float start;
    private float end;
    private Vector3 pos;
    public List<GameObject> coins = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        if (direction == Direction.Horizontal)
        {
            size = transform.localScale.x;
            start = (size / 2) + transform.position.x;
            end = transform.position.x - (size / 2);
            pos = new Vector3(start, transform.position.y, transform.position.z);
            GameObject g = Instantiate(coin, pos, Quaternion.identity);
            coins.Add(g);
            while (pos.x > end)
            {
                pos = new Vector3(start-step, transform.position.y, transform.position.z);
                GameObject go = Instantiate(coin, pos, Quaternion.identity);
                coins.Add(go);
                start -= step;
            }
            Destroy(coins[coins.Count - 1]);
        }
        else if (direction == Direction.Vertical)
        {
            size = transform.localScale.y;
            start = (size / 2) + transform.position.y;
            end = transform.position.y - (size / 2);
            pos = new Vector3(transform.position.x, start, transform.position.z);
            GameObject g = Instantiate(coin, pos, Quaternion.identity);
            coins.Add(g);
            while (pos.y > end)
            {
                pos = new Vector3(transform.position.x, start - step, transform.position.z);
                GameObject go = Instantiate(coin, pos, Quaternion.identity);
                coins.Add(go);
                start -= step;
            }
            Destroy(coins[coins.Count - 1]);
        }
        CreateBuff();
    }


    private void CreateBuff()
    {
        if(buff != null)
        {
            int i = Random.Range(0, coins.Count-1);
            Vector3 buffPos = coins[i].transform.position;
            Destroy(coins[i]);
            Instantiate(buff, buffPos, Quaternion.identity);
        }
    }
}
