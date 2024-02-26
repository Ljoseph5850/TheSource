using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public float speed;
	private Rigidbody2D rb;
	
	private float inputHorizontal;
	private float inputVertical;
	public bool isFalling, isJumping;

    private float jumpingTime = .669f;
    private float timer = 0f;
	
	public float distance;
	public LayerMask whatIsHole;

	public PlayerAnimator animator;
	
	void Start(){
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponentInChildren<PlayerAnimator> ();
	}
	
	void FixedUpdate(){
        if(Input.GetKeyDown(KeyCode.Space)){
            isJumping = true;
        }
		if(isJumping){
			timer += Time.deltaTime;
		}
		if(timer > jumpingTime){
            timer = 0;
            isJumping = false;
        }
		
		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsHole);
		
		if((hitInfo.collider != null) && !isJumping){
				isFalling = true;
				animator.KnockDown();
		}else{
			isFalling = false;
			animator.Idle();
		}
	}
}
