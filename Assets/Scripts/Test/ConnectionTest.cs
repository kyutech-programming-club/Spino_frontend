using System;
using System.Collections;
using System.Collections.Generic;
using PythonConnection;
using UnityEngine;

public class ConnectionTest : MonoBehaviour
{
    //Pythonへ送信するデータ形式
    [Serializable]
    private class SendingData
    {
        public SendingData(int testValue0, string testValue1)
        {
            this.testValue0 = testValue0;
            this.testValue1 = testValue1;
        }

        public int testValue0;

        [SerializeField]
        public string testValue1;
    }

    void Start()
    {
        //データ受信時時のコールバックを登録
        PythonConnector.instance.RegisterAction(typeof(TestDataClass), OnDataReceived);

        //Pythonへの接続を開始
        if (PythonConnector.instance.StartConnection())
        {
            Debug.Log("Connected");
        }
        else
        {
            Debug.Log("Connection Failed");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PythonConnector.instance.StopConnection();
            Debug.Log("Stop");
        }
    }

    public void OnTimeout()
    {
        Debug.Log("Timeout");
    }

    public void OnStop()
    {
        Debug.Log("Stopped");
    }

    //データ受信時のコールバック
    public void OnDataReceived(DataClass data)
    {
        //DataClass型で渡されてしまうため、明示的に型変換
        TestDataClass testData = data as TestDataClass;

        //受け取り結果表示
        Debug.Log("testValue0: " + testData.testValue0);
        Debug.Log("testValue1: " + testData.testValue1);
    }
}


