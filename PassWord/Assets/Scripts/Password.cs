using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 配列無し、繰り返し処理なし
/// できる限り技術的難易度が低いパスワード実装
/// </summary>
public class Password : MonoBehaviour
{
    [SerializeField] private GameObject num4; //4桁目（一番左）の数字群の親オブジェクト
    [SerializeField] private GameObject num3; //3桁目の数字群の親オブジェクト
    [SerializeField] private GameObject num2; //2桁目の数字群の親オブジェクト
    [SerializeField] private GameObject num1; //1桁目（一番右）の数字群の親オブジェクト

    [SerializeField] private Vector4 pass; //入力されたパスワードを格納
    [SerializeField] private Vector4 passAnswer = new Vector4(3, 1, 4, 1); //パスワードの答え

    //音楽系の演出を適当につけておく（本題とは外れるので気にしないでください）
    private AudioSource audioSource;
    private AudioClip rightClip;
    private AudioClip wrongClip;

    // Start is called before the first frame update
    void Start()
    {
        //音楽系演出関係諸々取得
        audioSource = this.gameObject.GetComponent<AudioSource>();
        rightClip=Resources.Load("RightAudio") as AudioClip;
        wrongClip=Resources.Load("WrongAudio") as AudioClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (num1.activeSelf==true) //num1が有効だったら
        {
            if (Input.anyKeyDown)//なにかキーが押されたら
            {
                InputNumber(1);
            }
            else //何も押されていなければ
            {
                return; //以下の処理を省略する
                //上記のように、キー入力で処理を発動するようにしとかないと、この下のパスワード正解時の処理にすぐに移行してしまう
            }

            if (pass == passAnswer) //もしパスワードが正解だったら
            {
                //何かしらのアクションをする。（下記のプログラムは適当に書いたやつ）
                GameObject.Find("right").GetComponent<SpriteRenderer>().enabled = true;
                audioSource.PlayOneShot(rightClip);
            }
            else //間違いだったら
            {
                //リセットする
                num1.transform.Find(pass.w.ToString()).gameObject.SetActive(false); //1桁目の数字非表示
                num1.SetActive(false); //1桁目非表示
                num2.transform.Find(pass.z.ToString()).gameObject.SetActive(false); //2桁目の数字非表示
                num2.SetActive(false); //2桁目非表示
                num3.transform.Find(pass.y.ToString()).gameObject.SetActive(false); //3桁目の数字非表示
                num3.SetActive(false); //3桁目非表示
                num4.transform.Find(pass.x.ToString()).gameObject.SetActive(false); //4桁目の数字非表示
                
                //適当にSEも鳴らしておくか...
                audioSource.PlayOneShot(wrongClip);
            }
        }
        else if (num2.activeSelf==true) //num2が有効だったら
        {
            InputNumber(2);
        }
        else if (num3.activeSelf==true) //num3が有効だったら
        {
            InputNumber(3);
        }
        else if (num4.activeSelf==true) //num4が有効だったら
        {
            InputNumber(4);
        }
    }

    //何度も書くのが面倒だったので関数にしました
    //理解度によっては、updateに直書きさせていくのもアリ
    
