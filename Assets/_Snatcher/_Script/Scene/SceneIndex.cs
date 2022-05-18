using UnityEngine;

namespace Snatcher
{
    public enum SceneIndex
    {
        // Be VERY CAREFUL when changing the enum order
        // Might need to rewire everything that uses this enum for scene reference
        // The integer values of the enum entries must match up with their indices in the Build Settings
        Init = 0,
        MainMenu = 1,
        TutorialUpperWorld = 2,
        TutorialDungeon = 3,
        UpperWorld = 4,
        Dungeon01 = 5,
        Dungeon02 = 6,
        Dungeon03 = 10,
        WinScene = 7,
        LoseScene = 8,
        Shop = 9
    }
}
