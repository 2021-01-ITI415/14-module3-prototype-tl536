using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    public TextMeshProUGUI collect;
    private int collected;
    // Start is called before the first frame update
    void Start()
    {
        collected = int.Parse(collect.text);
    }

    // Update is called once per frame
    void Update()
    {
        collected = int.Parse(collect.text);
        if (collected == 8)
        {
            Destroy(gameObject);
        }
    }
}
