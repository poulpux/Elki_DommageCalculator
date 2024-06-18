using UnityEngine;


public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _instance;
    public static T Instance => _instance;

    protected virtual void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
            _instance = (T)this;
    }
}
        


public abstract class MonoSingletonDDOL<T> : MonoBehaviour where T : MonoSingletonDDOL<T>
{
    private static T _instance;
    public static T Instance => _instance;

    protected virtual void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
        {
            _instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
