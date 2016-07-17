using UnityEngine;
using System.Collections;

public class Singleton {
    static Singleton instance;
 
    public static Singleton Instance {
        get {
            if (instance == null) {
                instance = new Singleton ();
            }
            return instance;
        }
    }
}