    private void InputNumber(int digits) //何桁目の入力なのか、引数で指定する
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) //0キーがおされたら
        {

            if (digits == 4) //4桁目のとき
            {
                //入力した数字を表示する
                num4.transform.Find("0").gameObject.SetActive(true);
                
                pass.x = 0; //入力された数字を保存する
                num3.SetActive(true); //num3を有効にする
            }
            else if(digits==3) //3桁目のとき
            {
                //入力した数字を表示する
                num3.transform.Find("0").gameObject.SetActive(true);
                
                pass.y = 0; //入力された数字を保存する
                num2.SetActive(true); //num2を有効にする
            }
            else if(digits==2) //2桁目のとき
            {
                //入力した数字を表示する
                num2.transform.Find("0").gameObject.SetActive(true);
                
                pass.z = 0; //入力された数字を保存する
                num1.SetActive(true); //num1を有効にする
            }
            else if(digits==1) //1桁目のとき
            {
                //入力した数字を表示する
                num1.transform.Find("0").gameObject.SetActive(true);
                
                pass.w = 0; //入力された数字を保存する
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1)) //1キーがおされたら
        {
            if (digits == 4) //4桁目のとき
            {
                //入力した数字を表示する
                num4.transform.Find("1").gameObject.SetActive(true);
                
                pass.x = 1; //入力された数字を保存する
                num3.SetActive(true); //num3を有効にする
            }
            else if(digits==3) //3桁目のとき
            {
                //入力した数字を表示する
                num3.transform.Find("1").gameObject.SetActive(true);
                
                pass.y = 1; //入力された数字を保存する
                num2.SetActive(true); //num2を有効にする
            }
            else if(digits==2) //2桁目のとき
            {
                //入力した数字を表示する
                num2.transform.Find("1").gameObject.SetActive(true);
                
                pass.z = 1; //入力された数字を保存する
                num1.SetActive(true); //num1を有効にする
            }
            else if(digits==1) //1桁目のとき
            {
                //入力した数字を表示する
                num1.transform.Find("1").gameObject.SetActive(true);
                
                pass.w = 1; //入力された数字を保存する
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) //2キーがおされたら
        {
            if (digits == 4) //4桁目のとき
            {
                //入力した数字を表示する
                num4.transform.Find("2").gameObject.SetActive(true);
                
                pass.x = 2; //入力された数字を保存する
                num3.SetActive(true); //num3を有効にする
            }
            else if(digits==3) //3桁目のとき
            {
                //入力した数字を表示する
                num3.transform.Find("2").gameObject.SetActive(true);
                
                pass.y = 2; //入力された数字を保存する
                num2.SetActive(true); //num2を有効にする
            }
            else if(digits==2) //2桁目のとき
            {
                //入力した数字を表示する
                num2.transform.Find("2").gameObject.SetActive(true);
                
                pass.z = 2; //入力された数字を保存する
                num1.SetActive(true); //num1を有効にする
            }
            else if(digits==1) //1桁目のとき
            {
                //入力した数字を表示する
                num1.transform.Find("2").gameObject.SetActive(true);
                
                pass.w = 2; //入力された数字を保存する
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) //3キーがおされたら
        {
            if (digits == 4) //4桁目のとき
            {
                //入力した数字を表示する
                num4.transform.Find("3").gameObject.SetActive(true);
                
                pass.x = 3; //入力された数字を保存する
                num3.SetActive(true); //num3を有効にする
            }
            else if(digits==3) //3桁目のとき
            {
                //入力した数字を表示する
                num3.transform.Find("3").gameObject.SetActive(true);
                
                pass.y = 3; //入力された数字を保存する
                num2.SetActive(true); //num2を有効にする
            }
            else if(digits==2) //2桁目のとき
            {
                //入力した数字を表示する
                num2.transform.Find("3").gameObject.SetActive(true);
                
                pass.z = 3; //入力された数字を保存する
                num1.SetActive(true); //num1を有効にする
            }
            else if(digits==1) //1桁目のとき
            {
                //入力した数字を表示する
                num1.transform.Find("3").gameObject.SetActive(true);
                
                pass.w = 3; //入力された数字を保存する
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) //4キーがおされたら
        {
            if (digits == 4) //4桁目のとき
            {
                //入力した数字を表示する
                num4.transform.Find("4").gameObject.SetActive(true);
                
                pass.x = 4; //入力された数字を保存する
                num3.SetActive(true); //num3を有効にする
            }
            else if(digits==3) //3桁目のとき
            {
                //入力した数字を表示する
                num3.transform.Find("4").gameObject.SetActive(true);
                
                pass.y = 4; //入力された数字を保存する
                num2.SetActive(true); //num2を有効にする
            }
            else if(digits==2) //2桁目のとき
            {
                //入力した数字を表示する
                num2.transform.Find("4").gameObject.SetActive(true);
                
                pass.z = 4; //入力された数字を保存する
                num1.SetActive(true); //num1を有効にする
            }
            else if(digits==1) //1桁目のとき
            {
                //入力した数字を表示する
                num1.transform.Find("4").gameObject.SetActive(true);
                
                pass.w = 4; //入力された数字を保存する
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5)) //5キーがおされたら
        {
            if (digits == 4) //4桁目のとき
            {
                //入力した数字を表示する
                num4.transform.Find("5").gameObject.SetActive(true);
                
                pass.x = 5; //入力された数字を保存する
                num3.SetActive(true); //num3を有効にする
            }
            else if(digits==3) //3桁目のとき
            {
                //入力した数字を表示する
                num3.transform.Find("5").gameObject.SetActive(true);
                
                pass.y = 5; //入力された数字を保存する
                num2.SetActive(true); //num2を有効にする
            }
            else if(digits==2) //2桁目のとき
            {
                //入力した数字を表示する
                num2.transform.Find("5").gameObject.SetActive(true);
                
                pass.z = 5; //入力された数字を保存する
                num1.SetActive(true); //num1を有効にする
            }
            else if(digits==1) //1桁目のとき
            {
                //入力した数字を表示する
                num1.transform.Find("5").gameObject.SetActive(true);
                
                pass.w = 5; //入力された数字を保存する
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6)) //6キーがおされたら
        {
            if (digits == 4) //4桁目のとき
            {
                //入力した数字を表示する
                num4.transform.Find("6").gameObject.SetActive(true);
                
                pass.x = 6; //入力された数字を保存する
                num3.SetActive(true); //num3を有効にする
            }
            else if(digits==3) //3桁目のとき
            {
                //入力した数字を表示する
                num3.transform.Find("6").gameObject.SetActive(true);
                
                pass.y = 6; //入力された数字を保存する
                num2.SetActive(true); //num2を有効にする
            }
            else if(digits==2) //2桁目のとき
            {
                //入力した数字を表示する
                num2.transform.Find("6").gameObject.SetActive(true);
                
                pass.z = 6; //入力された数字を保存する
                num1.SetActive(true); //num1を有効にする
            }
            else if(digits==1) //1桁目のとき
            {
                //入力した数字を表示する
                num1.transform.Find("6").gameObject.SetActive(true);
                
                pass.w = 6; //入力された数字を保存する
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7)) //7キーがおされたら
        {
            if (digits == 4) //4桁目のとき
            {
                //入力した数字を表示する
                num4.transform.Find("7").gameObject.SetActive(true);
                
                pass.x = 7; //入力された数字を保存する
                num3.SetActive(true); //num3を有効にする
            }
            else if(digits==3) //3桁目のとき
            {
                //入力した数字を表示する
                num3.transform.Find("7").gameObject.SetActive(true);
                
                pass.y = 7; //入力された数字を保存する
                num2.SetActive(true); //num2を有効にする
            }
            else if(digits==2) //2桁目のとき
            {
                //入力した数字を表示する
                num2.transform.Find("7").gameObject.SetActive(true);
                
                pass.z = 7; //入力された数字を保存する
                num1.SetActive(true); //num1を有効にする
            }
            else if(digits==1) //1桁目のとき
            {
                //入力した数字を表示する
                num1.transform.Find("7").gameObject.SetActive(true);
                
                pass.w = 7; //入力された数字を保存する
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8)) //8キーがおされたら
        {
            if (digits == 4) //4桁目のとき
            {
                //入力した数字を表示する
                num4.transform.Find("8").gameObject.SetActive(true);
                
                pass.x = 8; //入力された数字を保存する
                num3.SetActive(true); //num3を有効にする
            }
            else if(digits==3) //3桁目のとき
            {
                //入力した数字を表示する
                num3.transform.Find("8").gameObject.SetActive(true);
                
                pass.y = 8; //入力された数字を保存する
                num2.SetActive(true); //num2を有効にする
            }
            else if(digits==2) //2桁目のとき
            {
                //入力した数字を表示する
                num2.transform.Find("8").gameObject.SetActive(true);
                
                pass.z = 8; //入力された数字を保存する
                num1.SetActive(true); //num1を有効にする
            }
            else if(digits==1) //1桁目のとき
            {
                //入力した数字を表示する
                num1.transform.Find("8").gameObject.SetActive(true);
                
                pass.w = 8; //入力された数字を保存する
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9)) //9キーがおされたら
        {
            if (digits == 4) //4桁目のとき
            {
                //入力した数字を表示する
                num4.transform.Find("9").gameObject.SetActive(true);
                
                pass.x = 9; //入力された数字を保存する
                num3.SetActive(true); //num3を有効にする
            }
            else if(digits==3) //3桁目のとき
            {
                //入力した数字を表示する
                num3.transform.Find("9").gameObject.SetActive(true);
                
                pass.y = 9; //入力された数字を保存する
                num2.SetActive(true); //num2を有効にする
            }
            else if(digits==2) //2桁目のとき
            {
                //入力した数字を表示する
                num2.transform.Find("9").gameObject.SetActive(true);
                
                pass.z = 9; //入力された数字を保存する
                num1.SetActive(true); //num1を有効にする
            }
            else if(digits==1) //1桁目のとき
            {
                //入力した数字を表示する
                num1.transform.Find("9").gameObject.SetActive(true);
                
                pass.w = 9; //入力された数字を保存する
            }
        }
    }
}
