using UnityEngine;

namespace Snatcher
{
    public abstract class ASingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<T>("Manager/" + typeof(T).ToString());
                    if (_instance == null)
                    {
                        Debug.LogError("Did not load an instance from /Assets/_Snatcher/Resources/Manager. Did you forget to put in the Scriptable Object Singleton?");
                        return null;
                    }
                    
                    (_instance as ASingletonScriptableObject<T>).OnInitialized();
                }
                
                return _instance;
            }
        }

        /// <summary>
        /// Optional overridable method for initializing the instance
        /// </summary>
        protected void OnInitialized() { }
    }
}