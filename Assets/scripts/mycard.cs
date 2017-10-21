using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mycard : MonoBehaviour{

    public card pro;  //卡牌属性

    
    //public int Tfh = 100;   //第几张手牌

    public bool back = false;

    [NonSerialized]
    public bool Click = false;

    public Sprite bimger;

    public SpriteRenderer sr;

    public Sprite[] cimger;

    
    public void setPro(card o)
    {
        pro = o;
        if (back)
        {
            sr.sprite = bimger;
        }
        else
        {
            sr.sprite = cimger[(int)o];
        }
        
    }


    // 当用户在 GUIElement 或碰撞器上按鼠标按钮时调用 OnMouseDown
    /*
    private void OnMouseDown()
    {
        if(Click == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.x);
            Click = true;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.x);
            Click = false;
        }

       
        Debug.Log(transform.position.ToString());
    }

    */

}
