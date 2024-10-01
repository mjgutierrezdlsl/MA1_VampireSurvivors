using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            //if there is no instance yet,
            if (!_instance)
            {
                //find an existing gameobject in the scene that has the generic component
                _instance = (T)FindObjectOfType(typeof(T));
            }
            //if after checking the scene, we still don't have an instance..
            if (!_instance)
            {
                _instance = null;
            }
            return _instance;
        }
    }
    protected virtual void Awake()
    {
        //if there is no instance, set self as the instance
        if (_instance == null)
            _instance = this as T;

        //if there is already an existing instance
        if (_instance != null)
        {
            //check if self is not the actual instance
            if (_instance != this as T)
            {
                //Destroy self because there can only be one instance
                Destroy(this.gameObject);
            }
        }
    }
}
