using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{  
    //velocidade
    public float Speed; 
    //força do pulo
    public float JumpForce; 
   
    //Estado do Player: pulando ou não
    public bool isJumping;
    public bool doubleJumping;
    
    //componente de gravidade do Player
    private Rigidbody2D rig;
    //componente de animações do Player
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        //movendo-se para a direita
        if (Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            
        } 
        //movendo-se para a esquerda
        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("walk", true);
            //invertendo posição
            transform.eulerAngles = new Vector3(0f, 180f, 0f);         
        }
        //senão parado
        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("walk", false);
        }
        
    }

    void Jump()
    {
        //Se a tecla associada a Jump for pressionada (tecla padrão é Space) E o Player não estiver pulando ele pula
        if (Input.GetButtonDown("Jump")) 
        {
            if(!isJumping)
            {
                //adicionando uma força (impulso) sobre o Player no sentido (x=0, y=JumpForce)
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJumping = true;
            }
            
            else
            {
                if(doubleJumping)
                {
                    //adicionando uma força (impulso) sobre o Player no sentido (x=0, y=JumpForce)
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJumping = false;
                }
            }
        }
    }

    //Ao acontecer uma colisão
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Se Player coludir com um game object de layer 8 (ground)
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
        //se houver colisão com um objeto spilke ou com objto Saw ocorre o game over
        if (collision.gameObject.tag == "spike" || collision.gameObject.tag == "Saw")
        {
            //aativando a tela de game over quando o Player colidir com os espinhos
            GameController.instance.ShowGameOver();
            //o Player é destruído
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }

    //Após a colisão
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
            anim.SetBool("walk", true);
        }
    }
}
