using UnityEngine;


namespace UniEnt.Unity_QOL.Runtime {


    // ReSharper disable once ClassCanBeSealed.Global
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {


        // Check to see if we're about to be destroyed.
        // ReSharper disable once StaticMemberInGenericType
        static readonly object SLock = new();
        static T _sInstance;


        // ReSharper disable once MemberCanBeInternal
        /// <summary>
        ///     Access singleton instance through this property.
        /// </summary>
        /// <remarks>This instance will persist across scene changes.</remarks>
        public static T Instance {
            get {
                lock (SLock) {
                    if (_sInstance != null)
                        return _sInstance;

                    // Search for existing instance.
                    _sInstance = (T)FindObjectOfType(typeof(T));

                    // Create new instance if one doesn't already exist.
                    if (_sInstance != null)
                        return _sInstance;

                    // Need to create a new GameObject to attach the singleton to.
                    var singletonObject = new GameObject();
                    _sInstance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T) + " (Singleton)";

                    // Make instance persistent.
                    DontDestroyOnLoad(singletonObject);

                    return _sInstance;
                }
            }
        }


        // ReSharper disable once MemberCanBeInternal
        /// <summary>
        ///     Access non persistent singleton instance through this property.
        /// </summary>
        /// <remarks>This instance will not persist across scene changes.</remarks>
        public static T NonPersistentInstance {
            get {
                lock (SLock) {
                    if (_sInstance != null)
                        return _sInstance;

                    // Search for existing instance.
                    _sInstance = (T)FindObjectOfType(typeof(T));

                    // Create new instance if one doesn't already exist.
                    if (_sInstance != null)
                        return _sInstance;

                    // Need to create a new GameObject to attach the singleton to.
                    var singletonObject = new GameObject();
                    _sInstance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T) + " (Singleton)";

                    return _sInstance;
                }
            }
        }


        void OnDestroy() {
            lock (SLock)
                _sInstance = null;
        }


    }


}
