using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {


    public GameObject[] weapons;
    bool[] weaponAvailable;
    public Image weaponImage;

    int currentWeapon;

	void Start () {
        weaponAvailable = new bool[weapons.Length];
        for (int i = 0; i < weapons.Length; i++) weaponAvailable[i] = false;
        currentWeapon = 0;
        weaponAvailable[currentWeapon] = true;
    //    for (int i = 0; i < weapons.Length; i++) weaponAvailable[i] = true;

        deactivateWeapons();

        setWeaponActive(currentWeapon);

    }

    void Update () {
        //toggle weapon
        if (Input.GetButtonDown("Submit"))
        {
            int i;
            for(i = currentWeapon+1; i<weapons.Length; i++)
            {
                if (weaponAvailable[i] == true)
                {
                    currentWeapon = i;
                    setWeaponActive(currentWeapon);
                    return;
                }
            }
            for (i = 0; i<currentWeapon; i++)
            {
                currentWeapon = i;
                setWeaponActive(currentWeapon);
                return;
            }
        }
	}

    public void setWeaponActive(int whichWeapon)
    {
        if (!weaponAvailable[whichWeapon]) return;
        deactivateWeapons();
        weapons[whichWeapon].SetActive(true);
        weapons[whichWeapon].GetComponentInChildren<FireBullet>().initializeWeapon();
    }

    void deactivateWeapons()
    {
        for (int i = 0; i < weapons.Length; i++) weapons[i].SetActive(false);

    }

    public void ActivateWeapon (int whichWeapon)
    {
        weaponAvailable[whichWeapon] = true;
    }
}
