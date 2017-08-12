using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

public class Portal : VRTK_InteractableObject
{
    public string nextScene;

    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        base.StartUsing(usingObject);
        // TODO: Animate Door
        LoadScene();
    }

    private void LoadScene()
    {
        // TODO: Serialize and pass relevant data to the new scene.
        SceneManager.LoadSceneAsync(nextScene);
    }
}
