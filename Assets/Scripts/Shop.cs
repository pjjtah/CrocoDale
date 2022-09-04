using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shop : MonoBehaviour {

    public Sprite[] hatSprites;
    public Text[] scoreTexts;
    public Button[] hatButtons;
    public Button hat;
    int savannahScore = 0;
    int caveScore = 0;
    int jungleScore = 0;
    int winterScore = 0;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 6; i++)
        {
            savannahScore += GlobalObject.data.levelScores[i + 2];
        }
        for (int i = 0; i < 6; i++)
        {
            caveScore += GlobalObject.data.levelScores[i + 8];
        }
        for (int i = 0; i < 6; i++)
        {
            jungleScore += GlobalObject.data.levelScores[i + 14];
        }
        for (int i = 0; i < 3; i++)
        {
            winterScore += GlobalObject.data.levelScores[i + 20];
        }
        if (savannahScore < 20)
        {
            hatButtons[0].interactable = false;
            scoreTexts[0].text = savannahScore.ToString() + "/" + "20";
        }
        else
        {
            Destroy(scoreTexts[0].GetComponentInChildren<SpriteRenderer>());
            Destroy(scoreTexts[0]);
        }
        if(caveScore < 22)
        {
            hatButtons[1].interactable = false;
            scoreTexts[1].text = caveScore.ToString() + "/" + "22";
        }
        else
        {
            Destroy(scoreTexts[1].GetComponentInChildren<SpriteRenderer>());
            Destroy(scoreTexts[1]);
        }
        if (jungleScore < 20)
        {
            hatButtons[2].interactable = false;
            scoreTexts[2].text = jungleScore.ToString() + "/" + "20";
        }
        else
        {
            Destroy(scoreTexts[2].GetComponentInChildren<SpriteRenderer>());
            Destroy(scoreTexts[2]);
        }
        if (winterScore < 7)
        {
            hatButtons[3].interactable = false;
            scoreTexts[3].text = winterScore.ToString() + "/" + "7";
        }
        else
        {
            Destroy(scoreTexts[3].GetComponentInChildren<SpriteRenderer>());
            Destroy(scoreTexts[3]);
        }
        if (GlobalObject.data.selectedHat == 0)
        {
            hat.interactable = false;

        }
        else
        {
            hat.image.sprite = hatSprites[GlobalObject.data.selectedHat-1];
            hat.interactable = true;
            hatButtons[GlobalObject.data.selectedHat - 1].gameObject.SetActive(false);
        }

    }

    public void PurchaseHat(int i)
    {
        if (i == 0)
        {
            hat.interactable = false;
        }
        else
        {
            hatButtons[i-1].gameObject.SetActive(false);
            hat.interactable = true;
            hat.image.sprite = hatSprites[i-1];
        }
        if (GlobalObject.data.selectedHat != 0)
        {
            hatButtons[GlobalObject.data.selectedHat - 1].gameObject.SetActive(true);
        }
        GlobalObject.data.selectedHat = i;
        GlobalObject.Instance.SaveData();
    }

}
