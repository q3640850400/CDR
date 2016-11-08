using UnityEngine;
using System.Collections;

public class Game_Ctrl : MonoBehaviour {
	public static Game_Ctrl Instance = null;
	public int level=0;
	public float timecount = 60f;
	public int state = 0;//0waiting,1playing,2stop,3lose
	void Awake(){
		Instance = this;
		DontDestroyOnLoad (this);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void go(){

	}
	void timetick(){
		timecount -= Time.deltaTime;
		if (timecount < 0)
			timecount = 0;
	}
	void check(){
		if (Player_Ctrl.Instance.curLif <= 0f) {
			state = 3;
		}
	}
	//ATKtheChi
	void makeATK(string name,Vector3 des){
		GameObject g = Resources.Load ("/MyAssets/Prefabs/" + name) as GameObject;
		GameObject.Instantiate (g, des, Quaternion.identity);
	}
}
