using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.UI;
public class AppInitilize : MonoBehaviour
{
    public GameObject InGameUI;
    public GameObject GameOverUI;
    public GameObject InMenuUI;
    public GameObject player;
    public GameObject adButton;
    public float Curvature=1.8f;
    public float Trimming=0.1f;
    public bool HasGameStarted;
    public bool Hasseenadd;
    private void Awake()
    {
        Shader.SetGlobalFloat("_Curvature", Curvature);
        Shader.SetGlobalFloat("_Trimming", Trimming);
        Application.targetFrameRate=60;
    }

    private void Start()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        InMenuUI.gameObject.SetActive(true);
        GameOverUI.gameObject.SetActive(false);
        InGameUI.gameObject.SetActive(false);
    }
    public void PlayGame()
    {
        if (HasGameStarted == true)
            StartCoroutine(StartGame(1.5f));
        else
            StartCoroutine(StartGame(0.5f));
    }
    public void PauseGame()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        InMenuUI.gameObject.SetActive(true);
        GameOverUI.gameObject.SetActive(false);
        InGameUI.gameObject.SetActive(false);
      
    }
    public void GameOver()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        InMenuUI.gameObject.SetActive(false);
        GameOverUI.gameObject.SetActive(true);
        InGameUI.gameObject.SetActive(false);
        if (Hasseenadd == true)
        {
            adButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            adButton.GetComponent<Button>().enabled = false;
        }
       
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowAdd()
    {

        if(Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
         
        };
    }
    private void HandleShowResult(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Finished:
                Hasseenadd = true;
                StartCoroutine(StartGame(1.5f));
            break;
            case ShowResult.Skipped:
            break;
            case ShowResult.Failed:
            break;
        }
        Debug.Log("b");
    }
     
    IEnumerator StartGame(float waittime)
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        HasGameStarted = true;
        InMenuUI.gameObject.SetActive(false);
        GameOverUI.gameObject.SetActive(false);
        InGameUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(waittime);
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;

    }
}
