using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPoint : MonoBehaviour
{
    //nome da nivel a ser carregado
    public string lvlName;
   
    void OnCollisionEnter2D(Collision2D collision)
    {
        //se o Player colider com o ponto final o próximo nivel é carregada
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(lvlName);
        }
    }
}
