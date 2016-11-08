using UnityEngine;
using System.Collections;

public class Player_Ctrl : MonoBehaviour {
	public float SPD = 3f;
	public float maxLif = 100f;
	public float curLif=100f;
	public GameObject plr=null;
	public static Player_Ctrl Instance;
	private CharacterController cc = null;
	public float Gravity = 9.8f;
	// Use this for initialization
	void Awake(){
		Instance = this;
	}
	void Start () {
		cc = plr.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		move ();
		gravity ();
	}
	void gravity(){
		cc.Move (Gravity*Vector3.down);
	}
	void move(){
		Vector3 dr = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		cc.Move (dr.normalized* SPD*Time.deltaTime);
		//Debug.Log (ud + "," + lr);
	}
}
