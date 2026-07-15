using Fusion;

public class MLevel : NetworkBehaviour
{
    [Networked] public int Level { get; set; }
    [Networked] public int Experience { get; set; }
    [Networked] public int ExperienceCap { get; set; }

    public void AddExperience(int amount)
    {
        if (!Object.HasStateAuthority)
            return;

        Experience += amount;

        while (Experience >= ExperienceCap)
        {
            Experience -= ExperienceCap;

            Level++;

            // Increase cap
        }
    }
}