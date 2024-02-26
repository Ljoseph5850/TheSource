using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderManager : MonoBehaviour
{
    public float speed;
	private Rigidbody2D rb;
	
	private float inputHorizontal;
	private float inputVertical;
	public bool isClimbing;
	
	public float distance;
	public LayerMask whatIsLadder;

	public PlayerAnimator animator;
	
	void Start(){
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponentInChildren<PlayerAnimator> ();
	}
	
	void FixedUpdate(){
		
		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
		
		if(hitInfo.collider != null){
				isClimbing = true;
				animator.IsClimbing();
		}else{
			isClimbing = false;
			animator.NotClimbing();
		}
	}
}
