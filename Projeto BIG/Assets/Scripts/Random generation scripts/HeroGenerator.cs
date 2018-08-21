using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeroGenerator : MonoBehaviour {

    #region Declaring Variables
    //Main variable
    [SerializeField] private GameObject[] parts;
    private int count;
    // 0 -Heads
    [SerializeField] private Sprite[] bHead;
    [SerializeField] private Sprite[] rHead;
    [SerializeField] private Sprite[] blHead;
    [SerializeField] private Sprite[] yHead;
    // 1 -Body
    [SerializeField] private Sprite[] bBody;
    [SerializeField] private Sprite[] rBody;
    [SerializeField] private Sprite[] blBody;
    [SerializeField] private Sprite[] yBody;
    // 2/3 -arms
    [SerializeField] private Sprite[] bArms;
    [SerializeField] private Sprite[] rArms;
    [SerializeField] private Sprite[] blArms;
    [SerializeField] private Sprite[] yArms;
    // 4/5 -arms
    [SerializeField] private Sprite[] bLegs;
    [SerializeField] private Sprite[] rLegs;
    [SerializeField] private Sprite[] blLegs;
    [SerializeField] private Sprite[] yLegs;
    #endregion

    [SerializeField] private string[] aName;
    [SerializeField] private string[] bName;
    [SerializeField] private TextMeshProUGUI displayAName;
    [SerializeField] private TextMeshProUGUI displayBName;



    public void randomizar() // funcao pra randomizar os personagens
    {
        displayAName.text = aName[Random.Range(0, aName.Length)];
        displayBName.text = bName[Random.Range(0, bName.Length)];

        int arms = Random.Range(0,1);
        int legs = Random.Range(0,1);
        int cor = Random.Range(1, 4);

        if(cor == 1) //black
        {
            parts[0].GetComponent<SpriteRenderer>().sprite = bHead[Random.Range(0, bHead.Length)];
            parts[1].GetComponent<SpriteRenderer>().sprite = bBody[Random.Range(0, bBody.Length)];
            parts[2].GetComponent<SpriteRenderer>().sprite = bArms[arms];
            parts[3].GetComponent<SpriteRenderer>().sprite = bArms[arms];
            parts[4].GetComponent<SpriteRenderer>().sprite = bLegs[legs];
            parts[5].GetComponent<SpriteRenderer>().sprite = bLegs[legs];
        }
        if (cor == 2) //red
        {
            parts[0].GetComponent<SpriteRenderer>().sprite = rHead[Random.Range(0, bHead.Length)];
            parts[1].GetComponent<SpriteRenderer>().sprite = rBody[Random.Range(0, bBody.Length)];
            parts[2].GetComponent<SpriteRenderer>().sprite = rArms[arms];
            parts[3].GetComponent<SpriteRenderer>().sprite = rArms[arms];
            parts[4].GetComponent<SpriteRenderer>().sprite = rLegs[legs];
            parts[5].GetComponent<SpriteRenderer>().sprite = rLegs[legs];
        }
        if (cor == 3) //blue
        {
            parts[0].GetComponent<SpriteRenderer>().sprite = blHead[Random.Range(0, bHead.Length)];
            parts[1].GetComponent<SpriteRenderer>().sprite = blBody[Random.Range(0, bBody.Length)];
            parts[2].GetComponent<SpriteRenderer>().sprite = blArms[arms];
            parts[3].GetComponent<SpriteRenderer>().sprite = blArms[arms];
            parts[4].GetComponent<SpriteRenderer>().sprite = blLegs[legs];
            parts[5].GetComponent<SpriteRenderer>().sprite = blLegs[legs];
        }
        if (cor == 4)  //yellow
        {
            parts[0].GetComponent<SpriteRenderer>().sprite = yHead[Random.Range(0, bHead.Length)];
            parts[1].GetComponent<SpriteRenderer>().sprite = yBody[Random.Range(0, bBody.Length)];
            parts[2].GetComponent<SpriteRenderer>().sprite = yArms[arms];
            parts[3].GetComponent<SpriteRenderer>().sprite = yArms[arms];
            parts[4].GetComponent<SpriteRenderer>().sprite = yLegs[legs];
            parts[5].GetComponent<SpriteRenderer>().sprite = yLegs[legs];
        }


    }

}
