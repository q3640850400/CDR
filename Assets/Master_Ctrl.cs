using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Master_Ctrl : MonoBehaviour {
	public static Master_Ctrl Instance = null;
	public int level=1;
	public string PlayerName="oten";
	public float score=0;
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
	void readRecord(){

	}
	public void Go(){
		//Application.LoadLevel ("gamescene");
		SceneManager.LoadScene("LoadScene");
	}
}
