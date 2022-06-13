using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int player,bot = 0;
    public TextMeshProUGUI Text;
    public enum GameState{
        Home,
        Gameplay,
        GameOver,
        Win
    }

    private GameState Cur_gameState;
    [SerializeField] private GameObject HomePanel,GamePlay,GameOverPanel, ScorePanel, WinPanel;
    void Start()
    {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
        SetGameState(GameState.Home);
        Time.timeScale = 0;
    }

    public void changeScore(string name){
        Debug.Log(name);
        if(name == "Player"){
            player++;
        }else bot++;
        Text.text = player.ToString() + " : " + bot.ToString();
        if(player == 10) SetGameState(GameState.Win);
        if(bot == 10) SetGameState(GameState.GameOver);
    }

    public void SetGameState(GameState gameState){
        Cur_gameState = gameState;
        if(gameState == GameState.Win) 
            AudioManager.instance.YouWin();
        if(gameState == GameState.GameOver) 
            AudioManager.instance.YouLose();
        GamePlay.SetActive(gameState == GameState.Gameplay);
        ScorePanel.SetActive(gameState == GameState.Gameplay);
        HomePanel.SetActive(gameState == GameState.Home);
        GameOverPanel.SetActive(gameState == GameState.GameOver);
        WinPanel.SetActive(gameState == GameState.Win);
    }

    public void PlayBtn(){
        SetGameState(GameState.Gameplay);
        Time.timeScale = 1;
        player = bot = 0;
        Text.text = player.ToString() + " : " + bot.ToString();
        Ball.instance.ResetBall();
    }

    public void GameOverBtn(){
        SetGameState(GameState.Home);
    }
}
