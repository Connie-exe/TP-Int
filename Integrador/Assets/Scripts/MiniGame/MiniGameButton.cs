using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameButton : MonoBehaviour
{
    public Button btn_miniGame;

    void Start()
    {
        //btn_miniGame = GetComponent<Button>();
        btn_miniGame.enabled = false;
    }

    void Update()
    {
        EnableMiniGame();
    }

    public void EnableMiniGame()
    {
        if(MoneySystem.cant_founds <= 200)
        {
            btn_miniGame.enabled = true;
        }
    }
}
