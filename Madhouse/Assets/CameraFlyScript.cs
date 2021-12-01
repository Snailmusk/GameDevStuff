using UnityEngine;
using System.Collections;
 
public class CameraFlyScript : MonoBehaviour {

    /*
    Writen by Windexglow 11-13-10.  Use it, edit it, steal it I don't care.  
    Converted to C# 27-02-13 - no credit wanted.
    Simple flycam I made, since I couldn't find any others made public.  
    Made simple to use (drag and drop, done) for regular keyboard layout  
    wasd : basic movement
    shift : Makes camera accelerate
    space : Moves camera on X and Z axis only.  So camera doesn't gain any height*/

    public Transform camtrans;
    public Transform maintrans;
    private int movespeed = 5;
    private int rospeed = 3;
    private int floatspeed = 5;
    void Update () {
        if (Input.GetKey(KeyCode.E))
        {
            camtrans.RotateAroundLocal(Vector3.up, 3f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            camtrans.RotateAroundLocal(Vector3.up, -3f * Time.deltaTime);
        }
        Vector3 p = GetBaseInput();
        p = p * Time.deltaTime;
        maintrans.position += p;
        
    }
     
    private Vector3 GetBaseInput() { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey (KeyCode.W)){
            p_Velocity += new Vector3(0, 0 , movespeed);
        }
        if (Input.GetKey (KeyCode.S)){
            p_Velocity += new Vector3(0, 0, -movespeed);
        }
        if (Input.GetKey (KeyCode.A)){
            p_Velocity += new Vector3(-movespeed, 0, 0);
        }
        if (Input.GetKey (KeyCode.D)){
            p_Velocity += new Vector3(movespeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            p_Velocity += new Vector3(0, floatspeed, 0);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            p_Velocity += new Vector3(0, -floatspeed, 0);
        }
        return p_Velocity;
    }
}