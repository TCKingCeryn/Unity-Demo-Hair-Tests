using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.DemoTeam.Hair;
using UnityEngine.UI;

public class HairDemoSwitcher : MonoBehaviour
{
    public Slider StrandDiameter;
    public Slider StrandMargin;
    public Slider Stiffness;
    public Slider Dampening;
    public Slider AngularDampening;
    public Slider Gravity;
    public Slider GlobalPosition;
    [Space(10)]

    public GameObject[] HairObjects;
    public Material[] HairMaterials;


    internal int HairIndex;
    internal int HairMatIndex;


    void Start()
    {
        
    }
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


    public void SetStrandDiameter()
    {
        for (int i = 0; i < HairObjects.Length; i++)
        {
            var HairInst = HairObjects[i].GetComponent<HairInstance>();
            HairInst.strandGroupDefaults.settingsStrands.strandDiameter = StrandDiameter.value;
        }
    }
    public void SetStrandMargin()
    {
        for (int i = 0; i < HairObjects.Length; i++)
        {
            var HairInst = HairObjects[i].GetComponent<HairInstance>();
            HairInst.strandGroupDefaults.settingsStrands.strandMargin = StrandMargin.value;
        }
    }
    public void SetStiffness()
    {
        for (int i = 0; i < HairObjects.Length; i++)
        {
            var HairInst = HairObjects[i].GetComponent<HairInstance>();
            HairInst.strandGroupDefaults.settingsSolver.stiffness = Stiffness.value;
        }
    }
    public void SetDampening()
    {
        for (int i = 0; i < HairObjects.Length; i++)
        {
            var HairInst = HairObjects[i].GetComponent<HairInstance>();
            HairInst.strandGroupDefaults.settingsSolver.dampingFactor = Dampening.value;
        }
    }
    public void SetAngularDampening()
    {
        for (int i = 0; i < HairObjects.Length; i++)
        {
            var HairInst = HairObjects[i].GetComponent<HairInstance>();
            HairInst.strandGroupDefaults.settingsSolver.angularDampingFactor = AngularDampening.value;
        }
    }
    public void SetGravity()
    {
        for (int i = 0; i < HairObjects.Length; i++)
        {
            var HairInst = HairObjects[i].GetComponent<HairInstance>();
            HairInst.strandGroupDefaults.settingsSolver.gravity = Gravity.value;
        }
    }
    public void SetGlobalPosition()
    {
        for (int i = 0; i < HairObjects.Length; i++)
        {
            var HairInst = HairObjects[i].GetComponent<HairInstance>();
            HairInst.strandGroupDefaults.settingsSolver.globalPositionInfluence = GlobalPosition.value;
        } 
    }

}
