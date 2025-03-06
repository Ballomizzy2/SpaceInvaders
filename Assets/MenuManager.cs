using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoSomething()
    {
        LoadGameScene();
    }

    private void Awake()
    {
       // DontDestroyOnLoad(gameObject);
    }
    public void LoadGameScene()
    {
        StartCoroutine(_LoadScene());

        IEnumerator _LoadScene()
        {
            AsyncOperation loadOp = SceneManager.LoadSceneAsync("Game");
            while (!loadOp.isDone) yield return null;

            Debug.Log("Loaded");
        }
    }

    public void LoadCreditsScene()
    {
        StartCoroutine(_LoadScene());

        IEnumerator _LoadScene()
        {
            AsyncOperation loadOp = SceneManager.LoadSceneAsync("Credits");
            while (!loadOp.isDone) yield return null;

            Debug.Log("Loaded Creditrs");
        }
    }
}
