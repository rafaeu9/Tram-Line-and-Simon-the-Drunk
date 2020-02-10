using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonDance : MonoBehaviour
{
    public enum Moves { MoveUp, MoveDown, MoveLeft, MoveRight };

    Moves CurrentMove;

    Moves[] List;

    Moves ChangedDirct;

    GameObject RightFist;
    GameObject LeftFist;
    GameObject Feet;
    GameObject Head;

    public int MaxLevel = 7;

    public int Level = 0;

    public Text GameText;

    public bool PlayerTurn = false;

    Moves[] PlayerMoves;

    int currentplayermove = 0;

    public bool Moved = false;

    public Moves PlayerMoved;

    public bool Over = false;

    public bool Ready = false;

    

    // Start is called before the first frame update
    void Start()
    {
        RightFist = transform.Find("Simon_Fist_Right").gameObject;
        LeftFist = transform.Find("Simon_Fist_Left").gameObject;
        Feet= transform.Find("Simon_Fist_Left").gameObject;
        Head = transform.Find("Head").gameObject;

        List = new Moves[MaxLevel];

        GameText.text = "Ready?";

        //StartCoroutine(Dance());
    }

    // Update is called once per frame
    void Update()
    {

        if (Level == MaxLevel)
        {
            Over = true;
            Win();
        }

        if (PlayerTurn && !Over)
        {
            
            if (Moved)
            {
                PlayerMoves[currentplayermove] = PlayerMoved;
                
                Moved = false;
                currentplayermove++;
            }            

            if (currentplayermove > Level)
                {
                for (int i = 0; i < PlayerMoves.Length; i++)
                {
                    if (PlayerMoves[i] != List[i])
                        Over = true;
                }

                PlayerTurn = false;

                if (Over)
                    GameOver();
                else
                {             

                    ChangeDirection();
                }
            }
                
        }

    }

    public IEnumerator Dance()
    {        
        CurrentMove = (Moves)Random.Range((int)Moves.MoveUp, (int)Moves.MoveRight);

        List[Level] = CurrentMove;

        for (int i = 0; i <= Level; i++)
        {
            switch (List[i])
            {
                case Moves.MoveUp:
                    RightFist.GetComponent<Animation>().Play();
                    GameText.text = "Up";
                    while (RightFist.GetComponent<Animation>().isPlaying)
                    {
                        yield return null;
                    }
                    break;
                case Moves.MoveDown:
                    Head.GetComponent<Animation>().Play();
                    GameText.text = "Down";
                    while (Head.GetComponent<Animation>().isPlaying)
                    {
                        yield return null;
                    }
                    break;
                case Moves.MoveLeft:
                    LeftFist.GetComponent<Animation>().Play();
                    GameText.text = "Left";
                    while (LeftFist.GetComponent<Animation>().isPlaying)
                    {
                        yield return null;
                    }
                    break;
                case Moves.MoveRight:
                    Feet.GetComponent<Animation>().Play();
                    GameText.text = "Right";

                    while (Feet.GetComponent<Animation>().isPlaying)
                    {
                        yield return null;
                    }
                    break;
            }



        }

        PlayerTurn = true;

        GameText.text = "You're up";

        PlayerMoves = new Moves[Level+1];
        
        currentplayermove = 0;
        
    }



    public void ChangeDirection()
    {
        Level++;

        do {
            ChangedDirct = (Moves)Random.Range((int)Moves.MoveUp, (int)Moves.MoveRight);
        } while (ChangedDirct == List[Level - 1]);

        List[Level - 1] = ChangedDirct;

        StartCoroutine(Dance());
    }

    //public IEnumerator PlayerTurnMove()
    //{
        

    //    return null;
    //}


    void GameOver()
    {
        GameText.text = "You Lose";
    }

    void Win()
    {
        GameText.text = "You Win";
    }
}
