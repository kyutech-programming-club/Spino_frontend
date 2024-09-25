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
    private Vector3 target;
    private LineRenderer lineRenderer;
    private int currentSegment = 0;
    private float t = 0f; 
    public float duration = 5f;
    public bool canMove;
    private float delayspan;
    private int k;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        i = 0;
        true_musical_scale_List = musical_scales_List.true_musical_scales;
        m = 0;
        for(int k = 0; k<=true_musical_scale_List.Count-1;++k)
        {
        Instancewall(k);
        }
    }
void Update()
{
  
    span += Time.deltaTime;

    if (Input.GetKeyDown(KeyCode.A))
    {
        Check(text);
    }
    

    delayspan += Time.deltaTime;
    if(canMove == true)
    {
     if(SpeedTime >= 0)
   {
      SpeedTime -= Time.deltaTime;
        if (currentSegment < lineRenderer.positionCount - 1)
        {
            Vector3 startPosition = lineRenderer.GetPosition(currentSegment);
            Vector3 endPosition = lineRenderer.GetPosition(currentSegment + 1);
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            t += Time.deltaTime;

            if (t >= 1f)
            {
                t = 0f;
                currentSegment++;
                canMove = false;
            }
        }
        else
        {
            
            currentSegment = 0; 
        }
   }
    }
    
}

    public void Check(string musical_scale)
    {
        string true_musical_scale = true_musical_scale_List[i];
        i += 1;
        Instancewall(i + 1);
        if (true_musical_scale_List[i] != "休符")
        {
            List<string> musical_scale_types = new List<string>() { "ラ4", "シ4", "ド5", "レ5", "ミ5", "ファ5", "ソ5", "ラ5", "シ5", "ド6", "レ6" };
            if (musical_scale_types[0] == true_musical_scale)
            {
                if (musical_scale == musical_scale_types[0] || musical_scale == musical_scale_types[1] || musical_scale == musical_scale_types[10])
                {
                    speed += 0.3f;
                }
                else
                {
                  canMove = false;
                }
            }
            else if (musical_scale_types[10] == true_musical_scale)
            {
                if (musical_scale == musical_scale_types[0] || musical_scale == musical_scale_types[9] || musical_scale == musical_scale_types[10])
                {
                    speed += 0.3f;
                }
                else
                {
                   canMove = false;
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
                            speed += 0.3f;
                            if (true_musical_scale == "ド5")
                            {
                             
                            }
                            else if (true_musical_scale == "レ5")
                            {
                           
                            }
                            else if (true_musical_scale == "ミ5")
                            {
                            
                            }
                            else if (true_musical_scale == "ファ5")
                            {
                            
                            }
                            else if (true_musical_scale == "ソ5")
                            {
               
                            }
                            else if (true_musical_scale == "ラ5")
                            {
                     
                            }
                            else if (true_musical_scale == "シ5")
                            {
                    
                            }
                            else if (true_musical_scale == "ド6")
                            {
      
                            }
                            else if (true_musical_scale == "シ4")
                            {
   
                            }
                            else if (true_musical_scale == "レ6")
                            {

                            }
                            speed += 0.3f;
                            Debug.Log("seikou");
                            break;
                        }
                        else
                        {
                           canMove = false;
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
            canMove = false;
            }
        }

    }
    void Instancewall(int k)
    {
        lineRenderer.positionCount = k + 1;
        a = Instantiate(Cloud, target + new Vector3(0, 0, 40), Quaternion.identity);
        string true_musical_scale = true_musical_scale_List[k];
        Up = a.transform.Find("Up").gameObject;
        Left = a.transform.Find("Left").gameObject;
        Right = a.transform.Find("Right").gameObject;
        Down = a.transform.Find("Down").gameObject;
        if (true_musical_scale == "ド5")
        {
            lineRenderer.SetPosition(k, target + new Vector3(15, -15, 40));
            target = target + new Vector3(15, -15, 40);
            Destroy(Down);
            Destroy(Right);
            Destroy(Up);
        }
        else if (true_musical_scale == "レ5")
        {
            lineRenderer.SetPosition(k, target + new Vector3(-15, -15, 40));
            target = target + new Vector3(-15, -15, 40);
            Destroy(Down);
            Destroy(Left);
            Destroy(Right);
        }
        else if (true_musical_scale == "ミ5")
        {
            Destroy(Left);
            Destroy(Right);
            Destroy(Up);
            lineRenderer.SetPosition(k, target + new Vector3(-15, 0, 40));
            target = target + new Vector3(-15, 0, 40);

        }
        else if (true_musical_scale == "ファ5")
        {
            Destroy(Up);
            Destroy(Left);
            Destroy(Right);
            lineRenderer.SetPosition(k, target + new Vector3(0, 15, 40));
            target = target + new Vector3(0, 15, 40);

        }
        else if (true_musical_scale == "ソ5")
        {
            Destroy(Right);
            Destroy(Left);
            Destroy(Right);
            lineRenderer.SetPosition(k, target + new Vector3(15, 0, 40));
            target = target + new Vector3(15, 0, 40);

        }
        else if (true_musical_scale == "ラ5")
        {
            lineRenderer.SetPosition(k, target + new Vector3(0, -15, 40));
            target = target + new Vector3(0, 15, 40);
            Destroy(Down);
            Destroy(Right);
            Destroy(Left);

        }
        else if (true_musical_scale == "シ5")
        {
            lineRenderer.SetPosition(k, target + new Vector3(-15, 15, 40));
            target = target + new Vector3(-15, 15, 40);
            Destroy(Left);
            Destroy(Up);
            Destroy(Right);
        }
        else if (true_musical_scale == "ド6")
        {
            lineRenderer.SetPosition(k, target + new Vector3(15, 15, 40));
            target = target + new Vector3(15, 15, 40);
            Destroy(Right);
            Destroy(Down);
            Destroy(Left);
        }
        else if (true_musical_scale == "ラ4")
        {
            lineRenderer.SetPosition(k, target + new Vector3(0, 0, 40));
            Destroy(a);
        }
        else if (true_musical_scale == "シ4")
        {
            lineRenderer.SetPosition(k, target + new Vector3(0, 0, 40));
              Destroy(a);
        }
        else if (true_musical_scale == "レ6")
        {
            lineRenderer.SetPosition(k, target + new Vector3(0, 0, 40));
              Destroy(a);
        }
        else if(true_musical_scale == "休符")
        {
            lineRenderer.SetPosition(k, target + new Vector3(0, 0,40));
            Destroy(a);
        }
    }
}
