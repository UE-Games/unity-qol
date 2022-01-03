using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
#endif


namespace UniEnt.UnityQOL.Runtime {


    static class VLog {


        const string PurpleLightColor = "724972";
        const string PurpleDarkColor = "bd94bd";
        const string GreenLightColor = "3b643b";
        const string GreenDarkColor = "94bd94";
        const string BlueLightColor = "53607c";
        const string BlueDarkColor = "94a1bd";
        const string RedLightColor = "7c5353";
        const string RedDarkColor = "bd9494";


        /// <summary>
        ///     Log something with a purple accent.
        /// </summary>
        /// <param name="line">Line to print</param>
        public static void Purple(string line) {
            #if UNITY_EDITOR
            Debug.Log($"<color=#{(EditorGUIUtility.isProSkin ? PurpleDarkColor : PurpleLightColor)}><b>{line}</b></color>");
            #else
            Debug.Log(line);
            #endif
        }


        /// <summary>
        ///     Log something with a green accent.
        /// </summary>
        /// <param name="line">Line to print</param>
        public static void Green(string line) {
            #if UNITY_EDITOR
            Debug.Log($"<color=#{(EditorGUIUtility.isProSkin ? GreenDarkColor : GreenLightColor)}><b>{line}</b></color>");
            #else
            Debug.Log(line);
            #endif
        }


        /// <summary>
        ///     Log something with a blue accent.
        /// </summary>
        /// <param name="line">Line to print</param>
        public static void Blue(string line) {
            #if UNITY_EDITOR
            Debug.Log($"<color=#{(EditorGUIUtility.isProSkin ? BlueDarkColor : BlueLightColor)}><b>{line}</b></color>");
            #else
            Debug.Log(line);
            #endif
        }


        /// <summary>
        ///     Log something with a red accent.
        /// </summary>
        /// <param name="line">Line to print</param>
        public static void Red(string line) {
            #if UNITY_EDITOR
            Debug.Log($"<color=#{(EditorGUIUtility.isProSkin ? RedDarkColor : RedLightColor)}><b>{line}</b></color>");
            #else
            Debug.Log(line);
            #endif
        }


        /// <summary>
        ///     Log something as an error.
        /// </summary>
        /// <param name="line">Line to print</param>
        public static void Error(string line) {
            Debug.LogError(line);
        }


        /// <summary>
        ///     Log something as a warning.
        /// </summary>
        /// <param name="line">Line to print</param>
        public static void Warning(string line) {
            Debug.LogWarning(line);
        }


        /// <summary>
        ///     Log a statistic line.
        /// </summary>
        /// <param name="line">Line to print</param>
        public static void Statistic(string line) {
            #if UNITY_EDITOR
            Debug.Log($"<color=#{(EditorGUIUtility.isProSkin ? PurpleDarkColor : PurpleLightColor)}><b>{line}</b></color>");
            #else
            Debug.Log(line);
            #endif
        }


    }


}
