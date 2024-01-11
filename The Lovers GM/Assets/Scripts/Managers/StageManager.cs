using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static int _clearedSceneNumber = 0;

    [Serializable]
    public class Stage
    {
        public string stageNm;
        public List<Button> stageButtons;
    }

    [Header("Setting")]
    [SerializeField] public List<Stage> stage;

    public Text debugText;
    
    private void Awake()
    {
        // TODO : Awake Setting
    }

    private void Start()
    {
        SetStageButton();
        debugText.text = DataManager.Instance.CurrentStage + "";
    }

    private void SetStageButton()
    {
        for(int index = 0; index < stage.Count; index++)
        {
            for(int jndex = 0; jndex < stage[index].stageButtons.Count; jndex++)
            {
                Button button = stage[index].stageButtons[jndex];
                string stageNm = button.gameObject.name;
                int integerStage = Int32.Parse(stageNm);

                if(!VaildInitStage(integerStage))
                {
                    button.interactable = false;
                    continue;
                }

                button.onClick.AddListener(() => StartInGame(stageNm));
            }
        }
    }

    private void StartInGame(string stage)
    {
        StartCoroutine(GameObject.FindObjectOfType<ClearedController>().ClickTimeEvent(stage));
    }

    private bool VaildInitStage(int stage)
    {
        if (!(stage <= DataManager.Instance.CurrentStage + 1)) return false;

        return true;
    }

}
