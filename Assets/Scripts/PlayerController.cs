using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.03f;// 動く速さ
    public float y = 0;
    public float posz = 0;
    public float z = 0;
    public Text scoreText;
    public Text winText;
    
    private Rigidbody rb;//Rigidbody
    private int score;


    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();

        score = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        if (transform.position.x < 13)
        {
            z = 0.1f;
            var movement = new Vector3(-moveHorizontal, y, -z);
            rb.AddForce(movement * speed);
        }
        else
        {
            //カーソルキーの入力に合わせて移動方向を設定
            var movement = new Vector3(0, y, moveVertical);
            //Rigitbodyに与えて球を動かす
            rb.AddForce(movement * speed);
        }

        if(transform.position.y < -10){
            SceneManager.LoadScene("SampleScene");
        }
    }

    //球が他のオブジェクトにぶつかった時に呼び出される
    void OnTriggerEnter(Collider other)
    {
        //ぶつかったオブジェクトが収集アイテムだった場合
        if(other.gameObject.CompareTag("Pick Up"))
        {
            //その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            score = score + 1;

            SetCountText();
        }

        if (other.gameObject.CompareTag("kugi"))
        {
            
        }
    }

    void SetCountText()
    {
        scoreText.text = "Count: " + score.ToString();

        if(score >= 5){
            winText.text = "You Win!";
        }
    }
}
