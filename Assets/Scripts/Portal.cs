﻿using System.Collections;
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
        LoadScene();
    }

    private void LoadScene()
    {
        SceneManager.LoadSceneAsync(nextScene);
    }
}
