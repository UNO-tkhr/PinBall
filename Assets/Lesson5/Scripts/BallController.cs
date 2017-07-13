using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバーを表示するテキスト
	private GameObject gameoverText;
	//スコアを表示するテキスト
	private GameObject scoreObject;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		//シーン中のScoreオブジェクトを取得
		this.scoreObject = GameObject.Find("Score");
	}
	
	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if(this.transform.position.z < this.visiblePosZ){
			//GameoverTextにゲームオーバーを表示
			this.gameoverText.GetComponent<Text>().text = "Game Over";
		}
	}

	//オブジェクトと衝突した時スコアを加算
	void OnCollisionEnter(Collision other) {
		string colTag = other.gameObject.tag;
		int score = int.Parse(scoreObject.GetComponent<Text>().text);

		if(colTag == "SmallStarTag"){
			score += 1;
		} else if(colTag == "LargeStarTag"){
			score += 3;
		}else if(colTag == "SmallCloudTag"){
			score += 5;
		}else if(colTag == "LargeCloudTag"){
			score += 10;
		}
		scoreObject.GetComponent<Text>().text = score.ToString();
	}
}
