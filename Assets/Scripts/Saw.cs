using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{

    public float speed;
    public float moveTime;

    private bool dirRight = true;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // se dirReight verdadeiro a serra vai para a direita;
        if(dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        //senão vai para a esquerda;
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        //timer recebe o tempo atual no jogo
        timer += Time.deltaTime;

        //se timer for maior que moveTime (o tempo de movimento da serra)
        if(timer >= moveTime)
        {
            //a direção é invertida e timer é zerado
            dirRight = !dirRight;
            timer = 0f;
        }
    }
}
