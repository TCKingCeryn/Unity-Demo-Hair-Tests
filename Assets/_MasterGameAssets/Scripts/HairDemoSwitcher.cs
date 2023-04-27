using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.DemoTeam.Hair;

public class HairDemoSwitcher : MonoBehaviour
{

    public GameObject[] HairObjects;
    public Material[] HairMaterials;


    internal int HairIndex;
    internal int HairMatIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            HairIndex++;

            if(HairIndex >= HairObjects.Length)
            {
                HairIndex = 0;
            }

            for (int i = 0; i < HairObjects.Length; i++)
            {
                if (i != HairIndex)
                {
                    HairObjects[i].gameObject.SetActive(false);
                }
            }

            //Set desired weapon to active
            HairObjects[HairIndex].gameObject.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            HairMatIndex++;

            if (HairMatIndex >= HairMaterials.Length)
            {
                HairMatIndex = 0;
            }

            for (int i = 0; i < HairObjects.Length; i++)
            {
                var HairInst = HairObjects[i].GetComponent<HairInstance>();
                HairInst.strandGroupDefaults.settingsStrands.materialValue = HairMaterials[HairMatIndex];
 
            }
        }


    }
}
