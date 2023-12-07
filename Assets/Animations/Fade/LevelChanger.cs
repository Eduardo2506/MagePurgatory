using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;

    //void Update()
    //{

    //}
    public void NextToGame()
    {
        FadetoLevel(1);
    }
    public void NextToTutorial()
    {
        FadetoLevel(2);
    }
    public void NexToNivel2()
    {
        FadetoLevel(4);
    }
    public void FadetoLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }
    public void OnfadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
