using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class BeginGame : MonoBehaviour
{
    float timer = 0;
    private bool buttonPressed = true;
    [SerializeField] public GameObject fadeText;
    public int id;
    float duration = 3f;

    // Start is called before the first frame update
    void Start()
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("SaveFile.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("Files");
        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0)
        {
            // These playing params should be set to false while returning to the main menu!!!!
            if (mydoc.SelectSingleNode("Files/File1/playing").InnerText.Trim().Equals("True"))
                id = 1;
            else if(mydoc.SelectSingleNode("Files/File2/playing").InnerText.Trim().Equals("True"))
                id = 2;
            else if (mydoc.SelectSingleNode("Files/File3/playing").InnerText.Trim().Equals("True"))
                id = 3;

            if(int.Parse(mydoc.SelectSingleNode("Files/File" + id + "/turnNumber").InnerText.Trim()) > 0)
            {
                buttonPressed = false;
            }
            else
            {
                fadeText.GetComponent<Animator>().Play("TextAppear");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                Debug.Log("test");
                timer = 0;
                buttonPressed = false;
                fadeText.GetComponent<Animator>().Play("textDisappear");
            }
        }
    }
}
