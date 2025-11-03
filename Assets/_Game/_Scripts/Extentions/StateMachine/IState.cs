using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void EnterState();
    void UpdateState();
    void ExitState();
    /*
    In Child Class
    Any : IState
    {
        GameObject go;
        public Any(GameObject go){
            //cache
        }
        EnterState(){
        }
        UpdateState(){
        }
        ExitState(){
        }
    }
     */
}
