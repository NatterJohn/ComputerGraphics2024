using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using Random = System.Random;

public class Outcode
{
    public Boolean up = false;
    public Boolean down = false;
    public Boolean left = false;
    public Boolean right = false;
    public Outcode(Vector2 point) {
        up = point.y > 1;
        down = point.y < -1;
        left = point.x < -1;
        right = point.x > 1;
        
    }
    public Outcode(Boolean upIn, Boolean downIn, Boolean leftIn, Boolean rightIn)
    {
        up = upIn;
        down = downIn;
        left = leftIn;
        right = rightIn;

    }

    public void displayOutcode()
    {
        String outputString = (up ? "1" : "0") + (down ? "1" : "0") + (left ? "1" : "0") + (right ? "1" : "0");
        Debug.Log(outputString);
    }
    public static Outcode operator +(Outcode a, Outcode b)
    { return new Outcode(a.up || b.up, a.down || b.down, a.left || b.left, a.right || b.right); }
    public static Outcode operator *(Outcode a, Outcode b)
    { return new Outcode(a.up && b.up, a.down && b.down, a.left && b.left, a.right && b.right); }
    public static Boolean operator ==(Outcode a, Outcode b)
    { return (a.up == b.up) && (a.down == b.down) && (a.left == b.left) && (a.right == b.right); }
    public static Boolean operator !=(Outcode a, Outcode b)
    { return !(a == b); }
}