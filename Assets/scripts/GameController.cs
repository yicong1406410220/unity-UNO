using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text text;

    public Image[] image;

    public Pile pile;
    public Ghost ghost;
    public GameObject[] hdq;


    /*
    public GameObject hd;
    public GameObject hd1;
    public GameObject hd2;
    public GameObject hd3;
    */
    static int bout = 0;    //谁的回合
    public static bool playOrder = true;   //游戏出牌顺序
    public static int playing = 0; //是不是正在操作

    public GameObject rbyg;

    public GameObject BulletSreen;

    public GameObject win;

    public static int Bout
    {
        get
        {
            return bout;
        }
        set
        { 
            bout = value;
            if (bout < 0)
            {
                bout = bout + 4;
            }
            if (bout > 3)
            {
                bout = bout - 4;
            }
        }
        
    }

    List<card> red0 = new List<card>()
    {
        card.red0, card.red1, card.red2, card.red3, card.red4, card.red5, card.red6, card.red7,
        card.red8, card.red9
    };
    List<card> red1 = new List<card>()
    {
         card.redadd2, card.redflip, card.redban, card.redkingadd4,card.redkinga
    };
    List<card> blue0 = new List<card>()
    {
        card.blue0, card.blue1, card.blue2, card.blue3, card.blue4, card.blue5, card.blue6, card.blue7,
        card.blue8, card.blue9
    };
    List<card> blue1 = new List<card>()
    {
        card.blueadd2, card.blueflip, card.blueban, card.bluekingadd4, card.bluekinga
    };
    List<card> yellow0 = new List<card>()
    {
        card.yellow0, card.yellow1, card.yellow2, card.yellow3, card.yellow4, card.yellow5, card.yellow6,
        card.yellow7, card.yellow8, card.yellow9
    };
    List<card> yellow1 = new List<card>()
    {
        card.yellowadd2, card.yellowflip, card.yellowban, card.yellowkingadd4, card.yellowkinga
    };
    List<card> green0 = new List<card>()
    {
        card.green0, card.green1, card.green2, card.green3, card.green4, card.green5, card.green6, card.green7,
        card.green8, card.green9
    };
    List<card> green1 = new List<card>()
    {
        card.greenadd2, card.greenflip, card.greenban, card.greenkingadd4, card.greenkinga
    };
    List<card> kingc = new List<card>()
    {
        card.kingadd4, card.kinga
    };


    List<card> kingadd4c = new List<card>()
    {
        card.redkingadd4, card.bluekingadd4, card.yellowkingadd4, card.greenkingadd4
    };
    List<card> kingac = new List<card>()
    {
        card.redkinga, card.bluekinga, card.yellowkinga, card.greenkinga
    };



    // Use this for initialization
    IEnumerator Start()
    {
        StartCoroutine(Init());
        yield return new WaitForSeconds(2f);
    }

    IEnumerator Init()
    {
        //int i = Random.Range(0, pile.deck.Count);
        ghost.dPlie.Add(pile.deck[pile.deck.Count - 1]);
        pile.deck.RemoveAt(pile.deck.Count - 1);
        while (ghost.dPlie[ghost.dPlie.Count - 1] == card.kinga || ghost.dPlie[ghost.dPlie.Count - 1] == card.kingadd4)
        {
            PlayTitle("系统重新发给弃牌堆一张牌");
            Debug.Log("系统又发给弃牌堆一张牌");
            ghost.dPlie.Add(pile.deck[pile.deck.Count - 1]);
            pile.deck.RemoveAt(pile.deck.Count - 1);
        }
            
        for (int j = 0; j < 7; j++)
        {
            //int c = Random.Range(0, pile.deck.Count);
            hdq[0].GetComponent<handaera>().AddCard(pile.deck[pile.deck.Count-1]);
            pile.deck.RemoveAt(pile.deck.Count - 1);
            yield return new WaitForSeconds(0.1f);
            //int q = Random.Range(0, pile.deck.Count);
            hdq[1].GetComponent<handaera>().AddCard(pile.deck[pile.deck.Count - 1]);
            pile.deck.RemoveAt(pile.deck.Count - 1);
            //int w = Random.Range(0, pile.deck.Count);
            hdq[2].GetComponent<handaera>().AddCard(pile.deck[pile.deck.Count - 1]);
            pile.deck.RemoveAt(pile.deck.Count - 1);
            //int e = Random.Range(0, pile.deck.Count);
            hdq[3].GetComponent<handaera>().AddCard(pile.deck[pile.deck.Count - 1]);
            pile.deck.RemoveAt(pile.deck.Count - 1);
        }

    }

    public bool PlayCard(int i)
    {
        card g = hdq[bout].GetComponent<handaera>().handList[i].GetComponent<mycard>().pro;//打出牌的属性
        bool f = ((red0.Contains(g) || red1.Contains(g) || kingc.Contains(g)) && (red0.Contains(ghost.upcard) || red1.Contains(ghost.upcard)) || (blue0.Contains(g) || blue1.Contains(g) || kingc.Contains(g)) && (blue0.Contains(ghost.upcard) || blue1.Contains(ghost.upcard)) ||
            (yellow0.Contains(g) || yellow1.Contains(g) || kingc.Contains(g)) && (yellow0.Contains(ghost.upcard) || yellow1.Contains(ghost.upcard)) || (green0.Contains(g) || green1.Contains(g) || kingc.Contains(g)) && (green0.Contains(ghost.upcard) || green1.Contains(ghost.upcard)));
        bool p = false;
        if ((red0.IndexOf(ghost.upcard) != -1) && (red0.IndexOf(ghost.upcard) == red0.IndexOf(g) || red0.IndexOf(ghost.upcard) == blue0.IndexOf(g) || red0.IndexOf(ghost.upcard) == yellow0.IndexOf(g) || red0.IndexOf(ghost.upcard) == green0.IndexOf(g)))
        {
            p = true;
        }
        if ((red1.IndexOf(ghost.upcard) != -1) && (red1.IndexOf(ghost.upcard) == red1.IndexOf(g) || red1.IndexOf(ghost.upcard) == blue1.IndexOf(g) || red1.IndexOf(ghost.upcard) == yellow1.IndexOf(g) || red1.IndexOf(ghost.upcard) == green1.IndexOf(g)))
        {
            p = true;
        }
        if ((blue0.IndexOf(ghost.upcard) != -1) && (blue0.IndexOf(ghost.upcard) == red0.IndexOf(g) || blue0.IndexOf(ghost.upcard) == blue0.IndexOf(g) || blue0.IndexOf(ghost.upcard) == yellow0.IndexOf(g) || blue0.IndexOf(ghost.upcard) == green0.IndexOf(g)))
        {
            p = true;
        }
        if ((blue1.IndexOf(ghost.upcard) != -1) && (blue1.IndexOf(ghost.upcard) == red1.IndexOf(g) || blue1.IndexOf(ghost.upcard) == blue1.IndexOf(g) || blue1.IndexOf(ghost.upcard) == yellow1.IndexOf(g) || blue1.IndexOf(ghost.upcard) == green1.IndexOf(g)))
        {
            p = true;
        }
        if ((yellow0.IndexOf(ghost.upcard) != -1) && (yellow0.IndexOf(ghost.upcard) == red0.IndexOf(g) || yellow0.IndexOf(ghost.upcard) == blue0.IndexOf(g) || yellow0.IndexOf(ghost.upcard) == yellow0.IndexOf(g) || yellow0.IndexOf(ghost.upcard) == green0.IndexOf(g)))
        {
            p = true;
        }
        if ((yellow1.IndexOf(ghost.upcard) != -1) && (yellow1.IndexOf(ghost.upcard) == red1.IndexOf(g) || yellow1.IndexOf(ghost.upcard) == blue1.IndexOf(g) || yellow1.IndexOf(ghost.upcard) == yellow1.IndexOf(g) || yellow1.IndexOf(ghost.upcard) == green1.IndexOf(g)))
        {
            p = true;
        }
        if ((green0.IndexOf(ghost.upcard) != -1) && (green0.IndexOf(ghost.upcard) == red0.IndexOf(g) || green0.IndexOf(ghost.upcard) == blue0.IndexOf(g) || green0.IndexOf(ghost.upcard) == yellow0.IndexOf(g) || green0.IndexOf(ghost.upcard) == green0.IndexOf(g)))
        {
            p = true;
        }
        if ((green1.IndexOf(ghost.upcard) != -1) && (green1.IndexOf(ghost.upcard) == red1.IndexOf(g) || green1.IndexOf(ghost.upcard) == blue1.IndexOf(g) || green1.IndexOf(ghost.upcard) == yellow1.IndexOf(g) || green1.IndexOf(ghost.upcard) == green1.IndexOf(g)))
        {
            p = true;
        }
        if (!(f || p))
        {
            //Debug.Log("打出的牌不符合规则");
            return false;
        }
        card k = hdq[bout].GetComponent<handaera>().RemoveCard(i);
        PlayTitle(bout + "号玩家打出" + k);
        Debug.Log(bout+ "号玩家打出" + k);
        ghost.dPlie.Add(k);
        LsNext(k);
        if (kingc.Contains(k))
        {
            playing = -1;
            if (Bout == 0)
            {
                rbyg.SetActive(true);
            }
            else
            {
                gameObject.GetComponent<Ai>().myrbg[0].UpReplace(Random.Range(1, 5));
            }

            return true;
        }
        return true;
    }

    /**
     * 怎么到下个回合
     * */
    private void LsNext(card k)
    {
        if (!kingc.Contains(k))
        {
            if (k == card.redban || k == card.blueban || k == card.yellowban || k == card.greenban)
            {
                if (playOrder)
                {
                    Bout++;
                }
                else
                {
                    Bout--;
                }
            }
            if (k == card.redflip || k == card.blueflip || k == card.yellowflip || k == card.greenflip)
            {
                playOrder = !playOrder;
            }
            if (k == card.redadd2 || k == card.blueadd2 || k == card.yellowadd2 || k == card.greenadd2)
            {
                if (playOrder)
                {
                    int f = Bout + 1;
                    if (f < 0)
                    {
                        f = f + 4;
                    }
                    if (f > 3)
                    {
                        f = f - 4;
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        hdq[f].GetComponent<handaera>().AddCard(pile.deck[pile.deck.Count - 1]);
                        pile.deck.RemoveAt(pile.deck.Count - 1);
                    }
                    Bout++;
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        int f = Bout - 1;
                        if (f < 0)
                        {
                            f = f + 4;
                        }
                        if (f > 3)
                        {
                            f = f - 4;
                        }
                        hdq[f].GetComponent<handaera>().AddCard(pile.deck[pile.deck.Count - 1]);
                        pile.deck.RemoveAt(pile.deck.Count - 1);
                    }
                    Bout--;
                }
            }

            if (playOrder)
            {
                Bout++;
            }
            else
            {
                Bout--;
            }
            playing = 1;

        }
        
    }

    private void OnDestroy()
    {
        bout = 0;    //谁的回合
        playOrder = true;   //游戏出牌顺序
        playing = 0; //是不是正在操作
    }

    public void BFSCard(int g)
    {
        List<GameObject> hList = hdq[g].GetComponent<handaera>().handList;
        for (int j = 0; j < hList.Count; j++)
        {
            if (PlayCard(j))
            {
                return;
            }
        }
        hdq[g].GetComponent<handaera>().AddCard(pile.deck[pile.deck.Count - 1]);
        pile.deck.RemoveAt(pile.deck.Count - 1);
        PlayTitle(g + "号玩家摸了一张牌");
        Debug.Log(g + "号玩家摸了一张牌");
        if (playOrder)
        {
            Bout++;
        }
        else
        {
            Bout--;
        }
        playing = 1;
    }

    public void Addacard()
    {
        if (Bout == 0 && playing == 0)
        {

            hdq[0].GetComponent<handaera>().AddCard(pile.deck[pile.deck.Count - 1]);
            pile.deck.RemoveAt(pile.deck.Count - 1);
            PlayTitle(0 + "号玩家摸了一张牌");
            Debug.Log(0 + "号玩家摸了一张牌");
            if (playOrder)
            {
                Bout++;
            }
            else
            {
                Bout--;
            }
            playing = 1;
        }

    }

    public void PlayTitle(string s)
    {
        Vector3 f = new Vector3(14, Random.Range(-1,5), 0);
        GameObject o = Instantiate(BulletSreen, f, Quaternion.identity) as GameObject;
        o.GetComponent<TextMove>().mytext.text = s;
        o.GetComponent<TextMove>().speed = Random.Range(4, 7);
        text.text += s + "\n";

    }


    // Update is called once per frame
    void Update()
    {
        if (pile.deck.Count<5)
        {
            PlayTitle("系统洗切了牌堆");
            Debug.Log("系统洗切了牌堆");
            CardShuffle();

        }

        if (Bout == 0 && playing == 1)
        {
            playing = 0;
            PlayTitle("我的回合开始了");
            Debug.Log("我的回合开始了");
        }

        for(int i = 0; i < 4; i++)
        {
            if(bout == i)
            {
                image[i].enabled = true;
            }
            else
            {
                image[i].enabled = false;
            }
            
        }
        

    }

    private void CardShuffle()
    {
        int number = ghost.dPlie.Count;
        for(int i = 0; i < number -5; i++)
        {
            card g = ghost.dPlie[0];
            ghost.dPlie.RemoveAt(0);
            if (kingadd4c.Contains(g))
            {
                g = card.kingadd4;
            }
            if (kingac.Contains(g))
            {
                g = card.kinga;
            }
            pile.deck.Add(g);
        }

    }

    public void LsWin()
    {
        win.SetActive(true);
        if (Bout > 0 || Bout < 4)
        {
            win.GetComponentInChildren<Text>().text = "电脑" + Bout + "号获得了游戏胜利";

        }
        if (Bout == 0)
        {
            win.GetComponentInChildren<Text>().text = "恭喜玩家获得本局游戏胜利";
        }
    }
}
