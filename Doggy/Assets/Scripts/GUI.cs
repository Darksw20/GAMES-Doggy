using UnityEngine;
using TMPro;

public class GUI : MonoBehaviour
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI level;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI blueDiamond;
    public TextMeshProUGUI redDiamond;
    public TextMeshProUGUI health;

    public TextMeshProUGUI hSlot1;
    public TextMeshProUGUI hSlot2;
    public TextMeshProUGUI hSlot3;
    public TextMeshProUGUI hSlot4;
    public TextMeshProUGUI hSlot5;


    // Start is called before the first frame update
    void Start()
    {
        time = time.GetComponent<TextMeshProUGUI>();
        level = level.GetComponent<TextMeshProUGUI>();
        coins = coins.GetComponent<TextMeshProUGUI>();
        blueDiamond = blueDiamond.GetComponent<TextMeshProUGUI>();
        redDiamond = redDiamond.GetComponent<TextMeshProUGUI>();
        health = health.GetComponent<TextMeshProUGUI>();

        hSlot1 = hSlot1.GetComponent<TextMeshProUGUI>();
        hSlot2 = hSlot2.GetComponent<TextMeshProUGUI>();
        hSlot3 = hSlot3.GetComponent<TextMeshProUGUI>();
        hSlot4 = hSlot4.GetComponent<TextMeshProUGUI>();
        hSlot5 = hSlot5.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        health.SetText(GameManager.instancia.health.ToString());
        redDiamond.SetText(GameManager.instancia.redJewels.ToString());
        blueDiamond.SetText(GameManager.instancia.blueJewels.ToString());
        level.SetText("Nivel: \n" + GameManager.instancia.level.ToString());
        time.SetText("Tiempo: \n" + GameManager.instancia.time.ToString());
        coins.SetText(GameManager.instancia.money.ToString());

        hSlot1.SetText(GameManager.instancia.hSlot1.ToString());
        hSlot2.SetText(GameManager.instancia.hSlot2.ToString());
        hSlot3.SetText(GameManager.instancia.hSlot3.ToString());
        hSlot4.SetText(GameManager.instancia.hSlot4.ToString());
        hSlot5.SetText(GameManager.instancia.hSlot5.ToString());


    }

}
