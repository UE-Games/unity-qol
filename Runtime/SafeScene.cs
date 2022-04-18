using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace UniEnt.Unity_QOL.Runtime {


    // ReSharper disable once UnusedType.Global
    public static class SafeScene {


        // ReSharper disable once UnusedMember.Global
        /// <summary>
        ///     Unload a scene the safest way possible.
        /// </summary>
        /// <param name="id">Scene ID to load.</param>
        public static void /* IEnumerator */ Unload(string id) {
            Debug.Log($"Scene unload `{id}`");

            /* AsyncOperation task = */
            SceneManager.UnloadSceneAsync(id, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);

            // FIXME: Timeouts during UnloadSceneAsync task execution
            // Even with SceneManager.UnloadSceneAsync() called synchronously (and not waiting for the async task to
            // finish), the unload sometimes doesn't end. We can't block the execution of the queues relying on
            // unloading levels, so until we figure out a better way to unload with no timeouts, we need to do this
            // synchronously.

            /*
            while (!task.isDone) {
                Debug.Log("‣ Scene unload in progress");

                yield return null;
            }

            Debug.Log("✓ Scene unload done");

            yield return null;
            */
        }


        // ReSharper disable once UnusedMember.Global
        /// <summary>
        ///     Unload unused assets. Used usually after unloading a scene.
        ///     This is really just a shortcut to Resources.UnloadUnusedAssets, except it also provides a useful
        ///     output to the console, so that we know what's going on.
        /// </summary>
        /// <returns></returns>
        public static void /* IEnumerator */ UnloadUnusedAssets() {
            Debug.Log("Unload unused assets");

            /* AsyncOperation task = */
            Resources.UnloadUnusedAssets();

            // FIXME: Timeouts during UnloadSceneAsync task execution
            // This probably can't work at all, as this method is called in a queue as soon as Unload() (resulting in
            // SceneManager.UnloadSceneAsync() as seen above). If the Unload() method doesn't chain in a queue, this
            // method can't find resources to unload (the scene is still alive at that moment. We need to figure out
            // the timeouts in Unload() to help with this method too.

            /*
            while (!task.isDone) {
                Debug.Log("‣ Unload unused assets in progress");

                yield return null;
            }

            Debug.Log("✓ Unload unused assets done");

            yield return null;
            */
        }


        // ReSharper disable once UnusedMember.Global
        /// <summary>
        ///     Load a scene the safest way possible.
        /// </summary>
        /// <param name="id">Scene ID to load.</param>
        /// <param name="force">true if there is no need to wait for the scene activation.</param>
        public static IEnumerator Load(string id, bool force = false) {
            Debug.Log(force ? $"Scene load '{id}' in force mode" : $"Scene load '{id}'");

            AsyncOperation task = SceneManager.LoadSceneAsync(id, LoadSceneMode.Additive);

            if (!force)
                task.allowSceneActivation = false;

            while (!task.isDone) {
                Debug.Log($"‣ Scene load in progress: {task.progress * 100:F0}%");

                if (task.progress >= 0.9f) {
                    Debug.Log("✓ Scene load done");

                    if (!force)
                        task.allowSceneActivation = true;

                    yield break;
                }

                yield return null;
            }

            Debug.Log("✓ Scene load done");

            yield return null;
        }


        // ReSharper disable once UnusedMember.Global
        /// <summary>
        ///     Check if the scene is currently loaded.
        /// </summary>
        /// <param name="id">Scene ID to check.</param>
        /// <returns>true if the scene is currently loaded.</returns>
        public static bool IsSceneLoaded(string id) {
            Scene scene = SceneManager.GetSceneByName(id);

            return scene.IsValid() && scene.isLoaded;
        }


    }


}
