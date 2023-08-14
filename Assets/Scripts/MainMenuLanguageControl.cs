using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TMPro;
using UnityEngine;

public class MainMenuLanguageControl : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI newGame;
    [SerializeField] public TextMeshProUGUI loadGame;
    [SerializeField] public TextMeshProUGUI settings;
    [SerializeField] public TextMeshProUGUI credits;
    [SerializeField] public TextMeshProUGUI codex;
    [SerializeField] public TextMeshProUGUI languageLabel;
    [SerializeField] public TextMeshProUGUI muteMusic;
    [SerializeField] public TextMeshProUGUI muteSound;
    [SerializeField] public TextMeshProUGUI deleteMessage;
    [SerializeField] public TextMeshProUGUI overwriteMessage;
    [SerializeField] public TextMeshProUGUI[] backButtons;
    [SerializeField] public TextMeshProUGUI[] yesButtons;
    [SerializeField] public TextMeshProUGUI[] noButtons;
    [SerializeField] public TextMeshProUGUI[] warningTexts;
    [SerializeField] public TextMeshProUGUI[] saveButtons;
    [SerializeField] public TMP_Dropdown dropChoices;
    private string langText;

    private void Start()
    {
        readLanguage(0);
    }

    public void readLanguage(int check)
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("Language.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("Language");
        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0)
        {
            if(check == 0)
            {
                if (mydoc.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    dropChoices.value = 1;
                }
                else if (mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
                {
                    dropChoices.value = 0;
                }
            }
            else if (check == 1)
            {
                if (dropChoices.value == 1)
                {
                    mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText = "False";
                    mydoc.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText = "True";
                }
                else if (dropChoices.value == 0)
                {
                    mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText = "True";
                    mydoc.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText = "False";
                }
                mydoc.Save("Language.xml");
            }

            if (dropChoices.value == 1)
            {
                langText = "Turkish";
                dropChoices.options[0].text = "Ingilizce";
                dropChoices.options[1].text = "Türkçe";
            }
            else if (dropChoices.value == 0)
            {
                langText = "English";
                dropChoices.options[0].text = "English";
                dropChoices.options[1].text = "Turkish";
            }

            languageLabel.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/lngtext").InnerText.Trim();

            settings.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/settings").InnerText.Trim();
            newGame.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/newGame").InnerText.Trim();
            credits.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/credits").InnerText.Trim();
            codex.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/codex").InnerText.Trim();
            loadGame.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/loadGame").InnerText.Trim();
            muteMusic.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/muteMusic").InnerText.Trim();
            muteSound.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/muteSound").InnerText.Trim();
            deleteMessage.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/delete").InnerText.Trim();
            overwriteMessage.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/overwrite").InnerText.Trim();

            for (int i = 0; i < backButtons.Length; i++)
            {
                backButtons[i].GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/back").InnerText.Trim();
            }

            for (int i = 0; i < yesButtons.Length; i++)
            {
                yesButtons[i].GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/yes").InnerText.Trim();
            }

            for (int i = 0; i < noButtons.Length; i++)
            {
                noButtons[i].GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/no").InnerText.Trim();
            }

            for (int i = 0; i < warningTexts.Length; i++)
            {
                warningTexts[i].GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/warning").InnerText.Trim();
            }

            for (int i = 0; i < saveButtons.Length; i++)
            {
                saveButtons[i].GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/saveName").InnerText.Trim() + " " + ((i % 3) + 1).ToString();
            }
        }
    }
}
