using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ClearSaveFile : MonoBehaviour
{
    [SerializeField] public int fileID;
    [SerializeField] public GameObject w1;
    [SerializeField] public GameObject w2;
    [SerializeField] public GameObject w3;
    [SerializeField] public GameObject b1;
    [SerializeField] public GameObject b2;
    [SerializeField] public GameObject b3;
    public void resetFileID()
    {
        fileID = 0;
    }

    public void clearSaveFile()
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("SaveFile.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("Files");
        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0)
        {
            if(fileID > 3 || fileID <= 0)
            {
                Debug.Log("Error!");
            }
            else
            {
                mydoc.SelectSingleNode("Files/File" + fileID.ToString() + "/isBeingUsed").InnerText = "False";
                mydoc.SelectSingleNode("Files/File" + fileID.ToString() + "/playing").InnerText = "False";
                mydoc.SelectSingleNode("Files/File" + fileID.ToString() + "/turnNumber").InnerText = "0";
                mydoc.SelectSingleNode("Files/File" + fileID.ToString() + "/name").InnerText = "Null";
                mydoc.SelectSingleNode("Files/File" + fileID.ToString() + "/leftLoyaltyTick").InnerText = "0";
                mydoc.SelectSingleNode("Files/File" + fileID.ToString() + "/rightLoyaltyTick").InnerText = "0";
                mydoc.SelectSingleNode("Files/File" + fileID.ToString() + "/joinedCarlists").InnerText = "False";
                mydoc.SelectSingleNode("Files/File" + fileID.ToString() + "/joinedCNT").InnerText = "False";
                mydoc.SelectSingleNode("Files/File" + fileID.ToString() + "/joinedLiberals").InnerText = "False";
                mydoc.SelectSingleNode("Files/File" + fileID.ToString() + "/joinedFET").InnerText = "False";
                mydoc.SelectSingleNode("Files/File" + fileID.ToString() + "/joinedCommunists").InnerText = "False";
                mydoc.Save("SaveFile.xml");

                if(fileID == 1)
                {
                    w1.SetActive(false);
                    b1.SetActive(false);
                }
                if (fileID == 2)
                {
                    w2.SetActive(false);
                    b2.SetActive(false);
                }
                if (fileID == 3)
                {
                    w3.SetActive(false);
                    b3.SetActive(false);
                }
            }
        }

        fileID = 0;
    }
}
