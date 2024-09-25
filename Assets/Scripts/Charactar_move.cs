using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactar_move : MonoBehaviour
{
    public GameObject Cloud;
    public int i;
    public string text;
    private List<string> true_musical_scale_List = new List<string>();
    private GameObject Up;
    private GameObject Down;
    private GameObject Left;
    private GameObject Right;
    private float speed = 5f;
    private float SpeedTime;
    private float span;
    private int m;
    private GameObject a;

    private Vector3 addposition;
    private GameObject b;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {

        i = 0;
        true_musical_scale_List = musical_scales_List.true_musical_scales;

        m = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SpeedTime += Time.deltaTime;
        span += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A))
        {
            Check(text);
        }
        // if (span >= 3)
        // {
        //     Check(true_musical_scale_List[m]);
        //     m += 1;
        //     span = 0;
        //     SpeedTime = 0;
        // }
        gameObject.transform.position = gameObject.transform.position + addposition;

    }
    public void Check(string musical_scale)
    {
        SpeedTime = 0;
        string true_musical_scale = true_musical_scale_List[i];
        i += 1;
        Instancewall(i +1);
        if (true_musical_scale_List[i] != "休符")
        {
            List<string> musical_scale_types = new List<string>() { "ラ4", "シ4", "ド5", "レ5", "ミ5", "ファ5", "ソ5", "ラ5", "シ5", "ド6", "レ6" };
            if (musical_scale_types[0] == true_musical_scale)
            {
                if (musical_scale == musical_scale_types[0] || musical_scale == musical_scale_types[1] || musical_scale == musical_scale_types[10])
                {
                    Debug.Log("seikou");
                }
                else
                {
                    Debug.Log("失敗");
                }
            }
            else if (musical_scale_types[10] == true_musical_scale)
            {
                if (musical_scale == musical_scale_types[0] || musical_scale == musical_scale_types[9] || musical_scale == musical_scale_types[10])
                {
                    Debug.Log("seikou");
                }
                else
                {
                    Debug.Log("失敗");
                }
            }
            else
            {
                for (int j = 1; j <= 9; ++j)
                {
                    if (musical_scale_types[j] == true_musical_scale)
                    {
                        if (musical_scale == musical_scale_types[j] || musical_scale == musical_scale_types[j - 1] || musical_scale == musical_scale_types[j + 1])
                        {
                            if (true_musical_scale == "ド5")
                            {

                                addposition = new Vector3(0.01f, 0.01f, 0.02f) * speed;
                            }
                            else if (true_musical_scale == "レ5")
                            {

                                addposition = new Vector3(-0.01f, -0.01f, 0.02f) * speed;
                            }
                            else if (true_musical_scale == "ミ5")
                            {

                                addposition = new Vector3(-0.01f, 0, 0.02f) * speed;
                            }
                            else if (true_musical_scale == "ファ5")
                            {

                                addposition = new Vector3(0, 0.01f, 0.02f) * speed;

                            }
                            else if (true_musical_scale == "ソ5")
                            {

                                addposition = new Vector3(0.01f, 0, 0.02f) * speed;

                            }
                            else if (true_musical_scale == "ラ5")
                            {

                                addposition = new Vector3(0, -0.01f, 0.02f) * speed;
                            }
                            else if (true_musical_scale == "シ5")
                            {

                                addposition = new Vector3(0.01f, 0.01f, 0.02f) * speed;

                            }
                            else if (true_musical_scale == "ド6")
                            {

                                addposition = new Vector3(0.01f, 0.01f, 0.02f) * speed;

                            }
                            Debug.Log("seikou");
                            break;
                        }
                        else
                        {
                            Debug.Log("失敗");
                            break;
                        }
                    }
                }
            }
        }
        else
        {
            if (musical_scale == "休符")
            {
                Debug.Log("休符成功");
            }
            else
            {
                Debug.Log("失敗");
            }
        }

    }
    void Instancewall(int k)
    {
        a = Instantiate(Cloud, gameObject.transform.position + new Vector3(0, 0, 54), Quaternion.identity);
        string true_musical_scale = true_musical_scale_List[k];
        Up = a.transform.Find("Up").gameObject;
        Left = a.transform.Find("Left").gameObject;
        Right = a.transform.Find("Right").gameObject;
        Down = a.transform.Find("Down").gameObject;

        if (true_musical_scale == "ド5")
        {
            Destroy(Down);
            Destroy(Right);
          
        }
        else if (true_musical_scale == "レ5")
        {

            Destroy(Down);
            Destroy(Left);
         
        }
        else if (true_musical_scale == "ミ5")
        {
            Destroy(Left);
          
        }
        else if (true_musical_scale == "ファ5")
        {
            Destroy(Up);
           

        }
        else if (true_musical_scale == "ソ5")
        {
            Destroy(Right);
        

        }
        else if (true_musical_scale == "ラ5")
        {
            Destroy(Down);
    
        }
        else if (true_musical_scale == "シ5")
        {
            Destroy(Left);
            Destroy(Up);
          

        }
        else if (true_musical_scale == "ド6")
        {
            Destroy(Right);
            Destroy(Down);
         
        }

    }


}
