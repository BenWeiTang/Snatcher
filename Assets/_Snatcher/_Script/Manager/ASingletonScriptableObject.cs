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
                    // The Mangers will sit in the Manager folder which is a sub-folder of a Resources folder
                    // Therefore the path needs to be prefixed with "Manager/"
                    // The typeof(T) will return the type, but prefixed "Snatcher."
                    // This is because the managers are all under the namespace "Snatcher"
                    // To get rid of that we call the C# String.Substring method and get the substring starting from index 9
                    // 9 because "Snatcher." is 9 characters long and the index is zero-based
                    string path = "Manager/" + typeof(T).ToString().Substring(9);
                    _instance = Resources.Load<T>(path);
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