using System.Collections.Generic;
using UnityEngine;

public class WeaponFamilyScriptableObject : MonoBehaviour
{
    [SerializeField] private List<WeaponCategory> category;
    public List<WeaponCategory> Category { get => category; private set => category = value; }

    [SerializeField] private string displayName;
    public string DisplayName { get => displayName; private set => displayName = value; }

    [SerializeField] private string discription;
    public string Discription { get => discription; private set => discription = value; }

    [SerializeField] private Sprite icon;
    public Sprite Icon { get => icon; private set => icon = value; }
}
