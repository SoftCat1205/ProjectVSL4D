using UnityEngine;

public class WeaponFamilyScriptableObject : MonoBehaviour
{
    [SerializeField] private string displayName;
    public string DisplayName { get => displayName; private set => displayName = value; }

    [SerializeField] private string discription;
    public string Discription { get => discription; private set => discription = value; }

    [SerializeField] private Sprite icon;
    public Sprite Icon { get => icon; private set => icon = value; }
}
