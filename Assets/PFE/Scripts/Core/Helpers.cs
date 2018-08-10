﻿using UnityEngine;

namespace PFE.Helpers {
    /// <summary>
    /// https://answers.unity.com/questions/799429/transformfindstring-no-longer-finds-grandchild.html
    /// </summary>
    public static class TransformDeepChildExtension {
        //Breadth-first search
        public static Transform FindDeepChild(this Transform aParent, string aName) {
            var result = aParent.Find(aName);
            if (result != null)
                return result;
            foreach (Transform child in aParent) {
                result = child.FindDeepChild(aName);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}
