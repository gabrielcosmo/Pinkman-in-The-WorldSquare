using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //pontuação total
    public int totalScore;
    //componente de texto
    public Text scoreText;
    // tela de gameover
    public GameObject gameOver;

    //forma de manter a classe estatica, assim será possível acessar todos os menbros desta por meio de instance
    public static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        //instance recebe um objeto GameController
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Não há necessidade do metodo Uptade, pois este não é um componente visual
    }

    public void UptadeScoreText()
    {
        //componente de texto da UI recebe o valor da pontuação, em formato de texto
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        //ativando a tela de gameover
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvName)
    {
        //reincia a cena indicada pelo método
        SceneManager.LoadScene(lvName);
    }
}
