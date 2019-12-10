
/// <summary>
/// We are going to create a singleton that can exist in multiple scenes without any issues because it is handled
/// in the inspector.  Cool story.  We get the benefits of referencing the singleton without having to have a direct
/// reference to the object.  Sweet!
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class UtilityScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance = null;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                T[] results = Resources.FindObjectsOfTypeAll<T>();

                if (results.Length == 0)
                {
                    Debug.LogError("SingletonScriptableObject -> Instance -> results lenght is 0 for type " + typeof(T).ToString() + ".");
                    return null;
                }

                if (results.Length > 1)
                {
                    Debug.LogError("SingletonScriptableObject -> Instance -> results length is greater than 1 for type " + typeof(T).ToString() + ".");
                    return null;
                }

                _instance = results[0];
            }

            return _instance;
        }
    }
}

/// <summary>
/// Here, we will create a scriptable object that does two things.  First, it is a scriptable object so we will be able
/// to use it in all our code without having to create a direct reference to it.  We will just have to access it using the
/// class name.
/// For example, if we want to get the GameVersion, we just type GameSettings.GameVersion wherever we need it!
/// Even cooler, this is an asset menu item.  We can right click in Unity and create a new one of these just like we
/// would add a sphere or a canvas.
/// </summary>
[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class UtilityGameSettings : ScriptableObject
{
    [SerializeField]
    private string _gameVersion = "0.0.0";
    public string GameVersion { get { return _gameVersion; } }
    [SerializeField]
    private string _nickName = "Punfish";

    public string NickName
    {
        get
        {
            int value = UnityEngine.Random.Range(0, 9999);
            return _nickName + value.ToString();
        }
    }
}
