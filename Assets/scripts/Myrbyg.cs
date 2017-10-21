using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Myrbyg : MonoBehaviour {

    public int number = 0;

    public GameController gameController;

    public Ghost ghost;

    public void UpReplace()
    {
        card gf = 0;
        if (ghost.dPlie[ghost.dPlie.Count - 1] == card.kingadd4)
        {
            switch (number)
            {
                case 1:
                    gf = card.redkingadd4;
                    break;
                case 2:
                    gf = card.bluekingadd4;
                    break;
                case 3:
                    gf = card.yellowkingadd4;
                    break;
                case 4:
                    gf = card.greenkingadd4;
                    break;
            }
            if (GameController.playOrder)
            {
                for (int i = 0; i < 4; i++)
                {
                    int f = GameController.Bout + 1;
                    if (f < 0)
                    {
                        f = f + 4;
                    }
                    if (f > 3)
                    {
                        f = f - 4;
                    }
                    gameController.hdq[f].GetComponent<handaera>().AddCard(gameController.pile.deck[(gameController.pile.deck.Count) - 1]);
                    gameController.pile.deck.RemoveAt(gameController.pile.deck.Count - 1);
                }
                    GameController.Bout++;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    int f = GameController.Bout - 1;
                    if (f < 0)
                    {
                        f = f + 4;
                    }
                    if (f > 3)
                    {
                        f = f - 4;
                    }
                    gameController.hdq[f].GetComponent<handaera>().AddCard(gameController.pile.deck[(gameController.pile.deck.Count) - 1]);
                    gameController.pile.deck.RemoveAt(gameController.pile.deck.Count - 1);
                    
                }
                    GameController.Bout--;
            }

        }
        if (ghost.dPlie[ghost.dPlie.Count - 1] == card.kinga)
        {
            switch (number)
            {
                case 1:
                    gf = card.redkinga;
                    break;
                case 2:
                    gf = card.bluekinga;
                    break;
                case 3:
                    gf = card.yellowkinga;
                    break;
                case 4:
                    gf = card.greenkinga;
                    break;
            }
        }
        Debug.Log(gf);
        ghost.dPlie.RemoveAt(ghost.dPlie.Count - 1);
        ghost.dPlie.Add(gf);
        gameObject.transform.parent.gameObject.SetActive(false);
        if (GameController.playOrder)
        {
            GameController.Bout++;
        }
        else
        {
            GameController.Bout--;
        }
        GameController.playing = 1;
    }

    public void UpReplace(int number)
    {
        card gf = 0;
        if (ghost.dPlie[ghost.dPlie.Count - 1] == card.kingadd4)
        {
            switch (number)
            {
                case 1:
                    gf = card.redkingadd4;
                    break;
                case 2:
                    gf = card.bluekingadd4;
                    break;
                case 3:
                    gf = card.yellowkingadd4;
                    break;
                case 4:
                    gf = card.greenkingadd4;
                    break;
            }
            if (GameController.playOrder)
            {
                for (int i = 0; i < 4; i++)
                {
                    int f = GameController.Bout + 1;
                    if (f < 0)
                    {
                        f = f + 4;
                    }
                    if (f > 3)
                    {
                        f = f - 4;
                    }
                    gameController.hdq[f].GetComponent<handaera>().AddCard(gameController.pile.deck[(gameController.pile.deck.Count) - 1]);
                    gameController.pile.deck.RemoveAt(gameController.pile.deck.Count - 1);
                }
                GameController.Bout++;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    int f = GameController.Bout - 1;
                    if (f < 0)
                    {
                        f = f + 4;
                    }
                    if (f > 3)
                    {
                        f = f - 4;
                    }
                    gameController.hdq[f].GetComponent<handaera>().AddCard(gameController.pile.deck[(gameController.pile.deck.Count) - 1]);
                    gameController.pile.deck.RemoveAt(gameController.pile.deck.Count - 1);

                }
                GameController.Bout--;
            }

        }
        if (ghost.dPlie[ghost.dPlie.Count - 1] == card.kinga)
        {
            switch (number)
            {
                case 1:
                    gf = card.redkinga;
                    break;
                case 2:
                    gf = card.bluekinga;
                    break;
                case 3:
                    gf = card.yellowkinga;
                    break;
                case 4:
                    gf = card.greenkinga;
                    break;
            }
        }
        Debug.Log(gf);
        ghost.dPlie.RemoveAt(ghost.dPlie.Count - 1);
        ghost.dPlie.Add(gf);
        //gameObject.transform.parent.gameObject.SetActive(false);
        if (GameController.playOrder)
        {
            GameController.Bout++;
        }
        else
        {
            GameController.Bout--;
        }
        GameController.playing = 1;
    }

    private void Start()
    {
        //ghost = GameObject.FindWithTag("ghost").GetComponent<Ghost>();
    }



}
