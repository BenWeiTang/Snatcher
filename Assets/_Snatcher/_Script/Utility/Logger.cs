using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Snatcher
{
    public static class Logger
    {
        private static string Color(this string myStr, string color)
        {
            return $"<color={color}>{myStr}</color>";
        }

        private static void DoUnityObjectLog(Action<string, Object> logFunction, string prefix, Object myObj, params object[] msg)
        {
#if UNITY_EDITOR
            var name = (myObj ? myObj.name : "NullObject").Color("lightblue");
            logFunction($"{prefix}[{name}]: {string.Join("; ", msg)}\n ", myObj);
#endif
        }

        private static void DoCSharpObjectLog(Action<string> logFunction, string prefix, string entityName, params object[] msg)
        {
#if UNITY_EDITOR
            var name = (entityName.Length == 0 ? "___" : entityName).Color("lightblue");
            logFunction($"{prefix}[{name}]: {string.Join("; ", msg)}\n");
#endif
        }

        public static void Log(this Object myObj, params object[] msg)
        {
            DoUnityObjectLog(Debug.Log, "", myObj, msg);
        }

        public static void Log(this System.Object myObject, params object[] msg)
        {
            DoCSharpObjectLog(Debug.Log, "", myObject.ToString(), msg);
        }
        
        public static void LogError(this Object myObj, params object[] msg)
        {
            DoUnityObjectLog(Debug.LogError, "<!>".Color("red"), myObj, msg);
        }
        
        public static void LogError(this System.Object myObject, params object[] msg)
        {
            DoCSharpObjectLog(Debug.LogError, "<!>".Color("red"), myObject.ToString(), msg);
        }

        public static void LogWarning(this Object myObj, params object[] msg)
        {
            DoUnityObjectLog(Debug.LogWarning, "⚠️".Color("yellow"), myObj, msg);
        }
        
        public static void LogWarning(this System.Object myObject, params object[] msg)
        {
            DoCSharpObjectLog(Debug.LogWarning, "⚠️".Color("yellow"), myObject.ToString(), msg);
        }

        public static void LogSuccess(this Object myObj, params object[] msg)
        {
            DoUnityObjectLog(Debug.Log, "☻".Color("green"), myObj, msg);
        }
        
        public static void LogSuccess(this System.Object myObject, params object[] msg)
        {
            DoCSharpObjectLog(Debug.Log, "☻️".Color("green"), myObject.ToString(), msg);
        }
    }
}