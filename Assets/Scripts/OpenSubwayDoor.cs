using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSubwayDoor : MonoBehaviour
{
    public string nextScene;

    private Animation openAnimation;

    private void Awake()
    {
        openAnimation = GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            openAnimation.Play();
            StartCoroutine(WaitForAnimation());
        }
    }

    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(2);
        LoadScene();
    }

    private void LoadScene()
    {
        SceneManager.LoadSceneAsync(nextScene);
    }
}
