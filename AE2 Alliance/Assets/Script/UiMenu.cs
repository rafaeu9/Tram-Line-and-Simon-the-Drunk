using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DeeprunTramLine()
    {   

        StartCoroutine(TurnOrientation());
    }
        

    public IEnumerator TurnOrientation()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        while (Screen.orientation != ScreenOrientation.LandscapeLeft)
        {
            yield return null;
        }

        SceneManager.LoadScene("Deeprun Tram Line");
        
    }

    public void UnoptimizedScene()
    {

        StartCoroutine(TurnOrientationUnoptimizedScene());
    }


    public IEnumerator TurnOrientationUnoptimizedScene()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        while (Screen.orientation != ScreenOrientation.LandscapeLeft)
        {
            yield return null;
        }

        SceneManager.LoadScene("UnoptimizedScene");
    }

    public void SimonTheDrunk()
    {
        SceneManager.LoadScene("Simon The Drunk");
    }

    public void licence()
    {
        SceneManager.LoadScene("licence");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
