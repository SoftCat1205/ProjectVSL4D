using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public static WeaponSelector Instance;
    public WeaponScriptableObject weaponData;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Instance isn't null");
            Instance = null;
        }
    }

    public static WeaponScriptableObject GetData()
    {
        return Instance.weaponData;
    }

    public void SelectWeapon(WeaponScriptableObject weapon)
    {
        weaponData = weapon;
    }
}
