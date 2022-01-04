using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace UniEnt.Unity_QOL.Runtime {


    public static class PrefabNameRevert {


        #if UNITY_EDITOR


        [MenuItem("Tools/Universal Entities/Revert Name %#&E")]
        static void RevertPrefabNames() {
            RevertAllNames(Selection.GetFiltered(typeof(GameObject), SelectionMode.Editable));
        }


        static void RemoveNameModification(Object aObj) {
            var mods = new List<PropertyModification>(PrefabUtility.GetPropertyModifications(aObj));

            for (var i = 0; i < mods.Count; i++) {
                if (mods[i].propertyPath == "m_Name")
                    mods.RemoveAt(i);
            }

            PrefabUtility.SetPropertyModifications(aObj, mods.ToArray());
        }


        static void RevertAllNames([NotNull] IEnumerable<Object> aObjects) {
            var items = new List<Object>();

            foreach (Object item in aObjects) {
                Object prefab = PrefabUtility.GetPrefabParent(item);

                if (prefab == null)
                    continue;

                Undo.RecordObject(item, "Revert prefab name");
                item.name = prefab.name;
                items.Add(item);
            }

            Undo.FlushUndoRecordObjects();

            foreach (Object item in items)
                RemoveNameModification(item);
        }


        #endif


    }


}
