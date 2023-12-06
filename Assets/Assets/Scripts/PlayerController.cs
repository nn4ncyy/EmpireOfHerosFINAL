using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;
    

    private Vector2 input;

    private Animator animator;

    private bool flipped = false;

    public LayerMask interactableLayer;

    public AudioSource walkEffect;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

   

    public void HandleUpdate()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                //animator.SetFloat("moveX", input.x);
                //animator.SetFloat("moveY", input.y);
                walkEffect.Play();
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if(IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }

        animator.SetFloat("Speed", Mathf.Abs(input.magnitude * moveSpeed));


        if (input.x < 0 && !flipped)
        {
            flip();
        }

        if(input.x > 0 && flipped)
        {
            flip();
        }
        
        if (Input.GetKeyDown(KeyCode.Z))
            Interact();

    }


    void Interact()
    {

        var facingDir = new Vector3(input.x, input.y);
        var interactPos = transform.position + facingDir;

        Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        if(collider != null)
        {
            Debug.Log("there is an NPC here!");
        }
    }

    void flip()
    {
        Vector3 currentScale = animator.transform.localScale;
        currentScale.x *= -1;
        animator.transform.localScale = currentScale;

        flipped = !flipped;
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.2f, interactableLayer) != null)
        {
            return false;
        }
        return true;
    }
 
} 
