using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orange : MonoBehaviour
{
    //componente sprite renderer
    private SpriteRenderer sr;
    //componente de colisão
    private CircleCollider2D circle;
    //referencia ao game object Collected
    public GameObject collected;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //executado se houver colisões / usado no lugar de OnCollisionEnter2D pois orange é um gameObject trigger, ou seja, "transparente" e com colisor
    void OnTriggerEnter2D(Collider2D collider)
    {
        //se colidir com um objeto de tag Player
        if(collider.gameObject.tag == "Player")
        {
            //desabilitando o sprite renderer e o circle collider2D
            sr.enabled = false;
            circle.enabled = false;
            //habilitando objeto collected
            collected.SetActive(true);
            //aumentando a pontuação somando ao atributo totalScore da classe GameController o valor de Score
            GameController.instance.totalScore += Score;
            //atualizando o valor de pontuação na UI
            GameController.instance.UptadeScoreText();
            //o objeto Orange é destruido depois de 1 segundo
            Destroy(gameObject, 0.3f);
        }

    }
}
