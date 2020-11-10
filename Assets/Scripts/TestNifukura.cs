using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class TestNifukura : MonoBehaviour
{
    void Start()
    {
        // クラスのNCMBObjectを作成
        NCMBObject testClass = new NCMBObject("TestClass");

        //testClass.ObjectId = "nGWsu2C12bmu2Q97";

        testClass["message"] = "changetest";
        testClass["message2"] = "changetest";
        testClass.SaveAsync((NCMBException e) => {
            if (e != null)
            {
                //エラー処理
            }
            else
            {
                //成功時の処理
                Debug.Log("success");
            }
        });

        /*
        testClass.FetchAsync((NCMBException e) =>
        {
            if (e != null)
            {
                //エラー処理
            }
            else
            {
                //成功時の処理
                Debug.Log(testClass["message"]);
            }
        });
        */

        /*
        // オブジェクトに値を設定
        Debug.Log(testClass.ObjectId);
        testClass["message"] = "UnityLiveNow!!!";


        // データストアへの登録
        testClass.SaveAsync();
        */
    }


    void Update()
    {
        
    }
}
