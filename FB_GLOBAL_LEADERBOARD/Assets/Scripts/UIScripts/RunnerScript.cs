using UnityEngine;
using System.Collections;

public class RunnerScript : MonoBehaviour {

	private Animator animator;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		animator.SetFloat("Speed",vertical);
	//	animator.SetFloat("Direction",horizontal);
	}
}
