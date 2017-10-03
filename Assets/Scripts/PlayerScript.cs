using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public MainMenuScript mm;
    public int[] players;
    //public GameObject panel;
    public int numOfPlayers;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public KeyCode k1;
    public KeyCode k2;
    public KeyCode k3;
    public KeyCode k4;
    bool settingKey = true;
    int currentPlayer = 1;
    KeyCode LastPlayerKey = KeyCode.Mouse0; 
    //  public GameObject player;
    // private MainMenuScript levelLoad;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (settingKey)
        {
            if (setKeys(currentPlayer))
            {
                settingKey = false;
                mm.loadLevel(1);
                Debug.Log("All Done");
            }
        }
    }

    public void setNumOfPlayers(int numPlayers)
    {
        numOfPlayers = numPlayers;

        if (numPlayers == 2)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(false);
            p4.SetActive(false);
        }
        else if (numPlayers == 3)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(false);
        }
        else if (numPlayers == 4)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
        }

        //panel.GetComponent<GameObject> ().SetActive (false);

        //GetComponent<MainMenuScript> ().loadLevel (1);
    }

    public bool setKeys(int player)
    {
        KeyCode lastKeyHit = KeyCode.None;
        for (int x = 0; x < (int)KeyCode.Mouse6; x++)
        {
            if (Input.GetKeyDown((KeyCode)x))
            {
                lastKeyHit = (KeyCode)x;
            }
        }
        if (lastKeyHit != KeyCode.None && lastKeyHit != LastPlayerKey)
        {
            switch (player)
            {
                case 1:
                    k1 = lastKeyHit;
                    p1.GetComponentInChildren<Text>().text = lastKeyHit.ToString();
                    currentPlayer++;
                    break;
                case 2:
                    k2 = lastKeyHit;
                    p2.GetComponentInChildren<Text>().text = lastKeyHit.ToString();
                    currentPlayer++;
                    break;
                case 3:
                    k3 = lastKeyHit;
                    p3.GetComponentInChildren<Text>().text = lastKeyHit.ToString();
                    currentPlayer++;
                    break;
                case 4:
                    k4 = lastKeyHit;
                    p4.GetComponentInChildren<Text>().text = lastKeyHit.ToString();
                    currentPlayer++;
                    break;
            }
            if (currentPlayer == numOfPlayers + 1) 
            {
                return true;
            }
        }
        return false;
    }

    public void addScore(int playerNum, int score)
    {
        players[playerNum] += score;
    }

    public int[] getLeaderboard()
    {
        return players;
    }
}
