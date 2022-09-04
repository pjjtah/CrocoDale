using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSelect : MonoBehaviour {

    public CanvasGroup[] groups;

    public void ChooseWorld(int i)
    {
        CanvasGroup c = groups[i];
        Animation wa = c.GetComponent<Animation>();
        Animation ma = groups[0].GetComponent<Animation>();

        
        groups[0].interactable = false;
        groups[0].blocksRaycasts = false;

        string animationName;
        if (i == 5)
        {
            animationName = "menu_settings_button";
            if (PlayerPrefs.GetInt("timer") == 1)
            {
                Resources.FindObjectsOfTypeAll<Toggle>()[0].isOn = true;
            }
            else
            {
                Resources.FindObjectsOfTypeAll<Toggle>()[0].isOn = false;
            }
        }
        else if(i== 4)
        {
            animationName = "menu_shop_button";
        }
        else if (i == 6)
        {
            animationName = "special_levels_button";
        }
        else
        {
            animationName = "menu_button";
        }

        wa[animationName].speed = -1;
        wa[animationName].time = wa[animationName].length;
        wa.Play(animationName);
        ma["menu_world_button"].speed = 1;
        ma["menu_world_button"].time = 0;
        ma.Play("menu_world_button");
        c.interactable = true;
        c.blocksRaycasts = true;
    }

    public void BackToWorldSelect(int i)
    {

        CanvasGroup c = groups[i];
        Animation ma = groups[0].GetComponent<Animation>();
        Animation wa = c.GetComponent<Animation>();

        string animationName;
        if(i == 5)
        {
            animationName = "menu_settings_button";
        }
        else if (i == 4)
        {
            animationName = "menu_shop_button";
        }
        else if (i == 6)
        {
            animationName = "special_levels_button";
        }
        else
        {
            animationName = "menu_button";
        }
        print(animationName);
        wa[animationName].speed = 1;
        wa[animationName].time = 0;
        wa.Play(animationName);
        ma["menu_world_button"].speed = -1;
        ma["menu_world_button"].time = ma["menu_world_button"].length;
        ma.Play("menu_world_button");
        groups[0].interactable = true;
        groups[0].blocksRaycasts = true;
        c.interactable = false;
        c.blocksRaycasts = false;
    }
}
