using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
    public float fallingTime;
    //componente terget joint 2D
    private TargetJoint2D target;
    //componente box collider2D
    private BoxCollider2D boxCol;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        //se ocorrer colisão com objeto de layer 8 (ground)
        if (collider.gameObject.tag == "Player")
        {
            //invocando o método Folling em certo tempo determinado, em segundos, por fallingTime
           Invoke("Falling", fallingTime);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        //se colidir com o objeto gameover o objeto é destruido
        if (collider.gameObject.layer == 9){
            Destroy(gameObject);
        }
    }
    void Falling()
    {
        //o player fica parado
        target.enabled = false;
        //animação do player desativada
        boxCol.isTrigger = true;
    }
}
