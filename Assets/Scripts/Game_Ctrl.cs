using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
public class Gameinfo{
	public int level;
	public string name;
	public string mode;
	public float x;
	public float y;
	public float z;
	public float mx;
	public float my;
	public float mz;
	public float wait;
}
public class Game_Ctrl : MonoBehaviour {
	public static Game_Ctrl Instance = null;
	public int level=1;//当前关卡数
	public string PlayerName="oven";//玩家姓名
	public float score=0;//累计分数
	public float timecount = 0f;//每关计时器
	public int state = 0;//0waiting,1playing,2stop,3lose
	public static string localUrl;
	public string xmlName="exportxml";//地图名字
	public List<Gameinfo> GameList=null;
	private int list_node = 0;//标号
	void Awake(){
		Instance = this;
		DontDestroyOnLoad (this);
	}
	// Use this for initialization
	void Start () {
		//init ();
	}
	
	// Update is called once per frame
	void Update () {
		switch(state){
		case 0:
			{
				break;
			}
		case 1:
			{
				timetick ();
				if (list_node < GameList.Count) {
					if (GameList [list_node].wait <= timecount) {
						makeATK (GameList [list_node].name, new Vector3 (GameList [list_node].x, GameList [list_node].y, GameList [list_node].z));
						list_node++;
						//Debug.Log ("ddd");
					}
				}
				break;
			}
		case 2:
			{
				break;
			}
		}
	}
	void ReadTMX(int level){//读取xml文件,并存入GameList里
		XmlDocument doc = new XmlDocument();
		doc.Load (localUrl);
		XmlNode xml = doc.SelectSingleNode("ROOT"); 
		//Debug.Log (map);
		//this.x=int.Parse(((XmlElement)map).GetAttribute("width"));//从TMX读取地图大小x
		//this.y=int.Parse(((XmlElement)map).GetAttribute("height"));//从TMX读取地图大小y
		XmlNodeList tables = xml.SelectNodes("table");
		foreach (XmlNode t in tables) {
			XmlElement te= (XmlElement)t;
			int getlevel=int.Parse (te.GetAttribute ("level"));
			if (getlevel == level) {
				Gameinfo info0 = new Gameinfo ();
				info0.level = int.Parse (te.GetAttribute ("level"));
				info0.name = te.GetAttribute ("name");
				info0.mode = te.GetAttribute ("mode");
				info0.x = float.Parse (te.GetAttribute ("x"));
				info0.y = float.Parse (te.GetAttribute ("y"));
				info0.z = float.Parse (te.GetAttribute ("z"));
				info0.mx = float.Parse (te.GetAttribute ("mx"));
				info0.my = float.Parse (te.GetAttribute ("my"));
				info0.mz = float.Parse (te.GetAttribute ("mz"));
				info0.wait = float.Parse (te.GetAttribute ("wait"));
				GameList.Add (info0);
			}
		}

	}
	//倒计时
	void countdown(){
		state = 1;
	}
	void timetick(){
		timecount += Time.deltaTime;
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
		des.y = GameObject.Find ("PosSet").transform.position.y;//取得参考点的Y坐标
		GameObject g = Resources.Load ("MyAssets/Prefabs/" + name) as GameObject;
		GameObject.Instantiate (g, des, Quaternion.identity);
	}
	void init(){
		GameList = new List<Gameinfo>();
		list_node = 0;
		localUrl = Application.dataPath + "/Resources/MyAssets/level/"+xmlName+".xml";
		ReadTMX (level);
		SceneManager.LoadScene("GameScene");
		enterGameScene ();
	}
	//读取玩家资料
	void enterReadyScene(){
		//level = 1;
		//score=0;
	}
	//读取游戏数据
	void enterLoadScene(){
		init ();
	}
	//开始游戏
	void enterGameScene(){
		countdown ();
	}
	public void Go(string scenename){
		//Application.LoadLevel ("gamescene");
		SceneManager.LoadScene(scenename);
		if (scenename == "LoadScene") {
			enterLoadScene ();
			//Debug.Log ("LoadScene");
		}
	}
}
