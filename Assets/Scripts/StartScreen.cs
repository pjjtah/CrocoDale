
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartScreen : MonoBehaviour {




    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChooseLevel(int i)
    {
        StartCoroutine(LoadAsynchronously(i));
        
    }

    IEnumerator LoadAsynchronously(int i)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(i);
        
        Slider s = Resources.FindObjectsOfTypeAll<Slider>()[1];
        s.GetComponentInChildren<Text>().enabled = true;
        while (!load.isDone)
        {
            float progress = Mathf.Clamp01(load.progress / .9f);
            s.value = progress;
            yield return null;
        }
    }

    public void HideIfNotCompleted(int i)
    {
        if (GlobalObject.data.completedLevels[i])
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }
    public void HideAll()
    {
        CanvasGroup[] groups = Resources.FindObjectsOfTypeAll<CanvasGroup>();
        foreach(CanvasGroup g in groups){
            g.alpha = 0;
        }
        Camera.main.backgroundColor = Color.black;
    }

    public void ChangeMusicVolume()
    {
        AudioSource s = GetComponentsInChildren<AudioSource>()[0];
        float musicVolume = Resources.FindObjectsOfTypeAll<Slider>()[0].value/10;
        s.volume = musicVolume;
        PlayerPrefs.SetFloat("music", musicVolume);
    }
    public void ChangeEffectVolume()
    {
        AudioSource s = GetComponentsInChildren<AudioSource>()[1];
        float effectVolume = Resources.FindObjectsOfTypeAll<Slider>()[2].value/10;
        s.volume = effectVolume;
        PlayerPrefs.SetFloat("effects", effectVolume);
    }

    public void SavePrefs()
    {
        PlayerPrefs.Save();
    }

    public void ToggleTimer()
    {
        if (Resources.FindObjectsOfTypeAll<Toggle>()[0].isOn)
        {
            PlayerPrefs.SetInt("timer", 1);
        }
        else
        {
            print("asd");
            PlayerPrefs.SetInt("timer", 0);
        }

    }
}
