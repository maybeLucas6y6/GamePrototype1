using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
//using System.Reflection;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject playerInventory;
    public List<string> equippedGear;
    
    public void UpdateGear()
    {
        List<string> newGear = new();
        for(int i = 0; i <= 3; i++)
        {
            if(playerInventory.transform.GetChild(i).childCount > 0)
            {
                newGear.Add(playerInventory.transform.GetChild(i).transform.GetChild(0).GetComponent<ItemObject>().referenceItem.scriptName);
            }
        }
        var sameGear = newGear.Intersect(equippedGear).ToList();
        foreach (var item in newGear)
        {
            if (!sameGear.Contains(item))
            {
                SwitchEquipState(Type.GetType(item));
                sameGear.Add(item);
            }
        }
        foreach (var item in equippedGear)
        {
            if (!sameGear.Contains(item))
            {
                SwitchEquipState(Type.GetType(item));
            }
        }
        equippedGear = sameGear;
    }

    private void SwitchEquipState(Type gear)
    {
        if (gameObject.GetComponent(gear.Name))
        {
            Destroy(gameObject.GetComponent(gear.Name));
        }
        else
        {
            gameObject.AddComponent(gear);
        }
    }

    private void Update()
    {
        ReloadScene();
    }

    private void ReloadScene()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}