using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGG : MonoBehaviour
{
    private Rigidbody2D SlimeRigidbody2D;
    [SerializeField] private int nextMove;
    private Animator SlimeAnima;
    private SpriteRenderer SlimeSprite;
    private void Awake()
    {
        SlimeRigidbody2D = GetComponent<Rigidbody2D>();
        SlimeAnima = GetComponent<Animator>();
        SlimeSprite = GetComponent<SpriteRenderer>(); 
        StartCoroutine(Think());
    }


    private void FixedUpdate()
    {
        // move
        SlimeRigidbody2D.velocity = new Vector2 (nextMove, SlimeRigidbody2D.velocity.y);    
        // Platform Check 
        Vector2 vector2 = new Vector2(SlimeRigidbody2D.position.x + nextMove * 0.4f, SlimeRigidbody2D.position.y);
        Debug.DrawRay(vector2, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(vector2, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null)        
            Turn();       
    }
     
    IEnumerator Think() 
    { 
        yield return new WaitForSeconds(3.0f);
        nextMove = Random.Range(-1, 2);
        if (nextMove != 0)
        {
            SlimeAnima.Play("Move");
            SlimeSprite.flipX = nextMove == -1;
        }
        else if(nextMove == 0)
        {
            SlimeAnima.Play("Idle");
        }            
        yield return Think();    
    }
    private void Turn()
    {
        nextMove *= -1;
        SlimeSprite.flipX = nextMove == -1;
        StopCoroutine(Think());
    }






    // 재귀함수 자신을 스스로 호출하는 함수 
    // 처음에는 Invoke를 사용했지만, 코루틴 사용하여 딜레이 
    // private void Think() 
    // { 
    //     //nextMove = Random.Range(-1, 2); 
    //     //Invoke("Think", 5); 
    // } 

}
