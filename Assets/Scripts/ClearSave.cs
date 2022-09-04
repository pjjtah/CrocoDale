using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ClearSave : MonoBehaviour {

    Button b;
    float time = 5f;
    float pointerDownTimer;
    bool pointerdown;
    private Image fillImage;
	void Start () {
        b = GetComponent<Button>();
        fillImage = GetComponent<Image>();
	}


    public void DeleteSave()
    {
        GlobalObject.Instance.ClearData();
        SceneManager.LoadScene(0);
    }

    public void Update()
    {
        if (pointerdown)
        {
            pointerDownTimer += Time.deltaTime;
            if(pointerDownTimer > time)
            {
                DeleteSave();
            }
            fillImage.fillAmount = 1 - (pointerDownTimer / time);
        }
    }

    public void OnPointerDown()
    {
        pointerdown = true;
    }


    public void OnPointerUp()
    {
        pointerdown = false;
        pointerDownTimer = 0;
        fillImage.fillAmount = 1;
    }



}
