using System;
using UnityEngine;

public class GameHub
{
    public static event Action<PlayerManager> PlayerManagerReady;
    public static event Action<RunManager> RunManagerReady;

    public static void Register(PlayerManager pm) => PlayerManagerReady?.Invoke(pm);
    public static void Register(RunManager rm) => RunManagerReady?.Invoke(rm);
}
