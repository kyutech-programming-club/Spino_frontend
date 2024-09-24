using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Cloud;
    public int i;
    public string text;
    private List<string> true_musical_scale_List = new List<string>();
    private GameObject obja;
    private GameObject objb;
    private GameObject objc;
    private GameObject objd;
    private GameObject obje;
    private GameObject objf;
    private GameObject objg;
    private GameObject objh;
    private GameObject obji;
    private GameObject objj;
    private GameObject objk;
    private GameObject objl;
    private GameObject objm;
    private GameObject objn;
    private GameObject objo;
    private GameObject objp;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        true_musical_scale_List = musical_scales_List.true_musical_scales;
        Instancewall(0);
        Instancewall(1);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Check(text);
        }
    }
    void Check(string musical_scale)
    {

        string true_musical_scale = true_musical_scale_List[i];
        Instancewall(i);
        i += 1;
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
                Debug.Log("成功");
            }
            else
            {
                Debug.Log("失敗");
            }
        }

    }
    void Instancewall(int k)
    {
        Destroy(obja);
        Destroy(objb);
        Destroy(objc);
        Destroy(objd);
        Destroy(obje);
        Destroy(objf);
        Destroy(objg);
        Destroy(objh);
        Destroy(obji);
        Destroy(objj);
        Destroy(objk);
        Destroy(objl);
        Destroy(objm);
        Destroy(objn);
        Destroy(objo);
        Destroy(objp);
        string true_musical_scale = true_musical_scale_List[k];
        obja = Instantiate(Cloud, transform.position + new Vector3(15f, 15f, 50f), Quaternion.identity);
        objb = Instantiate(Cloud, transform.position + new Vector3(15f, 5f, 50f), Quaternion.identity);
        objc = Instantiate(Cloud, transform.position + new Vector3(15f, -5f, 50f), Quaternion.identity);
        objd = Instantiate(Cloud, transform.position + new Vector3(15f, -15f, 50f), Quaternion.identity);
        obje = Instantiate(Cloud, transform.position + new Vector3(5f, 15f, 50f), Quaternion.identity);
        objf = Instantiate(Cloud, transform.position + new Vector3(5f, 5f, 50f), Quaternion.identity);
        objg = Instantiate(Cloud, transform.position + new Vector3(5f, -5f, 50f), Quaternion.identity);
        objh = Instantiate(Cloud, transform.position + new Vector3(5f, -15f, 50f), Quaternion.identity);
        obji = Instantiate(Cloud, transform.position + new Vector3(-5f, 15f, 50f), Quaternion.identity);
        objj = Instantiate(Cloud, transform.position + new Vector3(-5f, 5f, 50f), Quaternion.identity);
        objk = Instantiate(Cloud, transform.position + new Vector3(-5f, -5f, 50f), Quaternion.identity);
        objl = Instantiate(Cloud, transform.position + new Vector3(-5f, -15f, 50f), Quaternion.identity);
        objm = Instantiate(Cloud, transform.position + new Vector3(-15f, 15f, 50f), Quaternion.identity);
        objn = Instantiate(Cloud, transform.position + new Vector3(-15f, 5f, 50f), Quaternion.identity);
        objo = Instantiate(Cloud, transform.position + new Vector3(-15f, -5f, 50f), Quaternion.identity);
        objp = Instantiate(Cloud, transform.position + new Vector3(-15f, -15f, 50f), Quaternion.identity);
        if (true_musical_scale == "ド5")
        {
            Destroy(objl);
            Destroy(objk);
            Destroy(objo);
            Destroy(objp);
            gameObject.transform.position = gameObject.transform.position + new Vector3(10, -10, 50);
        }
        else if (true_musical_scale == "レ5")
        {
            Destroy(objc);
            Destroy(objg);
            Destroy(objd);
            Destroy(objh);
            gameObject.transform.position = gameObject.transform.position + new Vector3(-10, -10, 50);
        }
        else if (true_musical_scale == "ミ5")
        {
            Destroy(objb);
            Destroy(objf);
            Destroy(objc);
            Destroy(objg);
            gameObject.transform.position = gameObject.transform.position + new Vector3(-10, 0, 50);
        }
        else if (true_musical_scale == "ファ5")
        {
            Destroy(obji);
            Destroy(obje);
            Destroy(objf);
            Destroy(objj);
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, 10, 50);

        }
        else if (true_musical_scale == "ソ5")
        {
            Destroy(objj);
            Destroy(objn);
            Destroy(objo);
            Destroy(objp);
            gameObject.transform.position = gameObject.transform.position + new Vector3(10, 0, 50);

        }
        else if (true_musical_scale == "ラ5")
        {
            Destroy(objg);
            Destroy(objk);
            Destroy(objh);
            Destroy(objl);
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, -10, 50);

        }
        else if (true_musical_scale == "シ5")
        {
            Destroy(obja);
            Destroy(objb);
            Destroy(obje);
            Destroy(objf);
            gameObject.transform.position = gameObject.transform.position + new Vector3(10, 10, 50);

        }
        else if (true_musical_scale == "ド6")
        {
            Destroy(obji);
            Destroy(objj);
            Destroy(objm);
            Destroy(objn);
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, 10, 50);

        }

    }


}
