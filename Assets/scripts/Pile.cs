using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pile : MonoBehaviour
{

    public List<card> deck = new List<card>();

    private void Awake()
    {
        Shuffle();

    }

    void Shuffle()
    {
        for (int i = 1; i < 5; i++)
        {
            Randcard((card)i);
        }
        for (int i = 5; i < 53; i++)
        {
            Randcard((card)i);
            Randcard((card)i);
        }
        for (int i = 53; i < 55; i++)
        {
            Randcard((card)i);
            Randcard((card)i);
            Randcard((card)i);
            Randcard((card)i);
        }
        /*
        for (int i = 0; i < 108 ; i++)
        {
            Debug.Log(i + " " + deck[i]);
        }
        */
    }

    void Randcard(card v)
    {
        int f;
        while (true)
        {
            f = UnityEngine.Random.Range(0, 108);
            if (deck[f] == card.cnull)
            {
                deck[f] = v;
                break;
            }
        }
        
    }

    /**
* 随机放入卡片
* */




    // Update is called once per frame
    void Update()
    {

    }
}
