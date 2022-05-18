using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBrain : MonoBehaviour
{
    private string input;
    public int type;
    private string declaredType;
    private int whichzone = 1;

    public TextMesh t;
    public GameObject zone;
    public int setzone;
    public GameObject heaven;
    private bool zonAtv = false;

    // Start is called before the first frame update
    void Start()
    {
        SetZType(type);
        t.text = declaredType;
        t.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            //print(input);
        }

        //when zombie is active
        KillZom();
        ResetInput();

        if (Input.GetKeyDown(KeyCode.K))
        {
            Destroy(gameObject);
        }
    }

    void SetZType(int type)
    {
        switch(type)
        {
            case 1:
                declaredType = "Hello";
                break;
            case 2:
                declaredType = "I Love You";
                break;
            case 3:
                declaredType = "Thank You";
                break;
            case 4:
                declaredType = "Yes";
                break;
            case 5:
                declaredType = "No";
                break;
        }
    }

    void KillZom()
    {
        if(input == declaredType && setzone == whichzone && zonAtv == true)
        {
            t.color = Color.red;
            StartCoroutine(Waiter());
        }
    }
    
    public void RecieveInput(string message)
    {
        input = message;
    }
    private void ResetInput()
    {
        input = null;
    }

    public void ZoneReciever()
    {
        //print("zombie knows next zone");
        whichzone++;
    }
    public void ZoneActive()
    {
        zonAtv = true;
    }
    public void ZoneInActive()
    {
        zonAtv = false;
    }

    IEnumerator Waiter()
    {

        //Wait for 4 seconds
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        //transform.Translate(GameObject.FindGameObjectWithTag("Heaven").transform.position);
    }

}
