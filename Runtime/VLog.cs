using System;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;


namespace UniEnt.Unity_QOL.Runtime {


    // ReSharper disable once MemberCanBeInternal
    public static class VLog {


        const string PurpleLightColor = "724972";
        const string PurpleDarkColor = "bd94bd";
        const string ThistleLightColor = "90319f";
        const string ThistleDarkColor = "db7cea";
        const string RaspberryLightColor = "c62451";
        const string RaspberryDarkColor = "ff799e";

        const string GreenLightColor = "3b643b";
        const string GreenDarkColor = "94bd94";
        const string PistachioLightColor = "40721f";
        const string PistachioDarkColor = "8bbd6a";
        const string EmeraldLightColor = "138247";
        const string EmeraldDarkColor = "5ecd92";

        const string BlueLightColor = "53607c";
        const string BlueDarkColor = "94a1bd";
        const string PeriwinkleLightColor = "514cba";
        const string PeriwinkleDarkColor = "9e99ff";
        const string SapphireLightColor = "355ea9";
        const string SapphireDarkColor = "80a9f4";

        const string RedLightColor = "7c5353";
        const string RedDarkColor = "bd9494";
        const string TerracottaLightColor = "a73c27";
        const string TerracottaDarkColor = "f28772";
        const string FawnLightColor = "7e5225";
        const string FawnDarkColor = "c99d70";


        /// <summary>
        ///     Log a low-priority detail message.
        ///     So far, this is just a placeholder for more advanced detail logging, when it's needed.
        ///     API will remain the same.
        /// </summary>
        /// <param name="line">Line to print</param>
        public static void Detail(string line) {
            Debug.Log(line);
        }


        /// <summary>
        ///     Log something as an error.
        /// </summary>
        /// <param name="line">Line to print</param>
        public static void Error(string line) {
            Debug.LogError(line);
        }


        // ReSharper disable once MemberCanBeInternal
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
            Debug.Log($"<color=#{PurpleColor}><b>{line}</b></color>");
            #else
            Debug.Log(line);
            #endif
        }


        /// <summary>
        ///     Log a physics line.
        /// </summary>
        /// <param name="line">Line to print</param>
        public static void Physics(string line) {
            #if UNITY_EDITOR
            Debug.Log($"<color=#{PeriwinkleColor}><b>{line}</b></color>");
            #else
            Debug.Log(line);
            #endif
        }


        /// <summary>
        ///     Log an animation line.
        /// </summary>
        /// <param name="line">Line to print</param>
        public static void Animation(string line) {
            #if UNITY_EDITOR
            Debug.Log($"<color=#{ThistleColor}><b>{line}</b></color>");
            #else
            Debug.Log(line);
            #endif
        }


        /// <summary>
        ///     Log a Intercom line.
        /// </summary>
        /// <param name="line">Line to print</param>
        public static void Intercom(string line) {
            #if UNITY_EDITOR
            Debug.Log($"<color=#{RaspberryColor}><b>{line}</b></color>");
            #else
            Debug.Log(line);
            #endif
        }


        /// <summary>
        ///     Log a game flow line.
        /// </summary>
        /// <param name="line">Line to print</param>
        public static void GameFlow(string line) {
            #if UNITY_EDITOR
            Debug.Log($"<color=#{PistachioColor}><b>{line}</b></color>");
            #else
            Debug.Log(line);
            #endif
        }


        /// <summary>
        ///     Log a system line.
        /// </summary>
        /// <param name="line">Line to print</param>
        public static void System(string line) {
            #if UNITY_EDITOR
            Debug.Log($"<color=#{TerracottaColor}><b>{line}</b></color>");
            #else
            Debug.Log(line);
            #endif
        }


        #region Color Getters


        #if UNITY_EDITOR


        [NotNull] static string PurpleColor => EditorGUIUtility.isProSkin ? PurpleDarkColor : PurpleLightColor;

        [NotNull] static string ThistleColor => EditorGUIUtility.isProSkin ? ThistleDarkColor : ThistleLightColor;

        [NotNull] static string RaspberryColor => EditorGUIUtility.isProSkin ? RaspberryDarkColor : RaspberryLightColor;

        [NotNull] static string GreenColor => EditorGUIUtility.isProSkin ? GreenDarkColor : GreenLightColor;

        [NotNull] static string PistachioColor => EditorGUIUtility.isProSkin ? PistachioDarkColor : PistachioLightColor;

        [NotNull] static string EmeraldColor => EditorGUIUtility.isProSkin ? EmeraldDarkColor : EmeraldLightColor;

        [NotNull] static string BlueColor => EditorGUIUtility.isProSkin ? BlueDarkColor : BlueLightColor;

        [NotNull] static string PeriwinkleColor => EditorGUIUtility.isProSkin ? PeriwinkleDarkColor : PeriwinkleLightColor;

        [NotNull] static string SapphireColor => EditorGUIUtility.isProSkin ? SapphireDarkColor : SapphireLightColor;

        [NotNull] static string RedColor => EditorGUIUtility.isProSkin ? RedDarkColor : RedLightColor;

        [NotNull] static string TerracottaColor => EditorGUIUtility.isProSkin ? TerracottaDarkColor : TerracottaLightColor;

        [NotNull] static string FawnColor => EditorGUIUtility.isProSkin ? FawnDarkColor : FawnLightColor;


        #endif // UNITY_EDITOR


        #endregion Color Getters


        #region Deprecated API


        /// <summary>
        ///     Log something with a purple accent.
        ///     Deprecated: Please call only semantic API like VLog.Detail().
        /// </summary>
        /// <param name="line">Line to print</param>
        [Obsolete("Please call only semantic methods like VLog.Detail().")]
        public static void Purple(string line) {
            #if UNITY_EDITOR
            Debug.Log($"<color=#{PurpleColor}><b>{line}</b></color>");
            #else
            Debug.Log(line);
            #endif
        }


        /// <summary>
        ///     Log something with a green accent.
        ///     Deprecated: Please call only semantic methods like VLog.Detail().
        /// </summary>
        /// <param name="line">Line to print</param>
        [Obsolete("Please call only semantic methods like VLog.Detail().")]
        public static void Green(string line) {
            #if UNITY_EDITOR
            Debug.Log($"<color=#{GreenColor}><b>{line}</b></color>");
            #else
            Debug.Log(line);
            #endif
        }


        /// <summary>
        ///     Log something with a blue accent.
        ///     Deprecated: Please call only semantic methods like VLog.Detail().
        /// </summary>
        /// <param name="line">Line to print</param>
        [Obsolete("Please call only semantic methods like VLog.Detail().")]
        public static void Blue(string line) {
            #if UNITY_EDITOR
            Debug.Log($"<color=#{BlueColor}><b>{line}</b></color>");
            #else
            Debug.Log(line);
            #endif
        }


        /// <summary>
        ///     Log something with a red accent.
        ///     Deprecated: Please call only semantic methods like VLog.Detail().
        /// </summary>
        /// <param name="line">Line to print</param>
        [Obsolete("Please call only semantic methods like VLog.Detail().")]
        public static void Red(string line) {
            #if UNITY_EDITOR
            Debug.Log($"<color=#{RedColor}><b>{line}</b></color>");
            #else
            Debug.Log(line);
            #endif
        }


        #endregion Deprecated API


    }


}
