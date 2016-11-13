using UnityEngine;
using System.Collections;

public class Player_Ctrl : MonoBehaviour {
	public float SPD = 3f;
	public float maxLif = 100f;
	public float curLif=100f;
	public GameObject plr=null;
	public static Player_Ctrl Instance;
	private CharacterController cc = null;//角色控制器
	public float Gravity = 9.8f;
	private Animator ac = null;//动作状态机
	// Use this for initialization
	void Awake(){
		Instance = this;
	}
	void Start () {
		cc = plr.GetComponent<CharacterController> ();
		ac = plr.GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dr = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		if (dr != Vector3.zero) {
			move (dr);
			turn (dr);
		} else {
			ac.SetInteger ("activity", 0);
		}
		gravity ();
	}
	void gravity(){
		cc.Move (Gravity*Vector3.down);
	}
	void turn(Vector3 dr){
		Vector3 newDir = Vector3.RotateTowards (transform.forward, dr, 5f* Time.deltaTime, 0.0f);
		newDir.y = 0;
		plr.transform.rotation = Quaternion.LookRotation (dr);
	}
	void move(Vector3 dr){
		ac.SetInteger ("activity", 1);
		cc.Move (dr.normalized* SPD*Time.deltaTime);
		//Debug.Log (ud + "," + lr);
	}
}
