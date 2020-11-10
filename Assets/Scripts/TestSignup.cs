using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class TestSignup : MonoBehaviour
{
    public Button m_btnWrite;
    public Button m_btnRead;
    public string m_strWriteMessage;
    public void ButtonActivation(bool _bFlag)
    {
        m_btnWrite.interactable = _bFlag;
        m_btnRead.interactable = _bFlag;
    }
    void Start()
    {
        ButtonActivation(false);
        // ユーザー名とパスワードでログイン
        NCMBUser.LogInAsync("Yamada Tarou", "password", (NCMBException e) => {
            if (e != null)
            {
                UnityEngine.Debug.Log("ログインに失敗: " + e.ErrorMessage);
            }
            else
            {
                UnityEngine.Debug.Log("ログインに成功！");
                ButtonActivation(true);
                Debug.Log(NCMBUser.CurrentUser.ObjectId);
            }
        });
    }
    public void Write()
    {
        ButtonActivation(false);
        // クラスのNCMBObjectを作成
        NCMBObject testClass = new NCMBObject("TestClass");
        //testClass.ObjectId = NCMBUser.CurrentUser.ObjectId;
        testClass["user_obj"] = NCMBUser.CurrentUser;
        testClass["message"] = m_strWriteMessage;
        testClass.SaveAsync((NCMBException e) => {
            if (e != null)
            {
                //エラー処理
            }
            else
            {
                //成功時の処理
                Debug.Log("success");
                ButtonActivation(true);
            }
        });
    }
    public void Read()
    {
        ButtonActivation(false);

        //QueryTestを検索するクラスを作成
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("TestClass");
        //Scoreの値が7と一致するオブジェクト検索
        query.WhereEqualTo("user_obj", NCMBUser.CurrentUser);
        query.FindAsync((List<NCMBObject> objList, NCMBException e) => {
            if (e != null)
            {
                //検索失敗時の処理
            }
            else
            {
                //Scoreが7のオブジェクトを出力
                foreach (NCMBObject obj in objList)
                {
                    Debug.Log(obj["message"]);
                    //Debug.Log("objectId:" + obj.ObjectId);
                }
                ButtonActivation(true);
            }
        });
    }




}
