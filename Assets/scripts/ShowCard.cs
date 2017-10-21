using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCard : MonoBehaviour {

    handaera hd;
    List<GameObject> hl;
    public void MyPlayCardClick()
    {
        if (!((GameController.Bout == 0) && (GameController.playing == 0)))
        {
            Debug.Log("不是你的回合" + GameController.Bout + GameController.playing + GameController.playOrder);
            return;
        }
        int d = 0; 
        int f = -1;
        for (int i = 0; i < hl.Count; i++)
        {
            if (d > 1)
            {
                Debug.Log("不能打出牌");
                return;
            }
            if (hl[i].GetComponent<mycard>().Click == true)
            {
                d++;
                f = i;
            }
            

        }
        if(d == 1)
        {
            GameObject.FindWithTag("GameController").GetComponent<GameController>().PlayCard(f);
        }
       

    }
    // Use this for initialization
    void Start () {
        hd = GetComponent<handaera>();
        hl = hd.handList;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
