using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour
{
    public GameObject[] stars;
    public GameObject[] starsEmpty;
    int coinsCount;

    // Start is called before the first frame update
    void Start()
    {
        coinsCount = GameObject.FindGameObjectsWithTag("Coins").Length;
        coinsCount = coinsCount == 0 ? 1 : coinsCount;
        Debug.Log("CoinsCount:" + coinsCount.ToString());
    }

    public void StarsAcheived() {
        int coinsLeft = GameObject.FindGameObjectsWithTag("Coins").Length;
        int coinsCollected = coinsCount - coinsLeft;

        float percentage = float.Parse(coinsCollected.ToString()) / float.Parse(coinsCount.ToString()) * 100f;
        Debug.Log("Percentage:" + percentage.ToString());

        if (percentage < 33f)
        {
            starsEmpty[0].SetActive(true);
            starsEmpty[1].SetActive(true);
            starsEmpty[2].SetActive(true);
            Debug.Log("percentage < 33");
        }
        else if (percentage < 66f)
        {
            stars[0].SetActive(true);
            starsEmpty[1].SetActive(true);
            starsEmpty[2].SetActive(true);
            Debug.Log("percentage < 66");
        }
        else if (percentage < 99f)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            starsEmpty[2].SetActive(true);
            Debug.Log("percentage < 99");
        }
        else {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            Debug.Log("percentage == 100");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
