using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class levelStats_controller : GameRouting
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI level;
    public TextMeshProUGUI health;
    public TextMeshProUGUI redDiamonds;
    public TextMeshProUGUI blueDiamonds;
    public TextMeshProUGUI coins;

    public Sprite missionCompleted;
    public Sprite levelCompleted;

    public GameObject backgroundImage;

    void Start()
    {
        showImage();
    }

    private void showImage()
    {
        int level = GameManager.instancia.level;
        if (level == 1 || level == 3 || level == 4 || level == 6 || level == 7 || level == 8)
        {
            backgroundImage.GetComponent<SpriteRenderer>().sprite = missionCompleted;
        } else if (level == 2 || level == 5 || level == 9)
        {
            backgroundImage.GetComponent<SpriteRenderer>().sprite = levelCompleted;
        }
        StartCoroutine(removeImage());
    }

    private void updateText()
    {
        time.text = "Completado en:\n" + GameManager.instancia.time.ToString() + " segundos";
        level.text = getLevelText();
        health.text = GameManager.instancia.health.ToString();
        redDiamonds.text = GameManager.instancia.redJewels.ToString();
        blueDiamonds.text = GameManager.instancia.blueJewels.ToString();
        coins.text = GameManager.instancia.money.ToString();
    }

    public void nextScene()
    {
        ChooseLevel(GameManager.instancia.nextLevel.ToString());
    }

    private string getLevelText()
    {
        switch (GameManager.instancia.level)
        {
            case 1:
                return "Level1_1";

            case 2:
                return "Level1_2";

            case 3:
                return "Level2_1_1";

            case 4:
                return "Level2_1_2";

            case 5:
                return "Level2_2";

            case 6:
                return "Level3_1";

            case 7:
                return "Level3_2_1";

            case 8:
                return "Level3_2_2";

            case 9:
                return "Level3_2_3";
        }
        return null;
    }

    IEnumerator removeImage()
    {
        yield return new WaitForSeconds(3);
        backgroundImage.GetComponent<SpriteRenderer>().sprite = null;
        updateText();
    }

}
