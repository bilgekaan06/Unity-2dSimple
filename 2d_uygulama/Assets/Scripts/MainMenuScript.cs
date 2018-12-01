using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuScript : MonoBehaviour
{
    public Text EnterNick;
    public GameObject ImageEnter;
    public static string myNick;

    public void HoldNick()
    {
        myNick = EnterNick.text;
        ImageEnter.SetActive(false);
    }
}
