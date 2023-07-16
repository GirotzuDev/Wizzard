using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private SpellController spellController;
    // Start is called before the first frame update
    void Start()
    {
        spellController = GetComponent<SpellController>();
        if (spellController == null)
        {
            Debug.LogError("SpellController component not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //spellController.SetTextDown("hOLA");

    }
}
