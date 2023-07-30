using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] public TMP_Dropdown dropChoices;
    private string langText;

    private void Start()
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("Language.xml");

        if (mydoc.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText.Trim().Equals("True"))
        {
            langText = "Turkish";
            dropChoices.value = 1;
            dropChoices.options[0].text = "İngilizce";
            dropChoices.options[1].text = "Türkçe";
        }
        else if (mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
        {
            langText = "English";
            dropChoices.value = 0;
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

    }

    public void readLanguage()
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("Language.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("Language");
        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0)
        {
            if (dropChoices.value == 1)
            {
                mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText = "False";
                mydoc.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText = "True";

                langText = "Turkish";
                dropChoices.options[0].text = "Ýngilizce";
                dropChoices.options[1].text = "Türkçe";
            }
            else if (dropChoices.value == 0)
            {
                mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText = "True";
                mydoc.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText = "False";

                langText = "English";
                dropChoices.options[0].text = "English";
                dropChoices.options[1].text = "Turkish";
            }
            mydoc.Save("Language.xml");

            languageLabel.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/lngtext").InnerText.Trim();

            settings.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/settings").InnerText.Trim();
            newGame.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/newGame").InnerText.Trim();
            credits.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/credits").InnerText.Trim();
            codex.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/codex").InnerText.Trim();
            loadGame.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/loadGame").InnerText.Trim();
            muteMusic.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/muteMusic").InnerText.Trim();
            muteSound.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/muteSound").InnerText.Trim();

        }
    }
}
