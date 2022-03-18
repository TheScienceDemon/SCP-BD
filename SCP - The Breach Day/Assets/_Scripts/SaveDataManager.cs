using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    public static SaveDataManager Singleton { get; private set; }
    public static string GameDirectory { get {
            return System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.ApplicationData) +
                "/SCP - The Breach Day/"; } }

    static string KeybindFile { get {
            return $"{GameDirectory}Saved Data/Keybinds.txt"; } }

    public static readonly Dictionary<ActionName, KeyCode> Keybinds =
        new Dictionary<ActionName, KeyCode>();

    static readonly ActionDefinition[] DefinedActions = new ActionDefinition[10]
    {
        new ActionDefinition(ActionName.WalkForward, KeyCode.W),
        new ActionDefinition(ActionName.WalkLeft, KeyCode.A),
        new ActionDefinition(ActionName.WalkBack, KeyCode.S),
        new ActionDefinition(ActionName.WalkRight, KeyCode.D),
        new ActionDefinition(ActionName.Run, KeyCode.LeftShift),
        new ActionDefinition(ActionName.Jump, KeyCode.Space),
        new ActionDefinition(ActionName.Interact, KeyCode.Mouse0),
        new ActionDefinition(ActionName.TakeScreenshot, KeyCode.F2),
        new ActionDefinition(ActionName.TogglePauseMenu, KeyCode.Escape),
        new ActionDefinition(ActionName.OpenDebugMenu, KeyCode.F3)
    };

    void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Start() => LoadKeybinds();

    public static KeyCode GetKey(ActionName actionName)
    {
        return Keybinds.TryGetValue(actionName, out KeyCode keyCode) ? keyCode : KeyCode.None;
    }

    public void SetKey(ActionName actionName, KeyCode keyCode)
    {
        Keybinds[actionName] = keyCode;
        SaveKeybinds();
    }

    public void SaveKeybinds()
    {
        StringBuilder sb = new StringBuilder();
        foreach (KeyValuePair<ActionName, KeyCode> userKeybind in Keybinds)
        {
            sb.Append(userKeybind.Key);
            sb.Append('=');
            sb.Append(userKeybind.Value);
            sb.Append('\n');
        }
        CheckDirectories.CheckForGameDirectory();
        File.WriteAllText(KeybindFile, sb.ToString(0, sb.Length - 1));
        sb = null;
    }

    public void LoadKeybinds()
    {
        if (!File.Exists(KeybindFile))
        {
            ResetKeybinds();
            SaveKeybinds();
        }


        string tempString1 = File.ReadAllText(KeybindFile);
        char[] tempArray1 = new char[1] { '\n' };

        foreach (string tempString2 in tempString1.Split(tempArray1))
        {
            char[] tempArray2 = new char[1] { '=' };
            string[] strArray = tempString2.Split(tempArray2);

            Keybinds[(ActionName)System.Enum.Parse(typeof(ActionName), strArray[0])] =
                (KeyCode)System.Enum.Parse(typeof(KeyCode), strArray[1]);
        }
    }

    public void ResetKeybinds()
    {
        Keybinds.Clear();

        foreach (ActionDefinition definedAction in DefinedActions)
        {
            KeyCode defaultKey = definedAction.DefaultKey;
            Keybinds[definedAction.Name] = defaultKey;
        }

        SaveKeybinds();
    }

    public readonly struct ActionDefinition
    {
        public readonly ActionName Name;
        public readonly KeyCode DefaultKey;

        public ActionDefinition(ActionName actionName, KeyCode code)
        {
            Name = actionName;
            DefaultKey = code;
        }
    }
}

public enum ActionName
{
    WalkForward,
    WalkLeft,
    WalkBack,
    WalkRight,
    Run,
    Jump,
    Interact,
    TakeScreenshot,
    TogglePauseMenu,
    OpenDebugMenu
};
