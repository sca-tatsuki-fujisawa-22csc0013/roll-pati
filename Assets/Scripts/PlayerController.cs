using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.03f;// ��������
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
        //Rigidbody���擾
        rb = GetComponent<Rigidbody>();

        score = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //�J�[�\���L�[�̓��͂��擾
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
            //�J�[�\���L�[�̓��͂ɍ��킹�Ĉړ�������ݒ�
            var movement = new Vector3(0, y, moveVertical);
            //Rigitbody�ɗ^���ċ��𓮂���
            rb.AddForce(movement * speed);
        }

        if(transform.position.y < -10){
            SceneManager.LoadScene("SampleScene");
        }
    }

    //�������̃I�u�W�F�N�g�ɂԂ��������ɌĂяo�����
    void OnTriggerEnter(Collider other)
    {
        //�Ԃ������I�u�W�F�N�g�����W�A�C�e���������ꍇ
        if(other.gameObject.CompareTag("Pick Up"))
        {
            //���̎��W�A�C�e�����\���ɂ��܂�
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
