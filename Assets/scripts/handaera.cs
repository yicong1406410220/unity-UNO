using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handaera : MonoBehaviour {
    public Transform left;
    public Transform right;

    public int player = 0;

    [NonSerialized]
    public List<GameObject> handList = new List<GameObject>();

    //[NonSerialized]
    //public int amount = 0;//手牌数

    public GameObject card;

    public void AddCard(card a) //添加卡片
    {
       // amount++;
        for (int i = 0; i < handList.Count; i++)
        {
            handList[i].GetComponent<Rigidbody>().MovePosition(new Vector3(left.position.x + (right.position.x - left.position.x) / (handList.Count + 2) * (i + 1), handList[i].GetComponent<Transform>().position.y, left.position.z));
        }
        Vector3 f = new Vector3(left.position.x + (right.position.x - left.position.x) / (handList.Count + 2) * (handList.Count + 1), left.position.y, left.position.z);
        GameObject o = Instantiate(card, f, Quaternion.identity) as GameObject;
        o.transform.SetParent(transform);
        handList.Add(o);
        if (player != 0)
        {
            o.GetComponent<mycard>().back = true;
        }
        o.GetComponent<mycard>().setPro((card)a);
        //SetCardTfh();
        Sortcard();
    }
 
    public card RemoveCard(int f)//删除卡片
    {
        //amount--;
        card cr = handList[f].GetComponent<mycard>().pro;
        Destroy(handList[f]);
        handList.RemoveAt(f);
        for (int i = 0; i < handList.Count; i++)
        {
            handList[i].GetComponent<Rigidbody>().MovePosition(new Vector3(left.position.x + (right.position.x - left.position.x) / (handList.Count + 1) * (i + 1), handList[i].GetComponent<Transform>().position.y, left.position.z));
        }
        //SetCardTfh();
        if(handList.Count == 0)
        {
            GameObject.FindWithTag("GameController").GetComponent<GameController>().LsWin();
        }
        Sortcard();
        return cr;
    }

    /*
    private void SetCardTfh()
    {
        for (int i = 0; i < handList.Count; i++)
        {
            handList[i].GetComponent<mycard>().Tfh = i;
        }
    }
    */

    private void Sortcard()//整理层级
    {
        for (int i = 0; i < handList.Count; i++)
        {
            handList[i].GetComponent<SpriteRenderer>().sortingOrder = i; 
        }
    }


    // Use this for initialization
    void Start () {
        //StartCoroutine(waitmy());
    }

    IEnumerator waitmy()
    {
        for (int i = 0; i < 7; i++)
        {
            yield return new WaitForSeconds(0.1f);
            AddCard((card)i);
        }
            
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
