using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public SceneStateController controller = null;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        controller = new SceneStateController();
        controller.SetState(new MainMenuSence(controller), false);
    }

    
    void Update()
    {
        if (controller != null)
            controller.StateUpdate();
    }
}
